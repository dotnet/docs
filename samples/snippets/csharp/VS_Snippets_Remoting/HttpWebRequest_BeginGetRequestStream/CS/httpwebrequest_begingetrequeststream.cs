//  <Snippet2>
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

class HttpWebRequestBeginGetRequest
{
    private static ManualResetEvent allDone = new ManualResetEvent(false);

    public static void Main(string[] args)
    {

//  <Snippet1>

        // Create a new HttpWebRequest object.
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.contoso.com/example.aspx");

        request.ContentType = "application/x-www-form-urlencoded";

        // Set the Method property to 'POST' to post data to the URI.
        request.Method = "POST";

        // start the asynchronous operation
        request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);

        // Keep the main thread from continuing while the asynchronous
        // operation completes. A real world application
        // could do something useful such as updating its user interface. 
        allDone.WaitOne();
    }

    private static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
    {
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
        
        // End the operation
        Stream postStream = request.EndGetRequestStream(asynchronousResult);

        Console.WriteLine("Please enter the input data to be posted:");
        string postData = Console.ReadLine();

        // Convert the string into a byte array.
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        // Write to the request stream.
        postStream.Write(byteArray, 0, postData.Length);
        postStream.Close();

        // Start the asynchronous operation to get the response
        request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
    }

    private static void GetResponseCallback(IAsyncResult asynchronousResult)
    {
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

        // End the operation
        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
        Stream streamResponse = response.GetResponseStream();
        StreamReader streamRead = new StreamReader(streamResponse);
        string responseString = streamRead.ReadToEnd();
        Console.WriteLine(responseString);
        // Close the stream object
        streamResponse.Close();
        streamRead.Close();

        // Release the HttpWebResponse
        response.Close();
        allDone.Set();
    }
//  </Snippet1>
}
//  </Snippet2>
