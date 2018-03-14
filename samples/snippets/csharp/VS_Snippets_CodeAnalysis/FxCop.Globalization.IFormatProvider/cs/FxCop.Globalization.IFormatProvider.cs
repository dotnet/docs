//<Snippet1>
using System;
using System.Globalization;
using System.Threading;

namespace GlobalLibGlobalLibrary
{
    public class IFormatProviderTest
    {
        public static void Main()
        {
            string dt = "6/4/1900 12:15:12";

            // The default behavior of DateTime.Parse is to use
            // the current culture.
            
            // Violates rule: SpecifyIFormatProvider.
            DateTime myDateTime = DateTime.Parse(dt);
            Console.WriteLine(myDateTime);
            
            // Change the current culture to the French culture,
            // and parsing the same string yields a different value.
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("Fr-fr", true);
            myDateTime = DateTime.Parse(dt);
            
            Console.WriteLine(myDateTime);
        }
    }
}
//</Snippet1>
