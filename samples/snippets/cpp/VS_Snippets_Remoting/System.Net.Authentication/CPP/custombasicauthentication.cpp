

// <Internal>
// This program contains snippets applicable to the following:
// System::Net::AuthenticationManger (Snippet1);
// System::Net::AuthenticationManger::Register (Snippet2);
// System::Net::AuthenticationUnregister (Snippet2);
// System::Net::AuthenticationManger::RegisteredModules (Snippet8);
// System::Net::Authorization::Authorization (Snippet3);
// System::Net::Authorization::Message (Snippet5);
// System::Net::Authorization::Complete (Snippet5);
// System::Net::Authorization::GroupId (Snippet5);
// System::Net::IAuthenticationModule* (Snippet6);
// System::Net::IAuthenticationModule*.AuthenticationType (Snippet7);
// System::Net::IAuthenticationModule*.CanPreAuthenticate (Snippet7);
// System::Net::IAuthenticationModule*.Authenticate (Snippet3);
// System::Net::IAuthenticationModule*.PreAuthenticate (Snippet4);
// </Internal>
//<Snippet1>
// This program shows how to create a custom Basic authentication module,
// how to register it via the AuthenticationManager class and how to authorize
// users to access a Web site.
// Note: In order to run this program you must create a test Web site that performs
// Basic authentication. Also you must add to your server machine a user whose
// credentials are the same you use in this program.
// Attention: Basic authenticastion sends the user's credentials over HTTP.
// Passwords and user names are encoded using Base64 encoding. Although the
// user information is encoded, it is considered insecure due to the fact that it
// could be deciphered relatively easily.
// If you must use basic authentication you are strongly adviced to use strong
// security mechanisms, such as SSL, when transfering sensitive information on
// the wire.
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Text;
using namespace System::Collections;

// The ClientAuthentication class performs the following main tasks:
// 1) It obtains the user's credentials.
// 2) Unregisters the standard Basic authentication.
// 3) Registers the customized Basic authentication.
// 4) Reads the selected page and displays it on the console.
ref class TestAuthentication
{
public:
   static String^ username;
   static String^ password;
   static String^ domain;
   static String^ uri;

   // Show how to use this program.
   static void showusage()
   {
      Console::WriteLine( "Attempts to authenticate to a URL" );
      Console::WriteLine( "\r\nUse one of the following:" );
      Console::WriteLine( "\tcustomBasicAuthentication URL username password domain" );
      Console::WriteLine( "\tcustomBasicAuthentication URL username password" );
      Console::WriteLine( "\r\nExample:" );
      Console::WriteLine( "\tcustomBasicAuthentication http://ndpue/ncl/ basicuser basic.101 ndpue" );
   }


   // <Snippet8>
   // Display registered authentication modules.
   static void displayRegisteredModules()
   {
      
      // The AuthenticationManager calls all authentication modules sequentially
      // until one of them responds with an authorization instance.  Show
      // the current registered modules, for testing purposes.
      IEnumerator^ registeredModules = AuthenticationManager::RegisteredModules;
      Console::WriteLine( "\r\nThe following authentication modules are now registered with the system" );
      while ( registeredModules->MoveNext() )
      {
         Console::WriteLine( "\r \n Module : {0}", registeredModules->Current );
         IAuthenticationModule^ currentAuthenticationModule = dynamic_cast<IAuthenticationModule^>(registeredModules->Current);
         Console::WriteLine( "\t  CanPreAuthenticate : {0}", currentAuthenticationModule->CanPreAuthenticate );
      }
   }


   // </Snippet8>
   // The getPage method accesses the selected page an displays its content
   // on the console.
   static void getPage( String^ url )
   {
      try
      {
         
         // Create the Web request object.
         HttpWebRequest^ req = dynamic_cast<HttpWebRequest^>(WebRequest::Create( url ));
         
         // Define the request access method.
         req->Method = "GET";
         
         // Define the request credentials according to the user's input.
         if ( String::Compare( domain, String::Empty ) == 0 )
                  req->Credentials = gcnew NetworkCredential( username,password ); // If the user's specifies the Internet resource domain, this usually
         else
                  req->Credentials = gcnew NetworkCredential( username,password,domain );
         
         // is by default the name of the sever hosting the resource.
         // Issue the request.
         // req->GetResponse();
         HttpWebResponse^ result = dynamic_cast<HttpWebResponse^>(req->GetResponse());
         Console::WriteLine( "\nAuthentication Succeeded:" );
         
         // Store the response.
         Stream^ sData = result->GetResponseStream();
         
         // Display the response.
         displayPageContent( sData );
      }
      catch ( WebException^ e ) 
      {
         
         // Display the error, if any. In particular display protocol
         // related error.
         if ( e->Status == WebExceptionStatus::ProtocolError )
         {
            HttpWebResponse^ hresp = dynamic_cast<HttpWebResponse^>(e->Response);
            Console::WriteLine( "\nAuthentication Failed, {0}", hresp->StatusCode );
            Console::WriteLine( "Status Code: {0}", (int)hresp->StatusCode );
            Console::WriteLine( "Status Description: {0}", hresp->StatusDescription );
            return;
         }
         Console::WriteLine( "Caught Exception: {0}", e->Message );
         Console::WriteLine( "Stack: {0}", e->StackTrace );
      }

   }


   // The displayPageContent method display the content of the
   // selected page.
   static void displayPageContent( Stream^ ReceiveStream )
   {
      
      // Create an ASCII encoding object.
      Encoding^ ASCII = Encoding::ASCII;
      
      // Define the Byte array to temporary hold the current read bytes.
      array<Byte>^read = gcnew array<Byte>(512);
      Console::WriteLine( "\r\nPage Content...\r\n" );
      
      // Read the page content and display it on the console.
      // Read the first 512 bytes.
      int bytes = ReceiveStream->Read( read, 0, 512 );
      while ( bytes > 0 )
      {
         Console::Write( ASCII->GetString( read, 0, bytes ) );
         bytes = ReceiveStream->Read( read, 0, 512 );
      }

      Console::WriteLine( "" );
   }

};


