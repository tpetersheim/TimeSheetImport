using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StringExtensions;

namespace TimeSheetImport
{
    internal static class MessageHelper
    {
        internal static void ShowError(string message, string title = "")
        {
            MessageBox.Show(message, "ERROR: Time Sheet Import - " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        internal static void ShowError(Exception exception, string title = "")
        {
            MessageBox.Show("Exception:\n\n{0}".With(exception.ToString()), "ERROR: Time Sheet Import - " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void ShowMessage(string message, string title = "")
        {
            MessageBox.Show(message, "Time Sheet Import - " + title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
