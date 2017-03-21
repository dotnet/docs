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