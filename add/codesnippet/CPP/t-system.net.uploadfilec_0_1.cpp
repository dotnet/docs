// Sample call: UploadFileInBackground("http://www.contoso.com/fileUpload.aspx", "data.txt")
void UploadFileInBackground( String^ address, String^ fileName )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ method = "POST";
   
   // Specify that that UploadFileCallback method gets called
   // when the file upload completes.
   client->UploadFileCompleted += gcnew UploadFileCompletedEventHandler( UploadFileCallback );
   client->UploadFileAsync( uri, method, fileName, waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the upload to complete.
   waiter->WaitOne();
   Console::WriteLine( "File upload is complete." );
}

