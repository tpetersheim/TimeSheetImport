using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
{
    public static class StringExtensions
    {
        public static string With(this string s, params object[] parameters)
        {
            return string.Format(s, parameters);
        }
    }
}
