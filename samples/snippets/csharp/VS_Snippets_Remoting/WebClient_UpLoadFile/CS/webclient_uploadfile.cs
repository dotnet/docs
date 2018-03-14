// System.Net.WebClient.UploadFile(String,String)
/*
This program demonstrates the 'UploadFile(String,String)' method of "WebClient" class.
It accepts an Uri and the path of a file to be uploaded to the Uri. This file is uploaded to the Uri 
provided as input using the 'UploadFile(String,String)' method. The custom made site responds back 
with whatever was posted to it. Thus the contents of the file are displayed to the console.

Note : The results described were obtained using a custom made site. This behaviour may not be the
same with all other sites. Also certain sites would not accept "Post" method thereby leading to 
an error.It is advisable to construct a site using files accompanying this and provide
url name of this site to the program.
*/

using System;
using System.Net;
using System.Text;

public class WebClient_UpLoadFile 
{
    public static void Main() 
    {	
        try 
        {
// <Snippet1>
            Console.Write("\nPlease enter the URI to post data to : ");
            String uriString = Console.ReadLine();

            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();

            Console.WriteLine("\nPlease enter the fully qualified path of the file to be uploaded to the URI");
            string fileName = Console.ReadLine();
            Console.WriteLine("Uploading {0} to {1} ...",fileName,uriString);

            // Upload the file to the URI.
            // The 'UploadFile(uriString,fileName)' method implicitly uses HTTP POST method.
            byte[] responseArray = myWebClient.UploadFile(uriString,fileName);

            // Decode and display the response.
            Console.WriteLine("\nResponse Received.The contents of the file uploaded are:\n{0}", 
                System.Text.Encoding.ASCII.GetString(responseArray));
// </Snippet1>
        } 
        catch (WebException e) 
        {
            Console.WriteLine ("The following exception was raised: "+ e.Message );
        }
        catch(Exception e)
        {
            Console.WriteLine ("The following exception was raised: "+ e.Message );
        }
    }
}

