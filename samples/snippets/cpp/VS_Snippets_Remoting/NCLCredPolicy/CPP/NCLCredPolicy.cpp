
// NCLCredPolicy
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Security;
using namespace System::IO;
using namespace System::Text;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace Microsoft::Win32;

//<snippet3>
public ref class SelectedHostsCredentialPolicy: public ICredentialPolicy
{
public:
   SelectedHostsCredentialPolicy(){}

   virtual bool ShouldSendCredential( Uri^ challengeUri, WebRequest^ request, NetworkCredential^ /*credential*/, IAuthenticationModule^ /*authModule*/ )
   {
      Console::WriteLine( L"Checking custom credential policy." );
      if ( request->RequestUri->Host->Equals( L"www.contoso.com" ) || challengeUri->IsLoopback == true )
            return true;

      return false;
   }
};
//</snippet3>

//<snippet4>
// The following class allows credentials to be sent if they are for requests for resources
// in the same domain, or if the request uses the HTTPSscheme and basic authentication is 
// required.
public ref class HttpsBasicCredentialPolicy: public IntranetZoneCredentialPolicy
{
public:
   HttpsBasicCredentialPolicy(){}

   virtual bool ShouldSendCredential( Uri^ challengeUri, WebRequest^ request, NetworkCredential^ credential, IAuthenticationModule^ authModule ) override
   {
      Console::WriteLine( L"Checking custom credential policy for HTTPS and basic." );
      bool answer = IntranetZoneCredentialPolicy::ShouldSendCredential( challengeUri, request, credential, authModule );
      if ( answer == true )
      {
         Console::WriteLine( L"Sending credential for intranet resource." );
         return answer;
      }

      // Determine whether the base implementation returned false for basic and HTTPS.
      if ( request->RequestUri->Scheme == Uri::UriSchemeHttps && authModule->AuthenticationType->Equals( L"Basic" ) )
      {
         Console::WriteLine( L"Sending credential for HTTPS and basic." );
         return true;
      }

      return false;
   }
};
//</snippet4>

public ref class CredentialPolicyExamples
{
public:
   static void UseHttpsBasicCredentialPolicy()
   {
      HttpsBasicCredentialPolicy^ encryptedBasic = gcnew HttpsBasicCredentialPolicy;
      AuthenticationManager::CredentialPolicy = encryptedBasic;
   }

   static void UseCustomCredentialPolicy()
   {
      SelectedHostsCredentialPolicy^ hosts = gcnew SelectedHostsCredentialPolicy;
      AuthenticationManager::CredentialPolicy = hosts;
   }

   // <snippet2>
   static void UseIntranetCredentialPolicy()
   {
      IntranetZoneCredentialPolicy^ policy = gcnew IntranetZoneCredentialPolicy;
      AuthenticationManager::CredentialPolicy = policy;
   }
   // </snippet2>

   // <snippet1>
   // The following example uses the System, System.Net, 
   // and System.IO namespaces.
   static void RequestMutualAuth( Uri^ resource )
   {
      // Create a new HttpWebRequest object for the specified resource.
      WebRequest^ request = dynamic_cast<WebRequest^>(WebRequest::Create( resource ));

      // Request mutual authentication.
      request->AuthenticationLevel = AuthenticationLevel::MutualAuthRequested;

      // Supply client credentials.
      request->Credentials = CredentialCache::DefaultCredentials;
      HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->GetResponse());

      // Determine whether mutual authentication was used.
      Console::WriteLine( L"Is mutually authenticated? {0}", response->IsMutuallyAuthenticated );

      // Read and display the response.
      Stream^ streamResponse = response->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      String^ responseString = streamRead->ReadToEnd();
      Console::WriteLine( responseString );

      // Close the stream objects.
      streamResponse->Close();
      streamRead->Close();

      // Release the HttpWebResponse.
      response->Close();
   }
   // </snippet1>


private:

   static String^ GetUserName()
   {
      return L"sharriso1\\Jane";
   }

   static String^ GetUserPassword()
   {
      return L"LXMP9804!";
   }

