/*  
   System.Net.HttpWebRequest.SendChunked  
   System.Net.HttpWebRequest.TransferEncoding
   This program demonstrates 'TransferEncoding' and 'SendChunked' properties of 'HttpWebRequestClass'.
   A new 'HttpWebRequest' object is created.The 'SendChunked' property value is set to 'true' and 
  'TransferEncoding' property is set to "gzip".If 'TransferEncoding' property is set with 'SendChunked' 
   property set to 'false' then 'InvalidOperationException' is raised. Data to be posted to the Uri is
   requested from the user.The HTML contents of the page are displayed to the console after the posted 
   data is accepted by the URL

Note:This program requires http://localhost/CodeSnippetTest.asp as Command line parameter.
    If the 'TransferEncoding' of type 'gzip' is not implemented by the server an error of status
     '(501) Not implemented' is returned.
*/


 
using System;
using System.IO;
using System.Net;
using System.Text;


class HttpWebRequest_SendChunked
{
   public static void Main(string[] args)
   {
      try   
      {
         if(args.Length<1)
         {
            Console.WriteLine("\nPlease enter the Uri address as a command line parameter:");
            Console.WriteLine("[ Usage:HttpWebRequest_Sendchunked http://<MachineName>/CodeSnippetTest.asp ]");
         }
         else
         {
            GetPage(args[0]); 
         }

      }
      catch(WebException e)
      {
         Console.WriteLine("\nWebException Caught!");
         Console.WriteLine("Source  :{0}",e.Source);
         Console.WriteLine("Message :{0}",e.Message);
      }
      catch(Exception e)
      {
         Console.WriteLine("\nException Caught!");
         Console.WriteLine("Source  :{0}",e.Source);
         Console.WriteLine("Message :{0}",e.Message); 
      }        

   }
   public static void GetPage(String myUri)
   {
      try
      {
// <Snippet1>
// <Snippet2>
         // A new 'HttpWebRequest' object is created.
         HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create(myUri);
         myHttpWebRequest.SendChunked=true;
         // 'TransferEncoding' property is set to 'gzip'.
         myHttpWebRequest.TransferEncoding="gzip";
         Console.WriteLine("\nPlease Enter the data to be posted to the (http://<machine name>/CodeSnippetTest.asp) uri:");
         string inputData =Console.ReadLine();
         string postData="testdata="+inputData;
         // 'Method' property of 'HttpWebRequest' class is set to POST.
         myHttpWebRequest.Method="POST";
         ASCIIEncoding encodedData=new ASCIIEncoding();
         byte[]  byteArray=encodedData.GetBytes(postData);
         // 'ContentType' property of the 'HttpWebRequest' class is set to "application/x-www-form-urlencoded".
         myHttpWebRequest.ContentType="application/x-www-form-urlencoded";
         // 'ContentLength' property is set to Length of the data to be posted.
         myHttpWebRequest.ContentLength=byteArray.Length;
         Stream newStream=myHttpWebRequest.GetRequestStream();
         newStream.Write(byteArray,0,byteArray.Length);
         newStream.Close();
         Console.WriteLine("\nData has been posted to the Uri\n\nPlease wait for the response..........");
         // The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
         HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
         // Displaying the contents of the page to the console
         Stream streamResponse=myHttpWebResponse.GetResponseStream();
         StreamReader streamRead = new StreamReader( streamResponse );
         Char[] readBuff = new Char[256];
         int count = streamRead.Read( readBuff, 0, 256 );
         Console.WriteLine("\nThe contents of the HTML page are :  ");
         while (count > 0) 
         {
            String outputData = new String(readBuff, 0, count);
            Console.WriteLine(outputData);
            count = streamRead.Read(readBuff, 0, 256);
         }
         // Release the response object resources.
         streamRead.Close();
         streamResponse.Close();
         myHttpWebResponse.Close(); 
// </Snippet2>
// </Snippet1>
         Console.WriteLine("\nPress 'Enter' Key to Continue.................");
         Console.Read();
      }
      catch(WebException e)
      {
         Console.WriteLine("\nWebException Caught!");
         Console.WriteLine("Source  :{0}",e.Source);
         Console.WriteLine("Message :{0}",e.Message);
      }
      catch(Exception e)
      {
         Console.WriteLine("\nException Caught!");
         Console.WriteLine("Source  :{0}",e.Source);
         Console.WriteLine("Message :{0}",e.Message); 
      }
   }
}
