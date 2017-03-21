void UploadStringInBackground2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ data = "Time = 12:00am temperature = 50";

   client->UploadStringCompleted += gcnew UploadStringCompletedEventHandler( UploadStringCallback2 );
   client->UploadStringAsync( uri, data );
}

