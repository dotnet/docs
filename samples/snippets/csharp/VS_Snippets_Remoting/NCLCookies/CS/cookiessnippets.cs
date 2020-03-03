// <Snippet1>
using System.Net;
using System;
namespace Examples.System.Net.Cookies
{
    // This example is run at the command line.
    // Specify one argument: the name of the host to 
    // send the request to.
    // If the request is sucessful, the example displays the contents of the cookies
    // returned by the host.
    
    public class CookieExample
    {   
        // <Snippet2>
        public static void Main(string[] args)
        {   
            if (args == null || args.Length != 1)
            {
                Console.WriteLine("Specify the URL to receive the request.");
                Environment.Exit(1);
            }
            // <Snippet3>
            var request = (HttpWebRequest)WebRequest.Create(args[0]);
            request.CookieContainer = new CookieContainer();
        
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                // Print the properties of each cookie.
                foreach (Cookie cook in response.Cookies)
                {
                    Console.WriteLine("Cookie:");
                    Console.WriteLine($"{cook.Name} = {cook.Value}");
                    Console.WriteLine($"Domain: {cook.Domain}");
                    Console.WriteLine($"Path: {cook.Path}");
                    Console.WriteLine($"Port: {cook.Port}");
                    Console.WriteLine($"Secure: {cook.Secure}");
                 
                    Console.WriteLine($"When issued: {cook.TimeStamp}");
                    Console.WriteLine($"Expires: {cook.Expires} (expired? {cook.Expired})");
                    Console.WriteLine($"Don't save: {cook.Discard}");
                    Console.WriteLine($"Comment: {cook.Comment}");
                    Console.WriteLine($"Uri for comments: {cook.CommentUri}");
                    Console.WriteLine($"Version: RFC {(cook.Version == 1 ? 2109 : 2965)}");
    
                    //<Snippet4>
                    // Show the string representation of the cookie.
                    Console.WriteLine($"String: {cook}");
                    // </Snippet4>
                }
            }
            // </Snippet3>
        }
        // </Snippet2>
    }
}

// Output from this example will be vary depending on the host name specified,
// but will be similar to the following.
/*
Cookie:
CustomerID = 13xyz
Domain: .contoso.com
Path: /
Port:
Secure: False
When issued: 1/14/2003 3:20:57 PM
Expires: 1/17/2013 11:14:07 AM (expired? False)
Don't save: False
Comment: 
Uri for comments:
Version: RFC 2965
String: CustomerID = 13xyz
*/

// </Snippet1>
