using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TimeSheetImport
{
    public class TimeSheetExcelEntry
    {
        public DateTime Date { get; set; }
        public string Job { get; set; }
        public string Item { get; set; }
        public string Notes { get; set; }
        public TimeSpan Hours { get; set; }
    }

    public class TimeSheetExcelJob
    {
        public string Name { get; set; }
        public string NameLowercase { get { return Name.ToLower(); } }

        public string Code
        {
            get
            {
                var split = Name.Split(':');
                return (split.Length > 0 ? split[0] : "");
            }
        }

        public string CodeStripLastTwo { get { return Code.Substring(0, Code.Length - 2); } }
        public string CodeStripLastTwoLower { get { return CodeStripLastTwo.ToLower(); } }

        public TimeSheetExcelJob()
        {
            Name = string.Empty;
        }
    }

    public class TimeSheetExcelItem
    {
        public string Name { get; set; }
        public string NameLowercase { get { return Name.ToLower(); } }

        public TimeSheetExcelItem()
        {
            Name = string.Empty;
        }
    }
}
