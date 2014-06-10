using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using StringExtensions;
using Taramon.Exceller;

namespace TimeSheetImport
{
    public class TimeSheetExcel
    {
        private const string WorksheetName = "Worksheet";
        private const string AColumnHeader = "Date";
        private const string denoteNoProjectNameFound = "**";
        private ExcelManager excelManager;
        private List<TimeSheetExcelJob> timeSheetExcelJobs;
        private List<TimeSheetExcelItem> timeSheetExcelItems;

        public TimeSheetExcel(string spreadsheetFilePath)
        {
            if (File.Exists(spreadsheetFilePath))
            {
                excelManager = new ExcelManager();
                excelManager.Open(spreadsheetFilePath);
                try
                {
                    excelManager.ActivateSheet(WorksheetName);
                }
                catch (Exception e)
                {
                    MessageHelper.ShowError("Worksheet named '{0}' could not be found.".With(WorksheetName), "Excel Template");
                }
            }
            else
                throw new FileNotFoundException("TimeSheetExcel file not found");

            parseTimeSheetExcelJobs();
            parseTimeSheetExcelItems();
        }

        private char findFirstRowText(string textToFind)
        {
            //Find the Item List section
            char column;

            for (column = 'A'; column < 'K'; column++)
            {
                string cellVal = getCellString(string.Format("{0}1", column));
                if (cellVal == textToFind)
                    break;
            }

            return column;
        }

        public void WriteEntry(TimeSheetExcelEntry entry)
        {
            int nextEntryRow = findRowOfNextEntry();

            var jobName = getJobName(entry.Job);
            var itemName = getItemName(entry.Item);

            setCell("A" + nextEntryRow, entry.Date.ToString("MM/dd/yy"));
            setCell("B" + nextEntryRow, (jobName != null ? jobName.Name : ""));
            setCell("C" + nextEntryRow, (itemName != null ? itemName.Name : ""));
            setCell("D" + nextEntryRow, entry.Notes);
            setCell("E" + nextEntryRow, roundToNearestQuarter(entry.Hours.TotalHours));
        }

        private TimeSheetExcelItem getItemName(string itemName)
        {
            if (!string.IsNullOrEmpty(itemName.Trim()))
                return timeSheetExcelItems.Where(i => i.NameLowercase.Contains(itemName.ToLower())).FirstOrDefault();
            else
                return new TimeSheetExcelItem();
        }

        private TimeSheetExcelJob getJobName(string jobName)
        {
            TimeSheetExcelJob job = null;
            string jobNameLower = jobName.ToLower();
            if (!string.IsNullOrEmpty(jobNameLower.Trim()))
            {
                job = timeSheetExcelJobs.Where(j => 
                    j.NameLowercase.Contains(jobNameLower) ||
                    jobNameLower.Contains(j.CodeStripLastTwoLower)
                ).FirstOrDefault();
            }

            //Check specifically for Errands job and match it to Pete01 job
            if (job == null && jobNameLower == "errands")
            {
                job = timeSheetExcelJobs.Where(j => j.Code == "Pete01").FirstOrDefault(); 
            }

            if (job == null)
                job = new TimeSheetExcelJob() { Name = denoteNoProjectNameFound + jobName };

            return job;
        }

        private int findRowOfNextEntry()
        {
            int nextEntry;
            int rowOfEntryHeaders = findRowOfEntryHeaders();
            const int lastEntryPadding = 3;
            int lastEntryRow = findLastEntryRow() - lastEntryPadding;

            for (nextEntry = rowOfEntryHeaders + 1; nextEntry <= 500; nextEntry++)
            {
                if (string.IsNullOrEmpty(getCellString("A{0}".With(nextEntry))))
                {
                    if (nextEntry > lastEntryRow)
                        InsertRow(nextEntry);
                    break;
                }
            }

            if (nextEntry == 500)
                MessageHelper.ShowError("Couldn't find where to write the next entry.", "Cannot write entries");

            return nextEntry;
        }

