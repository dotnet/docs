// <Snippet1>
using System;
using System.Globalization;

class Example 
{
    public static void Main() 
    {
       string str1 = "indigo";
       string str2, str3;
   
       // str2 is an uppercase copy of str1, using English-United States culture.
       str2 = str1.ToUpper(new CultureInfo("en-US", false));
   
       // str3 is an uppercase copy of str1, using Turkish-Turkey culture.
       str3 = str1.ToUpper(new CultureInfo("tr-TR", false));
   
       // Compare the code points and compare the uppercase strings.
       ShowCodePoints("str1", str1);
       ShowCodePoints("str2", str2);
       ShowCodePoints("str3", str3);
       Console.WriteLine("str2 is {0} to str3.", 
            String.CompareOrdinal(str2, str3) == 0 ? "equal" : "not equal");
    }

    public static void ShowCodePoints(string varName, string s)
    {
       Console.Write("{0} = {1}: ", varName, s);
       foreach (ushort u in s)
         Console.Write("{0:x4} ", u);
       Console.WriteLine();
    }
}
// This example displays the following output:
//       str1 = indigo: 0069 006e 0064 0069 0067 006f
//       str2 = INDIGO: 0049 004e 0044 0049 0047 004f
//       str3 = INDIGO: 0130 004e 0044 0130 0047 004f
//       str2 is not equal to str3.
// </Snippet1>
