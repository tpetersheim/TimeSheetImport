using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeSheetImport
{
    internal static class FileHelper
    {
        public static string UserFolderPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); }  }
        public static string DefaultDropboxPath { get { return Path.Combine(UserFolderPath, "Dropbox"); } }
        public static string DefaultTimeSheetBackupFilePath { get { return Path.Combine(DefaultDropboxPath, "TimeSheet", "Backup"); } }

        public static string DefaultOutputTimeSheetFileName{ get { return DateTime.Now.ToString() + "TimeSheet.xlsx"; } }

        public static bool IsValidFileName(string filename)
        {
            return !(string.IsNullOrEmpty(filename) || filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0);
        }
    }
}
