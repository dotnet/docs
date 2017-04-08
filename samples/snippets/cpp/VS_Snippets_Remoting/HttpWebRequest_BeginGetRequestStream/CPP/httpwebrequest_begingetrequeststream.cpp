/* System::Net::HttpWebRequest::BeginGetRequestStream, System::Net::HttpWebRequest::EndGetRequestStream

This program demonstrates 'BeginGetRequestStream' and 'EndGetRequestStream' methods of 'HttpWebRequest' class.
A new 'HttpWebRequest' Object is created .The 'Method' property of the 'HttpWebRequest' Object* is set to
'POST'.The 'ContentType' property is set to S"application/x-www-form-urlencoded".Then 'BeginGetRequestStream'
method of 'HttpWebRequest' class starts the Asynchronous writing to the 'HttpWebRequest' Object*. The
'EndGetRequestStream' method of 'HttpWebRequest' class ends the Asynchronous writing of data and returns a
stream Object*.The 'Stream' Object* is used to write data to the 'HttpWebRequest' Object*.

Note: This program POSTs data to the Uri: http://www20.Brinkster::com/codesnippets/next.asp
*/
//  <Snippet2>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;
using namespace System::Threading;
ref class HttpWebRequestBeginGetRequest
{
public:
   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );
   static void Main()
   {
      
      //  <Snippet1>
      // Create a new HttpWebRequest object.
      HttpWebRequest^ request = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com/example.aspx" ));
      
      // Set the ContentType property.
      request->ContentType = "application/x-www-form-urlencoded";
      
      // Set the Method property to 'POST' to post data to the Uri.
      request->Method = "POST";
      
      // Start the asynchronous operation.    
      AsyncCallback^ del = gcnew AsyncCallback(GetRequestStreamCallback);
      request->BeginGetRequestStream( del, request );
      
      // Keep the main thread from continuing while the asynchronous
      // operation completes. A real world application
      // could do something useful such as updating its user interface. 
      allDone->WaitOne();
    }
      

private:
    static void GetRequestStreamCallback(IAsyncResult^ asynchronousResult)
    {
        HttpWebRequest^ request = dynamic_cast<HttpWebRequest^>(asynchronousResult->AsyncState);
        
        // End the operation
        Stream^ postStream = request->EndGetRequestStream(asynchronousResult);

        Console::WriteLine("Please enter the input data to be posted:");
        String^ postData = Console::ReadLine();

        // Convert the string into a byte array.
        array<Byte>^ByteArray = Encoding::UTF8->GetBytes(postData);

        // Write to the request stream.
        postStream->Write(ByteArray, 0, postData->Length);
        postStream->Close();

        // Start the asynchronous operation to get the response
        AsyncCallback^ del = gcnew AsyncCallback(GetResponseCallback);
        request->BeginGetResponse(del, request);
    }

   static void GetResponseCallback(IAsyncResult^ asynchronousResult)
   {
      HttpWebRequest^ request = dynamic_cast<HttpWebRequest^>(asynchronousResult->AsyncState);

      // End the operation
      HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->EndGetResponse(asynchronousResult));
      Stream^ streamResponse = response->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader(streamResponse);
      String^ responseString = streamRead->ReadToEnd();
      Console::WriteLine(responseString);
      // Close the stream object
      streamResponse->Close();
      streamRead->Close();

      // Release the HttpWebResponse
      response->Close();
      allDone->Set();
   }
   //  </Snippet1>
};

void main()
{
   HttpWebRequestBeginGetRequest::Main();
}

//  </Snippet2>
