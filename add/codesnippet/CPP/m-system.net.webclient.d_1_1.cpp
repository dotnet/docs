void DownloadString( String^ address )
{
   WebClient^ client = gcnew WebClient;
   String^ reply = client->DownloadString( address );
   Console::WriteLine( reply );
}

