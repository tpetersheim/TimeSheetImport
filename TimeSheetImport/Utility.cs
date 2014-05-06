using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSheetImport
{
    internal static class Utility
    {
        internal static void ShowError(string message, string title = "")
        {
            MessageBox.Show(message, "ERROR: Time Sheet Import - " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void ShowMessage(string message, string title = "")
        {
            MessageBox.Show(message, "Time Sheet Import - " + title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
