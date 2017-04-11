// System.Net.FileWebResponse.Close

/*This program demontrates the  'Close' method of 'FileWebResponse' Class. 
It takes an Uri from console and creates a 'FileWebRequest' object for the Uri.It then gets back
the response object from the Uri. The response object can be processed as desired.The program then 
closes the response object and releases resources associated with it.*/

using System;
using System.Net;
using System.IO;
using System.Text;

class FileWebResponseSnippet 
{
   public static void Main(string[] args) 
    {
      if (args.Length < 1) 
        {
            Console.WriteLine("\nPlease enter the file name as command line parameter:");
            Console.WriteLine("Usage:FileWebResponse_Close <systemname>/<sharedfoldername>/<filename>  \nExample:FileWebResponse_Close microsoft/shared/hello.txt");
        } 
        else 
        {
            GetPage(args[0]);
        }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        return;
    }

// <Snippet1>
   public static void GetPage(String url) 
    {
        try 
        {     
            Uri fileUrl = new Uri("file://"+url);
            // Create a FileWebrequest with the specified Uri. 
            FileWebRequest myFileWebRequest = (FileWebRequest)WebRequest.Create(fileUrl); 
            // Send the 'fileWebRequest' and wait for response.
            FileWebResponse myFileWebResponse = (FileWebResponse)myFileWebRequest.GetResponse(); 
            // Process the response here.
            Console.WriteLine("\nResponse Received.Trying to Close the response stream..");
            // Release resources of response object.
            myFileWebResponse.Close();
         Console.WriteLine("\nResponse Stream successfully closed.");            
         } 
        catch(WebException e) 
         {
           Console.WriteLine("\r\nWebException thrown.The Reason for failure is : {0}",e.Status); 
       }
        catch(Exception e)
       {
           Console.WriteLine("\nThe following Exception was raised : {0}",e.Message);
        }
   }
// </Snippet1>
}