// System.Net.FileWebResponse.ContentLength;System.Net.FileWebResponse.ContentType.

/* This program demonstrates the 'ContentLength' and 'ContentType' property of 'FileWebResponse' class.
It creates a web request and queries for a response.It then prints the content length
and content type of the entity body in the response onto the console */

using System;
using System.Net;

class FileWebResponseSnippet 
{
   public static void Main(string[] args) 
    {

        if (args.Length < 1) 
        {
            Console.WriteLine("\nPlease enter the file name as command line parameter:");
            Console.WriteLine("Usage:FileWebResponse_ContentLength_ContentType <systemname>/<sharedfoldername>/<filename>  \nExample:FileWebResponse_ContentLength_ContentType microsoft/shared/hello.txt");
        } 
        else 
        {    
            GetPage(args[0]);
        }
            Console.WriteLine("Press any key to continue...");Console.ReadLine();
        return;
    }
// <Snippet1>
// <Snippet2>
   public static void GetPage(String url) 
    {
      try 
        {     
            Uri fileUrl = new Uri("file://"+url);
            // Create a 'FileWebrequest' object with the specified Uri.
            FileWebRequest myFileWebRequest = (FileWebRequest)WebRequest.Create(fileUrl); 
            // Send the 'fileWebRequest' and wait for response.    
            FileWebResponse myFileWebResponse = (FileWebResponse)myFileWebRequest.GetResponse(); 
            // Print the ContentLength and ContentType properties received as headers in the response object.
            Console.WriteLine("\nContent length :{0}, Content Type : {1}",myFileWebResponse.ContentLength,myFileWebResponse.ContentType);  
            // Release resources of response object.
            myFileWebResponse.Close();
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
// </Snippet2>
}