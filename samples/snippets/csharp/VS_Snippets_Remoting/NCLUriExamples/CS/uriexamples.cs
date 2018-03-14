using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Runtime.Serialization;

namespace Example
{
    public class Test
    {

        public static void Main()
        { 
            // Snippets 1 and 2
            HexConversions();          
       
            // snippet 7
            SampleToString();

            // snippet 8
            SampleEquals();

            // snippets 4, 5, and 6
            GetParts();
       
            // snippet 3
            SampleMakeRelative();
          
            // snippets 9 - 17
            SampleCheckSchemeName();

            // snippet 18 
            SampleUserInfo();

            // snippet 19
            UnescapeUriWithPlusConversion();

        }

        private static void SampleToString()
        {
        //<snippet7>
            // Create a new Uri from a string address.
            Uri uriAddress = new Uri("HTTP://www.Contoso.com:80/thick%20and%20thin.htm");

            // Write the new Uri to the console and note the difference in the two values.
            // ToString() gives the canonical version.  OriginalString gives the orginal 
            // string that was passed to the constructor.

            // The following outputs "http://www.contoso.com/thick and thin.htm".
            Console.WriteLine(uriAddress.ToString()); 

            // The following outputs "HTTP://www.Contoso.com:80/thick%20and%20thin.htm".
            Console.WriteLine(uriAddress.OriginalString);
        //</snippet7>
        }

        private static void SampleEquals()
        {
        //<snippet8>
            // Create some Uris.
            Uri address1 = new Uri("http://www.contoso.com/index.htm#search");
            Uri address2 = new Uri("http://www.contoso.com/index.htm"); 
            if (address1.Equals(address2))
                Console.WriteLine("The two addresses are equal");
            else
                Console.WriteLine("The two addresses are not equal");
        //</snippet8>
        }
       
        private static void GetParts()
        {
        //<snippet4>
            // Create Uri
            Uri uriAddress = new Uri("http://www.contoso.com/index.htm#search");
            Console.WriteLine(uriAddress.Fragment);
            Console.WriteLine("Uri {0} the default port ", uriAddress.IsDefaultPort ? "uses" : "does not use");
             
            Console.WriteLine("The path of this Uri is {0}", uriAddress.GetLeftPart(UriPartial.Path));
            Console.WriteLine("Hash code {0}", uriAddress.GetHashCode());
        //</snippet4>
        //<snippet5>
            Uri uriAddress1 = new Uri("http://www.contoso.com/title/index.htm");
            Console.WriteLine("The parts are {0}, {1}, {2}", uriAddress1.Segments[0], uriAddress1.Segments[1], uriAddress1.Segments[2]);
        //</snippet5>
  
         //<snippet6>
            Uri uriAddress2 =  new Uri("file://server/filename.ext");
            Console.WriteLine(uriAddress2.LocalPath);
            Console.WriteLine("Uri {0} a UNC path", uriAddress2.IsUnc ? "is" : "is not");
            Console.WriteLine("Uri {0} a local host", uriAddress2.IsLoopback ? "is" : "is not");
            Console.WriteLine("Uri {0} a file", uriAddress2.IsFile ? "is" : "is not");
        //</snippet6>
            
        }

        private static void HexConversions()
        {
        //<snippet1>
            char  testChar = 'e';
            if (Uri.IsHexDigit(testChar) == true)
                Console.WriteLine("'{0}' is the hexadecimal representation of {1}", testChar, Uri.FromHex(testChar));
            else 
                Console.WriteLine("'{0}' is not a hexadecimal character", testChar);
            
            string returnString = Uri.HexEscape(testChar);
            Console.WriteLine("The hexadecimal value of '{0}' is {1}", testChar, returnString);
        //</snippet1>
     
        //<snippet2>
            string testString = "%75";
            int index = 0;
            if (Uri.IsHexEncoding(testString, index))
                 Console.WriteLine("The character is {0}", Uri.HexUnescape(testString, ref index));
            else
                 Console.WriteLine("The character is not hexadecimal encoded");
        //</snippet2>
                    
        }

        
        // MakeRelative
        private static void SampleMakeRelative()
        {
        //<snippet3>
            // Create a base Uri.
            Uri address1 = new Uri("http://www.contoso.com/");

            // Create a new Uri from a string.
            Uri address2 = new Uri("http://www.contoso.com/index.htm?date=today"); 
           
            // Determine the relative Uri.  
            Console.WriteLine("The difference is {0}", address1.MakeRelativeUri(address2));
        //</snippet3>
        }

