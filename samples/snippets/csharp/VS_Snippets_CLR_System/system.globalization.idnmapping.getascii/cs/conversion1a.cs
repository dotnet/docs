// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] names = { "johann_doe@bücher.com", "vi@мойдомен.рф", "ia@παράδειγμα.δοκιμή",
                         "webmaster@mycharity\u3002org",
                         "admin@prose\u0000ware.com", "john_doe@proseware..com", 
                         "jane_doe@a.org", "me@my_company.com" };
      IdnMapping idn = new IdnMapping();
      
      foreach (var thisName in names) {
         string name = thisName;
         try {
            int position = name.LastIndexOf("@");
            if (position >= 0) 
               name = name.Substring(position + 1);

            string punyCode = idn.GetAscii(name);
            string name2 = idn.GetUnicode(punyCode);
            Console.WriteLine("{0} --> {1} --> {2}", name, punyCode, name2); 
            Console.WriteLine("Original: {0}", ShowCodePoints(name));
            Console.WriteLine("Restored: {0}", ShowCodePoints(name2));
         }   
         catch (ArgumentException) { 
            Console.WriteLine("{0} is not a valid domain name.", name);
         }
         Console.WriteLine();
      }   
   }

   private static string ShowCodePoints(string str1) 
   {
      string output = "";
      foreach (var ch in str1)
         output += String.Format("U+{0} ", Convert.ToUInt16(ch).ToString("X4"));
      
      return output;
   }
}
// The example displays the following output:
//    bücher.com --> xn--bcher-kva.com --> bücher.com
//    Original: U+0062 U+00FC U+0063 U+0068 U+0065 U+0072 U+002E U+0063 U+006F U+006D
//    Restored: U+0062 U+00FC U+0063 U+0068 U+0065 U+0072 U+002E U+0063 U+006F U+006D
//    
//    мойдомен.рф --> xn--d1acklchcc.xn--p1ai --> мойдомен.рф
//    Original: U+043C U+043E U+0439 U+0434 U+043E U+043C U+0435 U+043D U+002E U+0440 U+0444
//    Restored: U+043C U+043E U+0439 U+0434 U+043E U+043C U+0435 U+043D U+002E U+0440 U+0444
//    
//    παράδειγμα.δοκιμή --> xn--hxajbheg2az3al.xn--jxalpdlp --> παράδειγμα.δοκιμή
//    Original: U+03C0 U+03B1 U+03C1 U+03AC U+03B4 U+03B5 U+03B9 U+03B3 U+03BC U+03B1 U+002E U+03B4 U+03BF U+03BA U+03B9 U+03BC U+03AE
//    Restored: U+03C0 U+03B1 U+03C1 U+03AC U+03B4 U+03B5 U+03B9 U+03B3 U+03BC U+03B1 U+002E U+03B4 U+03BF U+03BA U+03B9 U+03BC U+03AE
//    
//    mycharity。org --> mycharity.org --> mycharity.org
//    Original: U+006D U+0079 U+0063 U+0068 U+0061 U+0072 U+0069 U+0074 U+0079 U+3002 U+006F U+0072 U+0067
//    Restored: U+006D U+0079 U+0063 U+0068 U+0061 U+0072 U+0069 U+0074 U+0079 U+002E U+006F U+0072 U+0067
//    
//    prose ware.com is not a valid domain name.
//    
//    proseware..com is not a valid domain name.
//    
//    a.org --> a.org --> a.org
//    Original: U+0061 U+002E U+006F U+0072 U+0067
//    Restored: U+0061 U+002E U+006F U+0072 U+0067
//    
//    my_company.com --> my_company.com --> my_company.com
//    Original: U+006D U+0079 U+005F U+0063 U+006F U+006D U+0070 U+0061 U+006E U+0079 U+002E U+0063 U+006F U+006D
//    Restored: U+006D U+0079 U+005F U+0063 U+006F U+006D U+0070 U+0061 U+006E U+0079 U+002E U+0063 U+006F U+006D
// </Snippet2>
