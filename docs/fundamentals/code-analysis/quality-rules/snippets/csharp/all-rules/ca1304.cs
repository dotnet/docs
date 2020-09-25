using System;
using System.Globalization;
using System.Threading;

namespace ca1304
{
    //<snippet1>
    public class CultureInfoTest
    {
        public void BadMethod(String string1, String string2, String string3)
        {
            if (string.Compare(string1, string2, false) == 0)
            {
                Console.WriteLine(string3.ToLower());
            }
        }

        public void GoodMethod(String string1, String string2, String string3)
        {
            if (string.Compare(string1, string2, false,
                              CultureInfo.InvariantCulture) == 0)
            {
                Console.WriteLine(string3.ToLower(CultureInfo.CurrentCulture));
            }
        }
    }
    //</snippet1>

    //<snippet2>
    public class IFormatProviderTest
    {
        public static void Main1304()
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
    //</snippet2>
}
