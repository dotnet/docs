// Sample call : DownloadStringInBackground2 ("http://www.contoso.com/GameScores.html");
void DownloadStringInBackground2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadStringCallback2 method gets called
   // when the download completes.
   client->DownloadStringCompleted += gcnew DownloadStringCompletedEventHandler( DownloadStringCallback2 );
   client->DownloadStringAsync( uri );
}

