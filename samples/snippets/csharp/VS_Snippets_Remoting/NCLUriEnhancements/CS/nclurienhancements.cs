using System;
using System.Net;
using System.Text;
using System.Threading;

namespace Example
{
    public class Test
    {
        public static void Main()
        {
            // TryCreate
            SampleTryCreate();

            // Constructor
            SampleConstructor();

            // OriginalString
            SampleOriginalString();

            // DNSSafeHost
            SampleDNSSafeHost();

            // operator == and !==
            SampleOperatorEqual();

            // IsBaseOf
            SampleIsBaseOf();
        }
     
        // TryCreate
        private static void SampleTryCreate()
        {
            //<snippet1>
            // String to create.
            string addressString = "catalog/shownew.htm?date=today";
            // Parse the string and create a new Uri instance, if possible.
            Uri result = null;
            if (Uri.TryCreate(addressString, UriKind.RelativeOrAbsolute, out result) == true) {
                // The call was successful. Write the URI address to the console.
                Console.Write(result.ToString());
                // Check whether new Uri instance is absolute or relative.
                if (result.IsAbsoluteUri) {
                    Console.WriteLine(" is an absolute Uri.");
                }
                else {
                    Console.WriteLine(" is a relative Uri.");
                }
            }
            else {
            // Let the user know that the call failed.
                Console.WriteLine("addressString could not be parsed as a URI "
                    + "address.");
            }
            //</snippet1>    
        } //SampleTryCreate


        // Constructor
        private static void SampleConstructor()
        {
            //<snippet2>
            // Create an absolute Uri from a string.
            Uri absoluteUri = new Uri("http://www.contoso.com/");

            // Create a relative Uri from a string.  allowRelative = true to allow for 
            // creating a relative Uri.
            Uri relativeUri = new Uri("/catalog/shownew.htm?date=today", UriKind.Relative);
         
            // Check whether the new Uri is absolute or relative.
            if (!relativeUri.IsAbsoluteUri)
                Console.WriteLine("{0} is a relative Uri.", relativeUri);

            // Create a new Uri from an absolute Uri and a relative Uri.
            Uri combinedUri = new Uri(absoluteUri, relativeUri);
            Console.WriteLine(combinedUri.AbsoluteUri);
            //</snippet2>
        }

        // OriginalString
        private static void SampleOriginalString()
        {
            //<snippet3>
            // Create a new Uri from a string address.
            Uri uriAddress = new Uri("HTTP://www.ConToso.com:80//thick%20and%20thin.htm");

            // Write the new Uri to the console and note the difference in the two values.
            // ToString() gives the canonical version.  OriginalString gives the orginal 
            // string that was passed to the constructor.

            // The following outputs "http://www.contoso.com/thick and thin.htm".
            Console.WriteLine(uriAddress.ToString()); 

            // The following outputs "HTTP://www.ConToso.com:80//thick%20and%20thin.htm".
            Console.WriteLine(uriAddress.OriginalString);
            //</snippet3>
        }

        // DNSSafeHost
        private static void SampleDNSSafeHost()
        {
            //<snippet4>
            // Create new Uri using a string address.         
            Uri address = new Uri("http://[fe80::200:39ff:fe36:1a2d%4]/temp/example.htm");

            // Make the address DNS safe. 

            // The following outputs "[fe80::200:39ff:fe36:1a2d]".
            Console.WriteLine(address.Host);

            // The following outputs "fe80::200:39ff:fe36:1a2d%4".
            Console.WriteLine(address.DnsSafeHost);
            //</snippet4>
        }


        // operator == and !==
        private static void SampleOperatorEqual()
        {
            //<snippet5>
            // Create some Uris.
            Uri address1 = new Uri("http://www.contoso.com/index.htm#search");
            Uri address2 = new Uri("http://www.contoso.com/index.htm"); 
            Uri address3 = new Uri("http://www.contoso.com/index.htm?date=today"); 

            // The first two are equal because the fragment is ignored.
            if (address1 == address2)
                Console.WriteLine("{0} is equal to {1}", address1.ToString(), address2.ToString());

            // The second two are not equal.
            if (address2 != address3)
                Console.WriteLine("{0} is not equal to {1}", address2.ToString(), address3.ToString());
            //</snippet5>
        }

        // IsBaseOf
        private static void SampleIsBaseOf()
        {
            //<snippet6>
            // Create a base Uri.
            Uri baseUri = new Uri("http://www.contoso.com/");

            // Create a new Uri from a string.
            Uri uriAddress = new Uri("http://www.contoso.com/index.htm?date=today"); 

            // Determine whether BaseUri is a base of UriAddress.  
            if (baseUri.IsBaseOf(uriAddress))
                Console.WriteLine("{0} is the base of {1}", baseUri, uriAddress);
            //</snippet6>
        }
    }
}
