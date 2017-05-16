

//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Threading;
using namespace System::IO;

//<snippet2>
public ref class FtpState
{
private:
   ManualResetEvent^ wait;
   FtpWebRequest^ request;
   String^ fileName;
   Exception^ operationException;
   String^ status;

public:
   FtpState()
   {
      wait = gcnew ManualResetEvent( false );
   }

   property ManualResetEvent^ OperationComplete 
   {
      ManualResetEvent^ get()
      {
         return wait;
      }

   }

   property FtpWebRequest^ Request 
   {
      FtpWebRequest^ get()
      {
         return request;
      }

      void set( FtpWebRequest^ value )
      {
         request = value;
      }

   }

   property String^ FileName 
   {
      String^ get()
      {
         return fileName;
      }

      void set( String^ value )
      {
         fileName = value;
      }

   }

   property Exception^ OperationException 
   {
      Exception^ get()
      {
         return operationException;
      }

      void set( Exception^ value )
      {
         operationException = value;
      }

   }

   property String^ StatusDescription 
   {
      String^ get()
      {
         return status;
      }

      void set( String^ value )
      {
         status = value;
      }

   }
};
//</snippet2>

//<snippet3>
public ref class AsynchronousFtpUpLoader
{
public:

   //<snippet4>    
   // Command line arguments are two strings:
   // 1. The url that is the name of the file being uploaded to the server.
   // 2. The name of the file on the local machine.
   //
   static void Main()
   {
      array<String^>^args = Environment::GetCommandLineArgs();

      // Create a Uri instance with the specified URI string.
      // If the URI is not correctly formed, the Uri constructor
      // will throw an exception.
      ManualResetEvent^ waitObject;
      Uri^ target = gcnew Uri( args[ 1 ] );
      String^ fileName = args[ 2 ];
      FtpState^ state = gcnew FtpState;
      FtpWebRequest ^ request = dynamic_cast<FtpWebRequest^>(WebRequest::Create( target ));
      request->Method = WebRequestMethods::Ftp::UploadFile;

      // This example uses anonymous logon.
      // The request is anonymous by default; the credential does not have to be specified. 
      // The example specifies the credential only to
      // control how actions are logged on the server.
      request->Credentials = gcnew NetworkCredential( "anonymous","janeDoe@contoso.com" );

      // Store the request in the object that we pass into the
      // asynchronous operations.
      state->Request = request;
      state->FileName = fileName;

      // Get the event to wait on.
      waitObject = state->OperationComplete;

      // Asynchronously get the stream for the file contents.
      request->BeginGetRequestStream( gcnew AsyncCallback( EndGetStreamCallback ), state );

      // Block the current thread until all operations are complete.
      waitObject->WaitOne();

      // The operations either completed or threw an exception.
      if ( state->OperationException != nullptr )
      {
         throw state->OperationException;
      }
      else
      {
         Console::WriteLine( "The operation completed - {0}", state->StatusDescription );
      }
   }
   //</snippet4>  

   //<snippet5> 
private:
   static void EndGetStreamCallback( IAsyncResult^ ar )
   {
      FtpState^ state = dynamic_cast<FtpState^>(ar->AsyncState);
      Stream^ requestStream = nullptr;

      // End the asynchronous call to get the request stream.
      try
      {
         requestStream = state->Request->EndGetRequestStream( ar );

         // Copy the file contents to the request stream.
         const int bufferLength = 2048;
         array<Byte>^buffer = gcnew array<Byte>(bufferLength);
         int count = 0;
         int readBytes = 0;
         FileStream^ stream = File::OpenRead( state->FileName );
         do
         {
            readBytes = stream->Read( buffer, 0, bufferLength );
            requestStream->Write( buffer, 0, bufferLength );
            count += readBytes;
         }
         while ( readBytes != 0 );
         Console::WriteLine( "Writing {0} bytes to the stream.", count );

         // IMPORTANT: Close the request stream before sending the request.
         requestStream->Close();

         // Asynchronously get the response to the upload request.
         state->Request->BeginGetResponse( gcnew AsyncCallback( EndGetResponseCallback ), state );
      }
      // Return exceptions to the main application thread.
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Could not get the request stream." );
         state->OperationException = e;
         state->OperationComplete->Set();
         return;
      }
   }
   //</snippet5> 

   //<snippet6> 
   // The EndGetResponseCallback method  
   // completes a call to BeginGetResponse.
   static void EndGetResponseCallback( IAsyncResult^ ar )
   {
      FtpState^ state = dynamic_cast<FtpState^>(ar->AsyncState);
      FtpWebResponse ^ response = nullptr;
      try
      {
         response = dynamic_cast<FtpWebResponse^>(state->Request->EndGetResponse( ar ));
         response->Close();
         state->StatusDescription = response->StatusDescription;

         // Signal the main application thread that 
         // the operation is complete.
         state->OperationComplete->Set();
      }
      // Return exceptions to the main application thread.
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Error getting response." );
         state->OperationException = e;
         state->OperationComplete->Set();
      }
   }
   //</snippet6> 
};
//</snippet3>

int main()
{
   AsynchronousFtpUpLoader::Main();
}
//</snippet1>
