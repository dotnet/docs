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