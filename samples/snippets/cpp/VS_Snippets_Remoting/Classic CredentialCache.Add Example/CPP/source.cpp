#using <System.dll>

using namespace System;
using namespace System::Net;
public ref class Class
{
private:
   void Method1()
   {
      String^ UserName = Console::ReadLine();
      String^ SecurelyStoredPassword = Console::ReadLine();
      String^ Domain = Console::ReadLine();

      WebRequest^ wReq = WebRequest::Create( "http://www.contoso.com" );
      
      // <Snippet1>
      CredentialCache^ myCache = gcnew CredentialCache;

      myCache->Add( gcnew Uri( "http://www.contoso.com/" ), "Basic", gcnew NetworkCredential( UserName,SecurelyStoredPassword ) );
      myCache->Add( gcnew Uri( "http://www.contoso.com/" ), "Digest", gcnew NetworkCredential( UserName,SecurelyStoredPassword,Domain ) );

      wReq->Credentials = myCache;
      // </Snippet1>
   }
};
