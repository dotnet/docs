void OpenResourceForReading2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);

   client->OpenReadCompleted += gcnew OpenReadCompletedEventHandler( OpenReadCallback2 );
   client->OpenReadAsync( uri );
}