        //CheckSchemeName
        private static void SampleCheckSchemeName()
        {
        //<snippet9>
            Uri address1 = new Uri("http://www.contoso.com/index.htm#search");
            Console.WriteLine("address 1 {0} a valid scheme name",
                  Uri.CheckSchemeName(address1.Scheme) ? " has" : " does not have");

            if (address1.Scheme == Uri.UriSchemeHttp)
                Console.WriteLine("Uri is HTTP type");
                  
            Console.WriteLine(address1.HostNameType);
         //</snippet9>


         //<snippet10>
            Uri address2 =  new Uri("file://server/filename.ext");
            if (address2.Scheme == Uri.UriSchemeFile) 
                Console.WriteLine("Uri is a file");
         //</snippet10>
                  
            Console.WriteLine(address2.HostNameType);
          
         //<snippet11>
            Uri address3 = new Uri("mailto:user@contoso.com?subject=uri");
            if (address3.Scheme == Uri.UriSchemeMailto) 
                Console.WriteLine("Uri is an email address");
         //</snippet11>        
           
         //<snippet12>    
            Uri address4 = new Uri("news:123456@contoso.com");
            if (address4.Scheme == Uri.UriSchemeNews)
                Console.WriteLine("Uri is an Internet news group");
         //</snippet12>
                
         //<snippet13>
            Uri address5 = new Uri("nntp://news.contoso.com/123456@contoso.com");
            if (address5.Scheme == Uri.UriSchemeNntp)
                Console.WriteLine("Uri is nntp protocol");
          //</snippet13>
            
          //<snippet14>
            Uri address6 = new Uri("gopher://example.contoso.com/");
            if (address6.Scheme == Uri.UriSchemeGopher)
                Console.WriteLine("Uri is Gopher protocol");
          //</snippet14>
                           
          //<snippet15>
            Uri address7 = new Uri("ftp://contoso/files/testfile.txt");
            if (address7.Scheme == Uri.UriSchemeFtp)
                Console.WriteLine("Uri is Ftp protocol");
          //</snippet15>
                         
          //<snippet16>
            Uri address8 = new Uri("https://example.contoso.com");
            if (address8.Scheme == Uri.UriSchemeHttps)
                Console.WriteLine("Uri is Https protocol.");
          //</snippet16>
                           
          //<snippet17>
            string address = "www.contoso.com";
            string uriString = String.Format("{0}{1}{2}/", Uri.UriSchemeHttp, Uri.SchemeDelimiter, address); 
 #if OLDMETHOD           
            Uri result;
            if (Uri.TryParse(uriString, false, false, out result) == true)
                Console.WriteLine("{0} is a valid Uri", result.ToString());
            else
                Console.WriteLine("Uri not created");
#endif
            Uri result = new Uri(uriString);
            if (result.IsWellFormedOriginalString())
                Console.WriteLine("{0} is a well formed Uri", uriString);
            else
                Console.WriteLine("{0} is not a well formed Uri", uriString);
         //</snippet17>
        }

        private static void SampleUserInfo()
        {
         //<snippet18>
            Uri uriAddress = new Uri ("http://user:password@www.contoso.com/index.htm ");
            Console.WriteLine(uriAddress.UserInfo);
            Console.WriteLine("Fully Escaped {0}", uriAddress.UserEscaped ? "yes" : "no");
        //</snippet18>
        }

        private static void UnescapeUriWithPlusConversion()
        {
         //<snippet19>
            String DataString = Uri.UnescapeDataString(".NET+Framework");
            Console.WriteLine("Unescaped string: {0}", DataString);

            String PlusString = DataString.Replace('+',' ');
            Console.WriteLine("plus to space string: {0}", PlusString);
        //</snippet19>

        }

    }
}

