// System.Net.WebRequest.BeginGetResponse  System.Net.WebRequest.EndGetResponse 
  /* 
   * This program demonstrates BeginGetResponse and EndGetResponse methods of 
   * WebRequest Class.A new WebRequest object is created to the mentioned Uri.
   * An Asynchronous call is started for response from the Uri using BeginGetResponse 
   * method of WebRequest class. 
   * The asynchronous response is ended by the EndGetResponse method of the 
   * WebRequest class. The page at the requested Uri is finally displayed.
*/
// <Snippet1>
// <Snippet2>

using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;



public class RequestState
{
  // This class stores the state of the request.
  const int BUFFER_SIZE = 1024;
  public StringBuilder requestData;
  public byte[] bufferRead;
  public WebRequest request;
  public WebResponse response;
  public Stream responseStream;
  public RequestState()
  {
    bufferRead = new byte[BUFFER_SIZE];
    requestData = new StringBuilder("");
    request = null;
    responseStream = null;
  }
}
class WebRequest_BeginGetResponse
{
  public static ManualResetEvent allDone= new ManualResetEvent(false);
  const int BUFFER_SIZE = 1024;
  static void Main()
  {
    try
    {
      // Create a new webrequest to the mentioned URL.   
      WebRequest myWebRequest= WebRequest.Create("http://www.contoso.com");
      
      // Please, set the proxy to a correct value. 
      WebProxy proxy=new WebProxy("myproxy:80");

      proxy.Credentials=new NetworkCredential("srikun","simrin123");
      myWebRequest.Proxy=proxy;
      // Create a new instance of the RequestState.
      RequestState myRequestState = new RequestState();
      // The 'WebRequest' object is associated to the 'RequestState' object.
      myRequestState.request = myWebRequest;
      // Start the Asynchronous call for response.
      IAsyncResult asyncResult=(IAsyncResult) myWebRequest.BeginGetResponse(new AsyncCallback(RespCallback),myRequestState);
      allDone.WaitOne();
      // Release the WebResponse resource.
      myRequestState.response.Close();
      Console.Read();
    }
    catch(WebException e)
    {
      Console.WriteLine("WebException raised!");
      Console.WriteLine("\n{0}",e.Message);
      Console.WriteLine("\n{0}",e.Status);
    } 
    catch(Exception e)
    {
      Console.WriteLine("Exception raised!");
      Console.WriteLine("Source : " + e.Source);
      Console.WriteLine("Message : " + e.Message);
    }
  }
  private static void RespCallback(IAsyncResult asynchronousResult)
  {  
    try
    {
      // Set the State of request to asynchronous.
      RequestState myRequestState=(RequestState) asynchronousResult.AsyncState;
      WebRequest  myWebRequest1=myRequestState.request;
      // End the Asynchronous response.
      myRequestState.response =  myWebRequest1.EndGetResponse(asynchronousResult);
      // Read the response into a 'Stream' object.
      Stream responseStream = myRequestState.response.GetResponseStream();
      myRequestState.responseStream=responseStream;
      // Begin the reading of the contents of the HTML page and print it to the console.
      IAsyncResult asynchronousResultRead = responseStream.BeginRead(myRequestState.bufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
    
    }
    catch(WebException e)
    {
      Console.WriteLine("WebException raised!");
      Console.WriteLine("\n{0}",e.Message);
      Console.WriteLine("\n{0}",e.Status);
    } 
    catch(Exception e)
    {
      Console.WriteLine("Exception raised!");
      Console.WriteLine("Source : " + e.Source);
      Console.WriteLine("Message : " + e.Message);
    }
  }
  private static  void ReadCallBack(IAsyncResult asyncResult)
  {
    try
    {
      // Result state is set to AsyncState.
      RequestState myRequestState = (RequestState)asyncResult.AsyncState;
      Stream responseStream = myRequestState.responseStream;
      int read = responseStream.EndRead( asyncResult );
      // Read the contents of the HTML page and then print to the console.
      if (read > 0)
      {
        myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.bufferRead, 0, read));
        IAsyncResult asynchronousResult = responseStream.BeginRead( myRequestState.bufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
      }
      else
      {
        Console.WriteLine("\nThe HTML page Contents are:  ");
        if(myRequestState.requestData.Length>1)
        {
          string sringContent;
          sringContent = myRequestState.requestData.ToString();
          Console.WriteLine(sringContent);
        }
        Console.WriteLine("\nPress 'Enter' key to continue........");
        responseStream.Close();
        allDone.Set();
      }
    }
    catch(WebException e)
    {
      Console.WriteLine("WebException raised!");
      Console.WriteLine("\n{0}",e.Message);
      Console.WriteLine("\n{0}",e.Status);
    } 
    catch(Exception e)
    {
      Console.WriteLine("Exception raised!");
      Console.WriteLine("Source : {0}" , e.Source);
      Console.WriteLine("Message : {0}" , e.Message);
    }

  }

}
// </Snippet2>
// </Snippet1>
