// Sample call : DownLoadDataInBackground ("http://www.contoso.com/GameScores.html");
void DownloadDataInBackground( String^ address )
{
   System::Threading::AutoResetEvent^ waiter = gcnew System::Threading::AutoResetEvent( false );
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the DownloadDataCallback method gets called
   // when the download completes.
   client->DownloadDataCompleted += gcnew DownloadDataCompletedEventHandler( DownloadDataCallback );
   client->DownloadDataAsync( uri, waiter );
   
   // Block the main application thread. Real applications
   // can perform other tasks while waiting for the download to complete.
   waiter->WaitOne();
}

