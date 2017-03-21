void OpenResourceForWriting2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   
   // Specify that the OpenWriteCallback method gets called
   // when the writeable stream is available.
   client->OpenWriteCompleted += gcnew OpenWriteCompletedEventHandler( OpenWriteCallback2 );
   client->OpenWriteAsync( uri, "POST" );
   
   // Applications can perform other tasks
   // while waiting for the upload to complete.
}

