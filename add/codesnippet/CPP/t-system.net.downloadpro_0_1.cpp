// Sample call : DownLoadFileInBackground2 ("http://www.contoso.com/logs/January.txt");
void DownLoadFileInBackground2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadFileCallback method gets called
   // when the download completes.
   client->DownloadFileCompleted += gcnew AsyncCompletedEventHandler( DownloadFileCallback2 );
   
   // Specify a progress notification handler.
   client->DownloadProgressChanged += gcnew DownloadProgressChangedEventHandler( DownloadProgressCallback );
   client->DownloadFileAsync( uri, "serverdata.txt" );
}

