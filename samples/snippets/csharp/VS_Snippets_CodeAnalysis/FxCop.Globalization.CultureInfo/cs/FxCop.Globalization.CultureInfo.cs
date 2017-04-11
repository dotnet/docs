//<Snippet1>
using System;
using System.Globalization;

namespace GlobalizationLibrary
{
    public class CultureInfoTest
    {
        public void BadMethod(String string1, String string2, String string3)
        {
            if(string.Compare(string1, string2, false) == 0)
            {
                Console.WriteLine(string3.ToLower());
            }
        }

        public void GoodMethod(String string1, String string2, String string3)
        {
            if(string.Compare(string1, string2, false, 
                              CultureInfo.InvariantCulture) == 0)
            {
                Console.WriteLine(string3.ToLower(CultureInfo.CurrentCulture));
            }
        }
    }
}
//</Snippet1>
