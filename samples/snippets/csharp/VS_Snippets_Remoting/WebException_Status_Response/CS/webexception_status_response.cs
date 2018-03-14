/* This program demonstrates the "Status" and the "Response" property of "WebException" class.
   It tries to access an invalid site and displays the status code and status description of the 
   resultant  exception that is raised.
*/

using System;
using System.Net;

public class WebException_Status_Response {

    public static void Main() {
// <Snippet1>
// <Snippet2>
        try {
           // Create a web request for an invalid site. Substitute the "invalid site" strong in the Create call with a invalid name.
             HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create("invalid site");

            // Get the associated response for the above request.
             HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();
            myHttpWebResponse.Close();
        }
        catch(WebException e) {
            Console.WriteLine("This program is expected to throw WebException on successful run."+
                                "\n\nException Message :" + e.Message);
            if(e.Status == WebExceptionStatus.ProtocolError) {
                Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
            }
// </Snippet2>
        }
        catch(Exception e) {
            Console.WriteLine(e.Message);
        }
// </Snippet1>
    }
};
