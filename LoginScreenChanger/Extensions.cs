using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginScreenChanger
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return false;

            int temp;
            int.TryParse(source, out temp);

            return temp > 0;
        }
    }
}
