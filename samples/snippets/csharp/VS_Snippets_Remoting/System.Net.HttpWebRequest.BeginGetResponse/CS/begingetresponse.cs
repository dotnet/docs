
 /** 
  * File name: Begingetresponse.cs
  * This program shows how to use BeginGetResponse and EndGetResponse methods of the 
  * HttpWebRequest class. It also shows how to create a customized timeout.
  * This is important in case od asynchronous request, because the NCL classes do 
  * not provide any off-the-shelf asynchronous timeout.
  * It uses an asynchronous approach to get the response for the HTTP Web Request.
  * The RequestState class is defined to chekc the state of the request.
  * After a HttpWebRequest object is created, its BeginGetResponse method is used to start 
  * the asynchronous response phase.
  * Finally, the EndGetResponse method is used to end the asynchronous response phase .*/

// <Snippet1>
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;


public class RequestState
{
  // This class stores the State of the request.
  const int BUFFER_SIZE = 1024;
  public StringBuilder requestData;
  public byte[] BufferRead;
  public HttpWebRequest request;
  public HttpWebResponse response;
  public Stream streamResponse;
  public RequestState()
  {
    BufferRead = new byte[BUFFER_SIZE];
    requestData = new StringBuilder("");
    request = null;
    streamResponse = null;
  }
}

class HttpWebRequest_BeginGetResponse
{
  public static ManualResetEvent allDone= new ManualResetEvent(false);
  const int BUFFER_SIZE = 1024;
  const int DefaultTimeout = 2 * 60 * 1000; // 2 minutes timeout
 
  // Abort the request if the timer fires.
  private static void TimeoutCallback(object state, bool timedOut) { 
      if (timedOut) {
          HttpWebRequest request = state as HttpWebRequest;
          if (request != null) {
              request.Abort();
          }
      }
  }

  static void Main()
  {  
   
    try
    {
      // Create a HttpWebrequest object to the desired URL. 
      HttpWebRequest myHttpWebRequest= (HttpWebRequest)WebRequest.Create("http://www.contoso.com");

    
  /**
    * If you are behind a firewall and you do not have your browser proxy setup
    * you need to use the following proxy creation code.

      // Create a proxy object.
      WebProxy myProxy = new WebProxy();

      // Associate a new Uri object to the _wProxy object, using the proxy address
      // selected by the user.
      myProxy.Address = new Uri("http://myproxy");
       
        
      // Finally, initialize the Web request object proxy property with the _wProxy
      // object.
      myHttpWebRequest.Proxy=myProxy;
    ***/

      // Create an instance of the RequestState and assign the previous myHttpWebRequest
      // object to its request field.  
      RequestState myRequestState = new RequestState();  
      myRequestState.request = myHttpWebRequest;


      // Start the asynchronous request.
      IAsyncResult result=
        (IAsyncResult) myHttpWebRequest.BeginGetResponse(new AsyncCallback(RespCallback),myRequestState);

      // this line implements the timeout, if there is a timeout, the callback fires and the request becomes aborted
      ThreadPool.RegisterWaitForSingleObject (result.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), myHttpWebRequest, DefaultTimeout, true);

      // The response came in the allowed time. The work processing will happen in the 
      // callback function.
      allDone.WaitOne();
      
      // Release the HttpWebResponse resource.
      myRequestState.response.Close();
    }
    catch(WebException e)
    {
      Console.WriteLine("\nMain Exception raised!");
      Console.WriteLine("\nMessage:{0}",e.Message);
      Console.WriteLine("\nStatus:{0}",e.Status);
      Console.WriteLine("Press any key to continue..........");
    }
    catch(Exception e)
    {
      Console.WriteLine("\nMain Exception raised!");
      Console.WriteLine("Source :{0} " , e.Source);
      Console.WriteLine("Message :{0} " , e.Message);
      Console.WriteLine("Press any key to continue..........");
      Console.Read();
    }
  }
  private static void RespCallback(IAsyncResult asynchronousResult)
  {  
    try
    {
      // State of request is asynchronous.
      RequestState myRequestState=(RequestState) asynchronousResult.AsyncState;
      HttpWebRequest  myHttpWebRequest=myRequestState.request;
      myRequestState.response = (HttpWebResponse) myHttpWebRequest.EndGetResponse(asynchronousResult);
      
      // Read the response into a Stream object.
      Stream responseStream = myRequestState.response.GetResponseStream();
      myRequestState.streamResponse=responseStream;
      
      // Begin the Reading of the contents of the HTML page and print it to the console.
      IAsyncResult asynchronousInputRead = responseStream.BeginRead(myRequestState.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
      return;
    }
    catch(WebException e)
    {
      Console.WriteLine("\nRespCallback Exception raised!");
      Console.WriteLine("\nMessage:{0}",e.Message);
      Console.WriteLine("\nStatus:{0}",e.Status);
    }
    allDone.Set();
  }
  private static  void ReadCallBack(IAsyncResult asyncResult)
  {
    try
    {

    RequestState myRequestState = (RequestState)asyncResult.AsyncState;
    Stream responseStream = myRequestState.streamResponse;
    int read = responseStream.EndRead( asyncResult );
    // Read the HTML page and then print it to the console.
    if (read > 0)
    {
      myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.BufferRead, 0, read));
      IAsyncResult asynchronousResult = responseStream.BeginRead( myRequestState.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
      return;
    }
    else
    {
      Console.WriteLine("\nThe contents of the Html page are : ");
      if(myRequestState.requestData.Length>1)
      {
        string stringContent;
        stringContent = myRequestState.requestData.ToString();
        Console.WriteLine(stringContent);
      }
      Console.WriteLine("Press any key to continue..........");
      Console.ReadLine();
      
      responseStream.Close();
    }

    }
    catch(WebException e)
    {
      Console.WriteLine("\nReadCallBack Exception raised!");
      Console.WriteLine("\nMessage:{0}",e.Message);
      Console.WriteLine("\nStatus:{0}",e.Status);
    }
    allDone.Set();

  }
// </Snippet1>

}

