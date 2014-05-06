using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ExcelWrapper;

namespace TimeSheetImport
{
    public class TimeSheetExcel
    {
        private const string WORKSHEET_NAME = "Worksheet";
        private ExcelSpreadsheet Spreadsheet;

        public TimeSheetExcel(string spreadsheetFilePath)
        {

            load(spreadsheetFilePath);
        }

        private bool validate(string spreadsheetFilePath)
        {
            bool valid = false;

            if (File.Exists(spreadsheetFilePath))
            {
                valid = true;
            }

            return valid;
        }

        private void load(string backupFilePath)
        {
            Spreadsheet.
        }
    }
}