// <Snippet6>
// The CustomBasic class creates a custom Basic authentication by implementing the
// IAuthenticationModule interface. In particular it performs the following
// tasks:
// 1) Defines and initializes the required properties.
// 2) Impements the Authenticate method.
public ref class CustomBasic: public IAuthenticationModule
{
private:

   // <Snippet7>
   String^ m_authenticationType;
   bool m_canPreAuthenticate;

public:

   // The CustomBasic constructor initializes the properties of the customized
   // authentication.
   CustomBasic()
   {
      m_authenticationType = "Basic";
      m_canPreAuthenticate = false;
   }


   property String^ AuthenticationType 
   {

      // Define the authentication type. This type is then used to identify this
      // custom authentication module. The default is set to Basic.
      virtual String^ get()
      {
         return m_authenticationType;
      }

   }

   property bool CanPreAuthenticate 
   {

      // Define the pre-authentication capabilities for the module. The default is set
      // to false.
      virtual bool get()
      {
         return m_canPreAuthenticate;
      }

   }

   // </Snippet7>
   // The checkChallenge method checks if the challenge sent by the HttpWebRequest
   // contains the correct type (Basic) and the correct domain name.
   // Note: the challenge is in the form BASIC REALM=S"DOMAINNAME"
   // and you must assure that the Internet Web site resides on a server whose
   // domain name is equal to DOMAINAME.
   bool checkChallenge( String^ Challenge, String^ domain )
   {
      bool challengePasses = false;
      String^ tempChallenge = Challenge->ToUpper();
      
      // Verify that this is a Basic authorization request and the requested domain
      // is correct.
      // Note: When the domain is an empty string the following code only checks
      // whether the authorization type is Basic.
      if ( tempChallenge->IndexOf( "BASIC" ) != -1 )
            if ( String::Compare( domain, String::Empty ) != 0 )
            if ( tempChallenge->IndexOf( domain->ToUpper() ) != -1 )
            challengePasses = true; // The domain is not allowed and the authorization type is Basic.
      else
            challengePasses = false;

      else
            challengePasses = true;


      return challengePasses;
   }


   // <Snippet4>
   // The PreAuthenticate method specifies if the authentication implemented
   // by this class allows pre-authentication.
   // Even if you do not use it, this method must be implemented to obey to the rules
   // of interface implemebtation.
   // In this case it always returns null.
   virtual Authorization^ PreAuthenticate( WebRequest^ request, ICredentials^ credentials )
   {
      return nullptr;
   }


   // </Snippet4>
   // <Snippet3>
   // Authenticate is the core method for this custom authentication.
   // When an internet resource requests authentication, the WebRequest::GetResponse
   // method calls the AuthenticationManager::Authenticate method. This method, in
   // turn, calls the Authenticate method on each of the registered authentication
   // modules, in the order they were registered. When the authentication is
   // complete an Authorization object is returned to the WebRequest, as
   // shown by this routine's retun type.
   virtual Authorization^ Authenticate( String^ challenge, WebRequest^ request, ICredentials^ credentials )
   {
      Encoding^ ASCII = Encoding::ASCII;
      
      // Get the username and password from the credentials
      NetworkCredential^ MyCreds = credentials->GetCredential( request->RequestUri, "Basic" );
      if ( PreAuthenticate( request, credentials ) == nullptr )
            Console::WriteLine( "\n Pre-authentication is not allowed." );
      else
            Console::WriteLine( "\n Pre-authentication is allowed." );

      
      // Verify that the challenge satisfies the authorization requirements.
      bool challengeOk = checkChallenge( challenge, MyCreds->Domain );
      if (  !challengeOk )
            return nullptr;

      
      // <Snippet5>
      // Create the encrypted string according to the Basic authentication format as
      // follows:
      // a)Concatenate username and password separated by colon;
      // b)Apply ASCII encoding to obtain a stream of bytes;
      // c)Apply Base64 Encoding to this array of bytes to obtain the encoded
      // authorization.
      String^ BasicEncrypt = String::Concat( MyCreds->UserName, ":", MyCreds->Password );
      String^ BasicToken = String::Concat( "Basic ", Convert::ToBase64String( ASCII->GetBytes( BasicEncrypt ) ) );
      
      // Create an Authorization object using the above encoded authorization.
      Authorization^ resourceAuthorization = gcnew Authorization( BasicToken );
      
      // Get the Message property which contains the authorization string that the
      // client returns to the server when accessing protected resources
      Console::WriteLine( "\n Authorization Message: {0}", resourceAuthorization->Message );
      
      // Get the Complete property which is set to true when the authentication process
      // between the client and the server is finished.
      Console::WriteLine( "\n Authorization Complete: {0}", resourceAuthorization->Complete );
      
      // </Snippet5>
      Console::WriteLine( "\n Authorization ConnectionGroupId: {0}", resourceAuthorization->ConnectionGroupId );
      return resourceAuthorization;
   }

   // </Snippet3>
};


