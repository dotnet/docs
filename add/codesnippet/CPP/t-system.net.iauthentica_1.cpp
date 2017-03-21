// The CustomBasic class creates a custom Basic authentication by implementing the
// IAuthenticationModule interface. In particular it performs the following
// tasks:
// 1) Defines and initializes the required properties.
// 2) Impements the Authenticate method.
public ref class CustomBasic: public IAuthenticationModule
{
private:

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


   // The PreAuthenticate method specifies if the authentication implemented
   // by this class allows pre-authentication.
   // Even if you do not use it, this method must be implemented to obey to the rules
   // of interface implemebtation.
   // In this case it always returns null.
   virtual Authorization^ PreAuthenticate( WebRequest^ request, ICredentials^ credentials )
   {
      return nullptr;
   }


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
      
      Console::WriteLine( "\n Authorization ConnectionGroupId: {0}", resourceAuthorization->ConnectionGroupId );
      return resourceAuthorization;
   }

};


// This is the program entry point. It allows the user to enter
// her credentials and the Internet resource (Web page) to access.
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
