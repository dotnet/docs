

// System::Net::Authorization::Authorization(String*, bool, String*)
/* This program demonstrates the contructor 'Authorization(String*, bool, String*)' of the authorization
* class.
*
* We implement the interface S"IAuthenticationModule*" to make CloneBasic which is a custom authentication module.
* The custom authentication module encodes username and password as base64 strings and then returns
* back an authorization instance. This authorization is internally used by the HttpWebRequest for
* authentication.
* *
* Please Note : This program has to be compiled as a dll.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;

namespace CloneBasicAuthentication
{
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
      virtual Authorization^ Authenticate( String^ challenge, WebRequest^ request, ICredentials^ credentials )
      {
         try
         {
            String^ message;

            // Check if Challenge String* was raised by a site which requires CloneBasic authentication.
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
            // a)Concatenate username and password seperated by space;
            // b)Apply ASCII encoding to obtain a stream of bytes;
            // c)Apply Base64 Encoding to this array of bytes to obtain our encoded authorization message.
            message = String::Concat( myCredentials->UserName, " ", myCredentials->Password );

            // Apply AsciiEncoding to our user name and password to obtain it as an array of bytes.
            Encoding^ asciiEncoding = Encoding::ASCII;
            array<Byte>^byteArray = gcnew array<Byte>(asciiEncoding->GetByteCount( message ));
            byteArray = asciiEncoding->GetBytes( message );

            // Perform Base64 transform.
            message = Convert::ToBase64String( byteArray );

            // The following overloaded contructor sets the 'Message' property of authorization to the base64 String*;
            // that  we just formed and it also sets the 'Complete' property to true and the connection group id;
            // to the domain of the NetworkCredential Object*.
            Authorization^ myAuthorization = gcnew Authorization( String::Concat( "CloneBasic ", message, true, request->ConnectionGroupName ) );
            return myAuthorization;
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( "Exception Raised ...: {0}", e->Message );
            return nullptr;
         }
      }
      // </Snippet1>

      virtual Authorization^ PreAuthenticate( WebRequest^ request, ICredentials^ credentials )
      {
         return nullptr;
      }
   };
}
