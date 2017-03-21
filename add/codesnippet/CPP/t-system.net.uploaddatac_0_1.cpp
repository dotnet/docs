void UploadDataInBackground2( String^ address )
{
   WebClient^ client = gcnew WebClient;
   Uri ^uri = gcnew Uri(address);
   String^ text = "Time = 12:00am temperature = 50";
   array<Byte>^data = System::Text::Encoding::UTF8->GetBytes( text );
   String^ method = "POST";

   client->UploadDataCompleted += gcnew UploadDataCompletedEventHandler( UploadDataCallback2 );
   client->UploadDataAsync( uri, method, data );
}

