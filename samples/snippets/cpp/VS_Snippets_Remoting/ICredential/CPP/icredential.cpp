/*
This program demonstrates 'GetCredential' method of 'ICredentials*' interface.
The 'CredentialList' class implements 'ICredentials*' interface which stores credentials for multiple
internet resources.The Program takes URL, Username, Password and Domain name from commandline and adds
it to an instance of 'CredentialList' class.An instance of 'WebRequest' class is obtained and 'Credentials'
property of 'WebRequest' class is set to an instance of 'NetworkCredential' class obtained by calling
'GetCredential' method of 'CredentialList' class. Then it sends the request and obtains a response.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Collections;

// <Snippet1>
ref class CredentialList: public ICredentials
{
private:
   ref class CredentialInfo
   {
   public:
      Uri^ uriObj;
      String^ authenticationType;
      NetworkCredential^ networkCredentialObj;
      CredentialInfo( Uri^ uriObj, String^ authenticationType, NetworkCredential^ networkCredentialObj )
      {
         this->uriObj = uriObj;
         this->authenticationType = authenticationType;
         this->networkCredentialObj = networkCredentialObj;
      }
   };

   ArrayList^ arrayListObj;

public:
   CredentialList()
   {
      arrayListObj = gcnew ArrayList;
   }

   void Add( Uri^ uriObj, String^ authenticationType, NetworkCredential^ credential )
   {
      
      // Add a 'CredentialInfo' object into a list.
      arrayListObj->Add( gcnew CredentialInfo( uriObj,authenticationType,credential ) );
   }

   // Remove the 'CredentialInfo' object from the list that matches to the given 'Uri' and 'AuthenticationType'
   void Remove( Uri^ uriObj, String^ authenticationType )
   {
      for ( int index = 0; index < arrayListObj->Count; index++ )
      {
         CredentialInfo^ credentialInfo = dynamic_cast<CredentialInfo^>(arrayListObj[ index ]);
         if ( uriObj->Equals( credentialInfo->uriObj ) && authenticationType->Equals( credentialInfo->authenticationType ) )
                  arrayListObj->RemoveAt( index );
      }
   }

   virtual NetworkCredential^ GetCredential( Uri^ uriObj, String^ authenticationType )
   {
      for ( int index = 0; index < arrayListObj->Count; index++ )
      {
         CredentialInfo^ credentialInfoObj = dynamic_cast<CredentialInfo^>(arrayListObj[ index ]);
         if ( uriObj->Equals( credentialInfoObj->uriObj ) && authenticationType->Equals( credentialInfoObj->authenticationType ) )
                  return credentialInfoObj->networkCredentialObj;
      }
      return nullptr;
   }
};
// </Snippet1>

void GetPage( String^ urlString, String^ UserName, String^ password, String^ DomainName )
{
   try
   {
      CredentialList^ credentialListObj = gcnew CredentialList;

      // Dummy names used as credentials.
      credentialListObj->Add( gcnew Uri( urlString ),
            "Basic", gcnew NetworkCredential( UserName,password,DomainName ) );
      credentialListObj->Add( gcnew Uri( "http://www.msdn.microsoft.com" ),
            "Basic", gcnew NetworkCredential( "User1","Passwd1","Domain1" ) );

      // Create a 'WebRequest' for the specified url.
      WebRequest^ myWebRequest = WebRequest::Create( urlString );

      // Call 'GetCredential' to obtain the credentials specific to a Uri.
      myWebRequest->Credentials = credentialListObj->GetCredential( gcnew Uri( urlString ), "Basic" );

      // Send the request and get the  response.
      WebResponse^ myWebResponse = myWebRequest->GetResponse();

      // ....Process the response here.
      Console::WriteLine( "\n Response Received." );
      myWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "WebException caught !!!" );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught !!!" );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}

int main()
{
   String^ urlString;
   String^ username;
   String^ password;
   String^ domainname;
   Console::Write( "Enter a URL(for e.g. http://www.microsoft.com : " );
   urlString = Console::ReadLine();
   Console::Write( "Enter User name : " );
   username = Console::ReadLine();
   Console::Write( "Enter Password :" );
   password = Console::ReadLine();
   Console::Write( "Enter Domain name : " );
   domainname = Console::ReadLine();
   GetPage( urlString, username, password, domainname );
}