// <Snippet2>
// This is the program entry point. It allows the user to enter
// their credentials and the Internet resource (Web page) to access.
// It also unregisters the standard and registers the customized basic
// authentication.
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length < 4 )
      TestAuthentication::showusage();
   else
   {
      
      // Read the user's credentials.
      TestAuthentication::uri = args[ 1 ];
      TestAuthentication::username = args[ 2 ];
      TestAuthentication::password = args[ 3 ];
      if ( args->Length == 4 )
            TestAuthentication::domain = String::Empty; // If the domain exists, store it. Usually the domain name
      else
            TestAuthentication::domain = args[ 4 ];
      
      // is by default the name of the server hosting the Internet
      // resource.
      // Instantiate the custom Basic authentication module.
      CustomBasic^ customBasicModule = gcnew CustomBasic;
      
      // Unregister the standard Basic authentication module.
      AuthenticationManager::Unregister( "Basic" );
      
      // Register the custom Basic authentication module.
      AuthenticationManager::Register( customBasicModule );
      
      // Display registered Authorization modules.
      TestAuthentication::displayRegisteredModules();
      
      // Read the specified page and display it on the console.
      TestAuthentication::getPage( TestAuthentication::uri );
   }
}

//</Snippet2>
// </Snippet6>
// </Snippet1>
