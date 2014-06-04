using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSheetImport
{
    public class ImportProgressReport
    {
        public int TotalEntries { get; set; }
        public int CurrentEntryIndex { get; set; }
        public string CurrentEntryDescription { get; set; }
    }
}
