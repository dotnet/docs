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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(args[0]);
            request.CookieContainer = new CookieContainer();
        
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            
            

            // Print the properties of each cookie.
            foreach (Cookie cook in response.Cookies)
            {
                Console.WriteLine("Cookie:");
                Console.WriteLine("{0} = {1}", cook.Name, cook.Value);
                Console.WriteLine("Domain: {0}", cook.Domain);
                Console.WriteLine("Path: {0}", cook.Path);
                Console.WriteLine("Port: {0}", cook.Port);
                Console.WriteLine("Secure: {0}", cook.Secure);
             
                Console.WriteLine("When issued: {0}", cook.TimeStamp);
                Console.WriteLine("Expires: {0} (expired? {1})", 
                    cook.Expires, cook.Expired);
                Console.WriteLine("Don't save: {0}", cook.Discard);    
                Console.WriteLine("Comment: {0}", cook.Comment);
                Console.WriteLine("Uri for comments: {0}", cook.CommentUri);
                Console.WriteLine("Version: RFC {0}" , cook.Version == 1 ? "2109" : "2965");

                //<Snippet4>
                // Show the string representation of the cookie.
                Console.WriteLine ("String: {0}", cook.ToString());
                // </Snippet4>
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