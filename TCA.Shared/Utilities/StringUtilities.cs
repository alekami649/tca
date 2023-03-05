using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCA.Shared;

namespace TCA.Utilities
{
    public static class StringUtilities
    {
        public static string ReplacePascalCase(this string str)
        {
            var builder = new StringBuilder();
            var firstChat = true;
            foreach (var c in str)
            {
                if (firstChat && char.IsUpper(c))
                {
                    builder.Append(c);
                    firstChat = false;
                }
                else if (char.IsUpper(c))
                {
                    builder.Append(' ');
                    builder.Append(char.ToLower(c));
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
        public static string ReplaceInvariant(this string str, string from, string to)
        {
            return str.Replace(from, to, StringComparison.InvariantCultureIgnoreCase);
        }
        public static bool ContainsInvariant(this string str, string str2)
        {
            return str.Contains(str2, StringComparison.InvariantCultureIgnoreCase);
        }
        public static int IndexOfInvariant(this string str, string str2)
        {
            return str.IndexOf(str2, comparisonType: StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
