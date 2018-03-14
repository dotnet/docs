// System.Net.FileWebResponse.GetResponseStream.

/* This program demonstrates the 'GetResponseStream' method of the 'FileWebResponse' class.
   It creates a 'FileWebRequest' object and queries for a response.
   The response stream obtained is piped to a higher level stream reader. The reader reads 
   256 characters at a time , writes them into a string and then displays the string onto the console*/

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
               Console.WriteLine("Usage:FileWebResponse_GetResponseStream <systemname>/<sharedfoldername>/<filename>  \nExample:FileWebResponse_GetResponseStream microsoft/shared/hello.txt");
           } 
           else 
           {
               GetPage(args[0]);
           }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        return;
    }
   public static void GetPage(String url) 
    {
        try 
         {     
// <Snippet1>
            Uri fileUrl = new Uri("file://"+url);
            // Create a 'FileWebrequest' object with the specified Uri. 
            FileWebRequest myFileWebRequest = (FileWebRequest)WebRequest.Create(fileUrl);
            // Send the 'FileWebRequest' object and wait for response. 
            FileWebResponse myFileWebResponse = (FileWebResponse)myFileWebRequest.GetResponse();
                        
            // Get the stream object associated with the response object.
            Stream receiveStream = myFileWebResponse.GetResponseStream();
            
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            // Pipe the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader( receiveStream, encode );
            Console.WriteLine("\r\nResponse stream received");
    
            Char[] read = new Char[256];
            // Read 256 characters at a time.    
            int count = readStream.Read( read, 0, 256 );
            Console.WriteLine("File Data...\r\n");
            while (count > 0) 
            {
                // Dump the 256 characters on a string and display the string onto the console.
                String str = new String(read, 0, count);
                Console.Write(str);
                count = readStream.Read(read, 0, 256);
            }
            Console.WriteLine("");
            // Release resources of stream object.
            readStream.Close();
            // Release resources of response object.
            myFileWebResponse.Close();
// </Snippet1>             
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
}