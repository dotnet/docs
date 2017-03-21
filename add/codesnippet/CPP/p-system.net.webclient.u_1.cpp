// Sample call: UploadFileInBackground3("http://www.contoso.com/fileUpload.aspx", "data.txt")
void UploadFileInBackground3( String^ address, String^ fileName )
{
   
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);

   client->UseDefaultCredentials = true;
   
   client->UploadFileCompleted += gcnew UploadFileCompletedEventHandler( UploadFileCallback2 );
   client->UploadFileAsync( uri, fileName );
   Console::WriteLine( "File upload started." );
}
