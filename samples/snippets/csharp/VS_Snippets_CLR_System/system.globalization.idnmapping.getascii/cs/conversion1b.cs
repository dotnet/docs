// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string email = "johann_doe@bücher.com john_doe@hotmail.com иван@мойдомен.рф";
      IdnMapping idn = new IdnMapping();
      int start = 0, end = 0;
      
      while (end >= 0) {
         start = email.IndexOf("@", end);
         end = email.IndexOf(" ", start);
         string domain = String.Empty;

         try {
            string punyCode = String.Empty;
            if (start >= 0 && end >= 0) { 
               domain = email.Substring(start + 1, end - start - 1);
               punyCode = idn.GetAscii(email, start + 1, end - start - 1);
            }
            else {
               domain = email.Substring(start + 1);
               punyCode = idn.GetAscii(email, start + 1);
            }
            string name2 = idn.GetUnicode(punyCode);
            Console.WriteLine("{0} --> {1} --> {2}", domain, punyCode, name2); 
         }   
         catch (ArgumentException) { 
            Console.WriteLine("{0} is not a valid domain name.", domain);
         }
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//       bücher.com --> xn--bcher-kva.com --> bücher.com
//       
//       hotmail.com --> hotmail.com --> hotmail.com
//       
//       мойдомен.рф --> xn--d1acklchcc.xn--p1ai --> мойдомен.рф
// </Snippet3>
