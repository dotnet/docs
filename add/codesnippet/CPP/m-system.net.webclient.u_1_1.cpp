void UploadString( String^ address )
{
   String^ data = "Time = 12:00am temperature = 50";
   WebClient^ client = gcnew WebClient;
   
   // Optionally specify an encoding for uploading and downloading strings.
   client->Encoding = System::Text::Encoding::UTF8;
   
   // Upload the data.
   String^ reply = client->UploadString( address, data );
   
   // Disply the server's response.
   Console::WriteLine( reply );
}

