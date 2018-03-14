/* System.Net.HttpWebRequest.Accept
This program demonstrates 'Accept' property of the 'HttpWebRequest' class.
A new 'HttpWebRequest' object is created.The 'Accept' property of 'HttpWebRequest'
class is set to 'image/*' that in turn sets the 'Accept' field of HTTP Request Headers to 
 "image/*". HTTP Request  and Response headers are displayed to the console.
 The contents of the page of the requested URI are displayed to the console.
 'Accept' property is set with an aim to receive the response in a specific format.

Note:This program requires http://localhost/CodeSnippetTest.html as Command line parameter.
    If the requested page contains any content other than 'image/*' an error of 'status (406) Not Acceptable'
     is returned.The functionality of 'Accept' property is supported only by servers that use HTTP 1.1 
     protocol.Please refer to RFC 2616 for further information on HTTP Headers.
*/

using System;
using System.IO;
using System.Net;

class HttpWebRequest_Accept
{
   static void Main(string[] args)
   {
      try   
      { 
         if(args.Length<1)
         {
            Console.WriteLine("\nPlease enter the Uri address as a command line parameter");
            Console.WriteLine("Usage:HttpWebRequest_Accept http://www.microsoft.com/library/homepage/images/ms-banner.gif");
         }
         else
         {
            GetPage(args[0]);
         }
      }
      catch(WebException e)
      {
         Console.WriteLine("\nWebException Caught!");
         Console.WriteLine("Message :{0}",e.Message);
      }
      catch(Exception e)
      {
         Console.WriteLine("\nException Caught!");
         Console.WriteLine("Message :{0}" , e.Message);
      }

   }
   public static void GetPage(String myUri)
   {
      try
      {
// <Snippet1>
         // Create a 'HttpWebRequest' object.
         HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create(myUri);
         // Set the 'Accept' property to accept an image of any type.
         myHttpWebRequest.Accept="image/*";
         // The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
         HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
// </Snippet1>
         Console.WriteLine("\nHTTP Request  Headers :\n\n{0}",myHttpWebRequest.Headers);
         Console.WriteLine("\nHTTP Response Headers :\n\n{0}",myHttpWebResponse.Headers);
         Console.WriteLine("Press 'Enter' Key to Continue.......");
         Console.Read();
         // Displaying the contents of the page to the console
         Stream streamResponse=myHttpWebResponse.GetResponseStream();
         StreamReader streamRead = new StreamReader( streamResponse );
         Char[] readBuffer = new Char[256];
         int count = streamRead.Read( readBuffer, 0, 256 );
         Console.WriteLine("\nThe contents of HTML page are.......");
         while (count > 0) 
         {
            String outputData = new String(readBuffer, 0, count);
            Console.Write(outputData);
            count = streamRead.Read(readBuffer, 0, 256);
         }
         // Release the response object resources.
         Console.WriteLine("\nPress 'Enter' Key to Continue......");
         Console.Read();
         streamRead.Close();
         streamResponse.Close();
         myHttpWebResponse.Close();
      }
      catch(WebException e)
      {
         Console.WriteLine("\nWebException Caught!");
         Console.WriteLine("Message : {0}",e.Message);
      }
      catch(Exception e)
      {
         Console.WriteLine("\nException Caught!");
         Console.WriteLine("Message :{0} " , e.Message);
      }
   }
}
   