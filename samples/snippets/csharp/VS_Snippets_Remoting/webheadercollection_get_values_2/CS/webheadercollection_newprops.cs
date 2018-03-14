/*
 This program demonstrate's the 'GetValues(string)' method of 
 'WebHeaderCollection' class.
 
 The program creates a 'HttpWebRequest' object from the specified URL 
 and gets the response from it. The headers of the response is 
 assigned to a 'WebHeaderCollection' object and all the values 
 associated with the corresponding headers in the response are 
 displayed to the console.
*/

using System;
using System.Net;
using System.Collections.Specialized;

public class WebHeaderCollection_GetValues_1 
{
    public static void Main(String[] args) 
    {
        try 
        {
// <Snippet1>
            if (args.Length == 0)
            {
                Console.WriteLine("must specify a URL!");
                return;
            }
            string server = args[0];

            // Create the web request 
            HttpWebRequest myHttpWebRequest = 
                (HttpWebRequest) WebRequest.Create(server);
            myHttpWebRequest.Timeout = 1000;
            // Get the associated response for the above request.
            HttpWebResponse myHttpWebResponse = 
                (HttpWebResponse) myHttpWebRequest.GetResponse();

            // Get the headers associated with the response.
            WebHeaderCollection myWebHeaderCollection = 
                myHttpWebResponse.Headers;

            for(int i = 0; i < myWebHeaderCollection.Count; i++)
            {
                String header = myWebHeaderCollection.GetKey(i);
                String[] values = 
                    myWebHeaderCollection.GetValues(header);
                if(values.Length > 0) 
                {
                    Console.WriteLine("The values of {0} header are : "
                                     , header);
                    for(int j = 0; j < values.Length; j++) 
                        Console.WriteLine("\t{0}", values[j]);
                }
                else
                    Console.WriteLine("There is no value associated" +
                        "with the header");
            }
            Console.WriteLine("");

            // Get the headers again, using new properties (Keys, 
            // AllKeys, Clear) and methods (Get and GetKey)

            string[] headers = myWebHeaderCollection.AllKeys;

            // enumerate through the header collection.
            foreach (string s in headers)
            {
                Console.WriteLine("Header {0}, value {1}",
                    s,
                    myWebHeaderCollection.Get(s) );
            }

            Console.WriteLine("");

            // show the use of Get(Int32) and GetValue(Int32)
            if (myWebHeaderCollection.Count > 0)
            {
                // get the name and value of the first header
                int index=0;
                Console.WriteLine("Header {0}: name {1}, value {2}",
                    index, 
                    myWebHeaderCollection.GetKey(index),
                    myWebHeaderCollection.Get(index));
            }

            myWebHeaderCollection.Clear();

            myHttpWebResponse.Close();
// </Snippet1>
        }
        catch(WebException e) {
            Console.WriteLine("\nWebException raised : {0}", e.Message);
            if(e.Status == WebExceptionStatus.ProtocolError) {
                Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                Console.WriteLine("Server : {0}", ((HttpWebResponse)e.Response).Server);
            }
        }
        catch(ArgumentOutOfRangeException e) {
            Console.WriteLine("\nArgumentOutOfRangeException raised : {0}", e.Message);
        }
        catch(Exception e) {
            Console.WriteLine("\n Exception raised : {0}", e.Message);
        }
    }
};
