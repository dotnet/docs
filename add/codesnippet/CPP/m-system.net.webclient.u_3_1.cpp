void PostString( String^ address )
{
   String^ data = "Time = 12:00am temperature = 50";
   String^ method = "POST";
   WebClient^ client = gcnew WebClient;
   String^ reply = client->UploadString( address, method, data );
   Console::WriteLine( reply );
}

