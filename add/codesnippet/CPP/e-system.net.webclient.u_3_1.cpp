// Sample call: UploadFileInBackground2("http://www.contoso.com/fileUpload.aspx", "data.txt")
void UploadFileInBackground2( String^ address, String^ fileName )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);

   client->UploadFileCompleted += 
     gcnew UploadFileCompletedEventHandler (UploadFileCallback2);
   
   // Specify a progress notification handler.
   client->UploadProgressChanged += 
       gcnew UploadProgressChangedEventHandler( UploadProgressCallback );
   client->UploadFileAsync( uri, "POST", fileName );
   Console::WriteLine( "File upload started." );
}