public:
   ref class HttpsBasicCredentialOnlyPolicy: public ICredentialPolicy
   {
   public:
      HttpsBasicCredentialOnlyPolicy(){}

      virtual bool ShouldSendCredential( Uri^ /*challengeUri*/, WebRequest^ request, NetworkCredential^ /*credential*/, IAuthenticationModule^ authModule )
      {
         Console::WriteLine( L"Checking custom credential policy for HTTPS and basic." );

         // Determine whether the base implementation returned false for basic and https.
         if ( request->RequestUri->Scheme == Uri::UriSchemeHttps && authModule->AuthenticationType->Equals( L"Basic" ) )
         {
            Console::WriteLine( L"Sending credential for HTTPS and basic." );
            return true;
         }

         return false;
      }

   };

   static void RequestHttpBasicResource( Uri^ resource )
   {
      // Set policy to send credentials when using HTTPS and basic authentication;
      HttpsBasicCredentialOnlyPolicy^ encryptedBasic = gcnew HttpsBasicCredentialOnlyPolicy;
      AuthenticationManager::CredentialPolicy = encryptedBasic;

      // Create a new HttpWebRequest object for the specified resource.
      WebRequest^ request = dynamic_cast<WebRequest^>(WebRequest::Create( resource ));

      // Supply client credentials for basic authentication.
      request->Credentials = gcnew NetworkCredential( GetUserName(),GetUserPassword() );
      HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->GetResponse());

      // Determine whether mutual authentication was used.
      Console::WriteLine( L"Is mutually authenticated? {0}", response->IsMutuallyAuthenticated );

      // Read and display the response.
      System::IO::Stream^ streamResponse = response->GetResponseStream();
      System::IO::StreamReader^ streamRead = gcnew System::IO::StreamReader( streamResponse );
      String^ responseString = streamRead->ReadToEnd();
      Console::WriteLine( responseString );

      // Close the stream objects.
      streamResponse->Close();
      streamRead->Close();

      // Release the HttpWebResponse.
      response->Close();
   }

   // <snippet5>
   static void RequestResource( Uri^ resource )
   {
      // Set policy to send credentials when using HTTPS and basic authentication.
      // Create a new HttpWebRequest object for the specified resource.
      WebRequest^ request = dynamic_cast<WebRequest^>(WebRequest::Create( resource ));

      // Supply client credentials for basic authentication.
      request->UseDefaultCredentials = true;
      request->AuthenticationLevel = AuthenticationLevel::MutualAuthRequired;
      HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->GetResponse());

      // Determine mutual authentication was used.
      Console::WriteLine( L"Is mutually authenticated? {0}", response->IsMutuallyAuthenticated );
      System::Collections::Specialized::StringDictionary^ spnDictionary = AuthenticationManager::CustomTargetNameDictionary;
      System::Collections::IEnumerator^ myEnum = spnDictionary->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DictionaryEntry^ e = safe_cast<DictionaryEntry^>(myEnum->Current);
         Console::WriteLine( "Key: {0}  - {1}", dynamic_cast<String^>(e->Key), dynamic_cast<String^>(e->Value) );
      }

      // Read and display the response.
      System::IO::Stream^ streamResponse = response->GetResponseStream();
      System::IO::StreamReader^ streamRead = gcnew System::IO::StreamReader( streamResponse );
      String^ responseString = streamRead->ReadToEnd();
      Console::WriteLine( responseString );

      // Close the stream objects.
      streamResponse->Close();
      streamRead->Close();

      // Release the HttpWebResponse.
      response->Close();
   }

   /*
   
   The output from this example will differ based on the requested resource
   and whether mutual authentication was successful. For the purpose of illustration,
   a sample of the output is shown here:
   
   Is mutually authenticated? True
   Key: http://server1.someDomain.contoso.com  - HTTP/server1.someDomain.contoso.com
   
   <html>
   ...
   </html>
   
   */
   // </snippet5>
   int TestCredentialPolicy()
   {
      // UseCustomCredentialPolicy();
      //RequestMutualAuth(new Uri("http://wasabi/noribeta/NamespaceExceptionReport.aspx?Namespace=System.Net"));
      //RequestMutualAuth(new Uri("http://sharriso1/test/postaccepter.aspx"));
      // RequestResource(new Uri("http://sharriso1.redmond.corp.microsoft.com/test/postaccepter.aspx"));
      RequestResource( gcnew Uri( L"http://www.google.com" ) );
      return 1;
   }
};

void main()
{
   CredentialPolicyExamples^ cpe = gcnew CredentialPolicyExamples;
   cpe->TestCredentialPolicy();
}
