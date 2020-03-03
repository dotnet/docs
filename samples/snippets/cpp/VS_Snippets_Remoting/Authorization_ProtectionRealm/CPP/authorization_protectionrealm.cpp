

// System::Net::Authorization::Authorization(String*, bool);System::Net::Authorization::ProtectionRealm
/* This program demonstrates the 'ProtectionRealm' property and 'Authorization(String*, bool)' constructor of
the S"Authorization" class. The S"IAuthenticationModule*" interface is implemented in 'CloneBasic' to make
it a custom authentication module. The custom authentication module encodes username and password as
base64 strings and then returns back an 'Authorization' instance. The 'Authorization' instance encapsulates
a list of Uri's for which it is applicable using the S"ProtectionRealm" property.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;
void GetPage( String^ url, String^ username, String^ passwd )
{
   try
   {
      String^ challenge = nullptr;
      HttpWebRequest^ myHttpWebRequest = nullptr;
      try
      {
         // Create a 'HttpWebRequest' Object* for the above 'url'.
         myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( url ));

         // The following method call throws the 'WebException'.
         HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());

         // Release resources of response Object*.
         myHttpWebResponse->Close();
      }
      catch ( WebException^ e ) 
      {
         for ( int i = 0; i < e->Response->Headers->Count; ++i )

            // Retrieve the challenge String* from the header S"WWW-Authenticate".
            if ( (String::Compare( e->Response->Headers->Keys[ i ], "WWW-Authenticate", true ) == 0) )
                        challenge = e->Response->Headers[ i ];
      }

      if ( challenge != nullptr )
      {
         // Challenge was raised by the client.Declare your credentials.
         NetworkCredential^ myCredentials = gcnew NetworkCredential( username,passwd );

         // Pass the challenge , 'NetworkCredential' Object* and the 'HttpWebRequest' Object* to the
         // 'Authenticate' method of the  S"AuthenticationManager" to retrieve an S"Authorization" ;
         // instance.
         Authorization^ urlAuthorization = AuthenticationManager::Authenticate( challenge, myHttpWebRequest, myCredentials );
         if ( urlAuthorization != nullptr )
         {
            Console::WriteLine( "\nSuccessfully Created 'Authorization' object with authorization Message:\n \" {0}\"", urlAuthorization->Message );
            Console::WriteLine( "\n\nThis authorization is valid for the following Uri's:" );
            int count = 0;
            System::Collections::IEnumerator^ myEnum = urlAuthorization->ProtectionRealm->GetEnumerator();
            while ( myEnum->MoveNext() )
            {
               String^ uri = safe_cast<String^>(myEnum->Current);
               ++count;
               Console::WriteLine( "\nUri->Item[ {0}]: {1}", count, uri );
            }
         }
         else
                  Console::WriteLine( "\nAuthorization Object* was returned as 0. Please check if site accepts 'CloneBasic' authentication" );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\n The following exception was raised : {0}", e->Message );
   }
}

void PrintUsage()
{
   Console::WriteLine( "\r\nUsage: Try a site which requires CloneBasic(custom made) authentication as below" );
   Console::WriteLine( "   Authorization_ProtectionRealm URLname username password" );
   Console::WriteLine( "\nExample:" );
   Console::WriteLine( "\n   Authorization_ProtectionRealm http://www.microsoft.com/net/ george george123" );
}

// The 'CloneBasic' authentication module class implements 'IAuthenticationModule*'.
public ref class CloneBasic: public IAuthenticationModule
{
private:
   String^ m_authenticationType;
   bool m_canPreAuthenticate;

public:
   CloneBasic()
   {
      m_authenticationType = "CloneBasic";
      m_canPreAuthenticate = false;
   }

   property String^ AuthenticationType 
   {
      virtual String^ get()
      {
         return m_authenticationType;
      }
   }

   property bool CanPreAuthenticate 
   {
      virtual bool get()
      {
         return m_canPreAuthenticate;
      }
   }

   // <Snippet1>
   // <Snippet2>
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
   // </Snippet2>
   // </Snippet1>

   virtual Authorization^ PreAuthenticate( WebRequest^ request, ICredentials^ credentials )
   {
      return nullptr;
   }
};

// The 'Client' class is defined here to test the above  custom authentication module.
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   String^ url;
   String^ userName;
   String^ passwd;
   if ( args->Length < 3 )
   {
      PrintUsage();
      return 0;
   }
   else
   {
      url = args[ 0 ];
      userName = args[ 1 ];
      passwd = args[ 2 ];
   }

   Console::WriteLine();
   CloneBasic^ authenticationModule = gcnew CloneBasic;
   AuthenticationManager::Register( authenticationModule );
   AuthenticationManager::Unregister( "Basic" );
   
   // Get response from Uri.
   GetPage( url, userName, passwd );
}
