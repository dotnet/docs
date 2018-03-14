/* System.Net.WebRequest.BeginGetRequestStream System.Net.WebRequest.EndGetRequestStream System.Net.WebRequest.Method
  This program demonstrates 'BeginGetRequestStream','EndGetRequestStream' methods and 'Method' property of 
    'WebRequest' class. 
   A new 'WebRequest' object is created .The method property of the 'WebRequest' object is set to POST. An 
   asynchronous request for writing data is started  using the 'BeginGetRequestStream' method of 'WebRequest'
   class.A 'Stream' object is obtained using the 'EndGetRequestStream' method in the callback function. The 
   stream object is  used to write the requested data to the mentioned uri. After data writing is over the 
   same data is read from the same Uri and printed on the console. 

   Note: This program POSTs data to the Uri: http://www20.Brinkster.com/codesnippets/next.asp 
*/
// <Snippet3>
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

public class RequestState
{
    // This class stores the request state of the request.
    public WebRequest request;    
    public RequestState()
    {
        request = null;
    }
}

class WebRequest_BeginGetRequeststream
{
    public static ManualResetEvent allDone= new ManualResetEvent(false);
    static void Main()
    {
    //<Snippet1>
            // Create a new request to the mentioned URL.    
            WebRequest myWebRequest= WebRequest.Create("http://www.contoso.com");

            // Create an instance of the RequestState and assign 
            // 'myWebRequest' to it's request field.    
            RequestState myRequestState = new RequestState();
            myRequestState.request = myWebRequest;            
            myWebRequest.ContentType="application/x-www-form-urlencoded";

            // Set the 'Method' property  to 'POST' to post data to a Uri.
            myRequestState.request.Method="POST";
     //</Snippet1>
            // Start the Asynchronous 'BeginGetRequestStream' method call.    
            IAsyncResult r=(IAsyncResult) myWebRequest.BeginGetRequestStream(
                new AsyncCallback(ReadCallback),myRequestState);
            // Pause the current thread until the async operation completes.
            Console.WriteLine("main thread waiting...");
            allDone.WaitOne();   
            // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            WebResponse myWebResponse = myWebRequest.GetResponse();
            Console.WriteLine("The string has been posted.");    
            Console.WriteLine("Please wait for the response...");

            Stream streamResponse = myWebResponse.GetResponseStream();
            StreamReader streamRead = new StreamReader( streamResponse );
            Char[] readBuff = new Char[256];
            int count = streamRead.Read( readBuff, 0, 256 );
            Console.WriteLine("\nThe contents of the HTML page are ");    

            while (count > 0) 
            {
                String outputData = new String(readBuff, 0, count);
                Console.Write(outputData);
                count = streamRead.Read(readBuff, 0, 256);
            }

            // Close the Stream Object.
            streamResponse.Close();
            streamRead.Close();
 

            // Release the HttpWebResponse Resource.
            myWebResponse.Close();            
    }
    private static void ReadCallback(IAsyncResult asynchronousResult)
    {
            RequestState myRequestState =(RequestState) asynchronousResult.AsyncState;
            WebRequest  myWebRequest = myRequestState.request;

            // End the Asynchronus request.
            Stream streamResponse = myWebRequest.EndGetRequestStream(asynchronousResult);

            // Create a string that is to be posted to the uri.
            Console.WriteLine("Please enter a string to be posted:");
            string postData = Console.ReadLine();
            // Convert the string into a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Write the data to the stream.
            streamResponse.Write(byteArray,0,postData.Length);
            streamResponse.Close();
            allDone.Set();
    }
}
// </Snippet3>
