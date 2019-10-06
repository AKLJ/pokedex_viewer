using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Utils
{
    public static class Extensions
    {
        /// <summary>
        /// Allowing to format a URI string with routed parameters args kindly without calling eachtime string format
        /// </summary>
        /// <param name="s">the URI string to format</param>
        /// <param name="querys">Route arguments</param>
        /// <returns></returns>
        public static string APIUriFormatter(this string s, params string[] querys)
        {
            return string.Format(s, querys);
        }
    }
}
