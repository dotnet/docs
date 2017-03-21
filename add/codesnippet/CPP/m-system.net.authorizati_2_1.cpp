   virtual Authorization^ Authenticate( String^ challenge, WebRequest^ request, ICredentials^ credentials )
   {
      try
      {
         String^ message;

         // Check if Challenge String* was raised by a site which requires 'CloneBasic' authentication.
         if ( (challenge == nullptr) || ( !challenge->StartsWith( "CloneBasic" )) )
                  return nullptr;
         NetworkCredential^ myCredentials;
         if ( dynamic_cast<CredentialCache^>(credentials) == nullptr )
         {
            myCredentials = credentials->GetCredential( request->RequestUri, "CloneBasic" );
            if ( myCredentials == nullptr )
                        return nullptr;
         }
         else
                  myCredentials = dynamic_cast<NetworkCredential^>(credentials);

         // Message encryption scheme :
         //   a)Concatenate username and password seperated by space;
         //   b)Apply ASCII encoding to obtain a stream of bytes;
         //   c)Apply Base64 Encoding to this array of bytes to obtain our encoded authorization message.
         message = String::Concat( myCredentials->UserName, " ", myCredentials->Password );

         // Apply AsciiEncoding to 'message' String* to obtain it as an array of bytes.
         Encoding^ ascii = Encoding::ASCII;
         array<Byte>^byteArray = gcnew array<Byte>(ascii->GetByteCount( message ));
         byteArray = ascii->GetBytes( message );

         // Performing Base64 transformation.
         message = Convert::ToBase64String( byteArray );
         Authorization^ myAuthorization = gcnew Authorization( String::Concat( "CloneBasic ", message, true ) );
         array<String^>^protectionRealm = gcnew array<String^>(1);
         protectionRealm[ 0 ] = request->RequestUri->AbsolutePath;
         myAuthorization->ProtectionRealm = protectionRealm;
         return myAuthorization;
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "The following exception was raised in Authenticate method: {0}", e->Message );
         return nullptr;
      }
   }