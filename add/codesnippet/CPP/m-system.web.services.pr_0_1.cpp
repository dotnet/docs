   // Math is a proxy class derived from HttpGetClientProtocol.
   HttpGetClientProtocol^ myHttpGetClientProtocol = gcnew ::Math;
   
   // Obtain password from a secure store.
   String^ SecurelyStoredPassword = String::Empty;
   
   // Set the client-side credentials using the Credentials property.
   ICredentials^ credentials = gcnew NetworkCredential( "Joe","mydomain",SecurelyStoredPassword );
   myHttpGetClientProtocol->Credentials = credentials;
   Console::WriteLine( "Auto redirect is: {0}", myHttpGetClientProtocol->AllowAutoRedirect );
}
