static void AuthenticateClient( TcpClient^ clientRequest )
{
   NetworkStream^ stream = clientRequest->GetStream();
   
   // Create the NegotiateStream.
   NegotiateStream^ authStream = gcnew NegotiateStream( stream,false );
   
   // Perform the server side of the authentication.
   authStream->AuthenticateAsServer();
   
   // Display properties of the authenticated client.
   IIdentity^ id = authStream->RemoteIdentity;
   Console::WriteLine( L"{0} was authenticated using {1}.", id->Name, id->AuthenticationType );
   
   // Read a message from the client.
   array<Byte>^buffer = gcnew array<Byte>(2048);
   int charLength = authStream->Read( buffer, 0, buffer->Length );
   String^ messageData = gcnew String( Encoding::UTF8->GetChars( buffer, 0, buffer->Length ) );
   Console::WriteLine( L"READ {0}", messageData );
   
   // Finished with the current client.
   authStream->Close();
   
   // Close the client connection.
   clientRequest->Close();
}

