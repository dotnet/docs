// System.Net.WebClient.DownloadData; System.Net.WebClient.WebClient
/*
This program demonstrates the 'DownloadData' method and 'WebClient()' constructor of 'WebClient' class.
It creates a URI to access a web resource. The Uri can point 
to any text or binary web resource, like images etc. The 'DownloadData' method then downloads 
the required text/html homepage into a byte array. The downloaded data is displayed on the Console.
*/

using System;
using System.Net;
using System.Text;

public class WebClient_DownloadData 
{
    public static void Main() 
    {
        try 
        {
// <Snippet1>            
// <Snippet2>
            Console.Write("\nPlease enter a URI (for example, http://www.contoso.com): ");
            string remoteUri = Console.ReadLine();

            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Download home page data.
            Console.WriteLine("Downloading " + remoteUri);                        
            // Download the Web resource and save it into a data buffer.
            byte[] myDataBuffer = myWebClient.DownloadData (remoteUri);

            // Display the downloaded data.
            string download = Encoding.ASCII.GetString(myDataBuffer);
            Console.WriteLine(download);
                                
            Console.WriteLine("Download successful.");
// </Snippet1>            
// </Snippet2>

        } 
        catch (WebException e) 
        {
            Console.WriteLine ("Download failed!!! WebException : "+ e.Message );
        } 
        catch (Exception e) 
        {
            Console.WriteLine ("The following general exception was raised: "+ e.Message );
        }
    }
}

