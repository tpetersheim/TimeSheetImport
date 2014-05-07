using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Taramon.Exceller;

namespace TimeSheetImport
{
    public class TimeSheetExcel
    {
        private const string WorksheetName = "Worksheet";
        private const string AColumnHeader = "Date";
        private ExcelManager excelManager;

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
                    Utility.ShowError(string.Format("Worksheet named '{0}' could not be found.", WorksheetName), "Excel Template");
                }
            }
            else
                throw new FileNotFoundException("TimeSheetExcel file not found");
        }

        public void WriteEntry(TimeSheetExcelEntry entry)
        {
            int nextEntryRow = findRowOfEntryHeaders();

            setCell("A" + nextEntryRow, entry.Date);

        }

        private int findRowOfNextEntry()
        {
            int nextEntry;
            int rowOfEntryHeaders = findRowOfEntryHeaders();
            const int maxEntryRows = 26;
            int lastEntryRow = maxEntryRows + rowOfEntryHeaders;

            for (nextEntry = rowOfEntryHeaders + 1; nextEntry <= lastEntryRow ; nextEntry++)
            {
                if (string.IsNullOrEmpty(getCellString(string.Format("A{0}", nextEntry))))
                    break;
            }

            return nextEntry;
        }

        private int findRowOfEntryHeaders()
        {
            int entryHeaderRow;

            for (entryHeaderRow = 1; entryHeaderRow < 100; entryHeaderRow++)
            {
                string cellVal = getCellString(string.Format("A{0}", entryHeaderRow));
                if (cellVal == KeyCells.Date)
                    break;
            }

            return entryHeaderRow;
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
                Utility.ShowError(string.Format("Unable to set value '{0}' to cell '{1}'", value, cellAddress), "Bad cell value");
                return false;
            }
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

        private static class KeyCells
        {
            public static string Date { get { return "Date"; } }
            public static string PayPeriod { get { return "Pay Period"; } }
        }
    }

    public class TimeSheetExcelEntry
    {
        public DateTime Date { get; set; }
        public TimeSheetExcelJob Job { get; set; }
        public TimeSheetExcelItem Item { get; set; }
        public string Notes { get; set; }
        public TimeSpan Hours { get; set; }
    }

    public class TimeSheetExcelJob
    {
        public string Name { get; set; }
    }

    public class TimeSheetExcelItem
    {
        public string Name { get; set; }
    }
}