        private int findRowOfEntryHeaders()
        {
            int entryHeaderRow;

            for (entryHeaderRow = 1; entryHeaderRow <= 100; entryHeaderRow++)
            {
                string cellVal = getCellString(string.Format("A{0}", entryHeaderRow));
                if (cellVal == KeyCells.Date)
                    break;
            }

            if (entryHeaderRow == 100)
                MessageHelper.ShowError("Couldn't find headers of timesheet entries.", "Cannot write entries");

            return entryHeaderRow;
        }

        private int findLastEntryRow()
        {
            int lastEntryRow;

            for (lastEntryRow = 1; lastEntryRow < 100; lastEntryRow++)
            {
                string cellVal = getCellString(string.Format("D{0}", lastEntryRow));
                if (cellVal == KeyCells.TotalHours)
                    break;
            }

            if (lastEntryRow == 100)
                MessageHelper.ShowError("Couldn't find the last entry.", "Cannot write entries");

            return lastEntryRow - 1;
        }

        public bool SetPayPeriodStart(DateTime periodStart)
        {
            throw new NotImplementedException();
        }

        private string getPayPeriodStartCell()
        {
            throw new NotImplementedException();
        }

        public bool SetPayPeriodEnd(DateTime periodEnd)
        {
            throw new NotImplementedException();
        }

        public bool SetRatePerHour(decimal rate)
        {
            throw new NotImplementedException();
        }

        private void parseTimeSheetExcelItems()
        {
            timeSheetExcelItems = new List<TimeSheetExcelItem>();
            char columnOfHeader = findFirstRowText(KeyCells.ItemList);

            int row = 2;
            string cellContents = getCellString("{0}{1}".With(columnOfHeader, row));
            while (!string.IsNullOrEmpty(cellContents))
            {
                timeSheetExcelItems.Add(new TimeSheetExcelItem() { Name = cellContents });

                row++;
                cellContents = getCellString("{0}{1}".With(columnOfHeader, row));
            }
        }

        private void parseTimeSheetExcelJobs()
        {
            timeSheetExcelJobs = new List<TimeSheetExcelJob>();
            char columnOfHeader = findFirstRowText(KeyCells.JobInformation);

            int row = 2;
            string cellContents = getCellString("{0}{1}".With(columnOfHeader, row));
            while (!string.IsNullOrEmpty(cellContents))
            {
                timeSheetExcelJobs.Add(new TimeSheetExcelJob() { Name = cellContents });

                row++;
                cellContents = getCellString("{0}{1}".With(columnOfHeader, row));
            }
        }
        
        // Wrappers

        public void InsertRow(int row)
        {
            excelManager.InsertRow(row);
        }

        public void Close()
        {
            excelManager.Close();
        }

        public void Save()
        {
            excelManager.Save();
        }

        public bool AnyFileOpen
        {
            get { return excelManager.AnyFileOpen; }
        }

        public bool SaveAs(string filePath)
        {
            bool success = true;
            try
            {
                excelManager.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex, "Saving File");
                success = false;
            }
            return success;
        }

        private string getCellString(string cellAddress)
        {
            return excelManager.GetValue(cellAddress, Category.Formatted).ToString();
        }

        private bool setCell(string cellAddress, object value)
        {
            try
            {
                excelManager.SetValue(cellAddress, value);
                return true;
            }
            catch (Exception e)
            {
                MessageHelper.ShowError("Unable to set value '{0}' to cell '{1}'".With(value, cellAddress), "Bad cell value");
                return false;
            }
        }
        // End Wrappers

        private double roundToNearestQuarter(double value)
        {
            return Convert.ToDouble(Math.Round(value * 4, MidpointRounding.ToEven) / 4);
        }

        private static class KeyCells
        {
            public static string Date { get { return "Date"; } }
            public static string PayPeriod { get { return "Pay Period"; } }
            public static string JobInformation { get { return "Job Information"; } }
            public static string ItemList { get { return "Item List"; } }
            public static string TotalHours { get { return "Total Hours"; } }
        }
    }
}
