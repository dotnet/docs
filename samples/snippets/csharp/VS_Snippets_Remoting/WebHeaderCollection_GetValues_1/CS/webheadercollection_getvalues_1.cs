/* 
 This program demonstrate's the 'GetValues(string)' method of 'WebHeaderCollection' class.
 
 The program creates a 'HttpWebRequest' object from the specified URL and gets the response from it. The 
 headers of the response is assigned to a 'WeHeaderCollection' object and all the values associated with
 the corresponding headers in the response are displayed to the console.
*/

using System;
using System.Net;

public class WebHeaderCollection_GetValues_1 {

    public static void Main() {
        try {
// <Snippet1>
            // Create a web request for "www.msn.com".
             HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create("http://www.msn.com");
            myHttpWebRequest.Timeout = 1000;
            // Get the associated response for the above request.
             HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();

            // Get the headers associated with the response.
            WebHeaderCollection myWebHeaderCollection = myHttpWebResponse.Headers;

            for(int i = 0; i < myWebHeaderCollection.Count; i++) {
                String header = myWebHeaderCollection.GetKey(i);
                String[] values = myWebHeaderCollection.GetValues(header);
                if(values.Length > 0) {
                    Console.WriteLine("The values of {0} header are : ", header);
                    for(int j = 0; j < values.Length; j++) 
                        Console.WriteLine("\t{0}", values[j]);
                }
                else
                    Console.WriteLine("There is no value associated with the header");
            }
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
        catch(Exception e) {
            Console.WriteLine("\n Exception raised : {0}", e.Message);
        }
    }
};
