#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
public:
   void Method()
   {
      String^ SecurelyStoredUserName = "";
      String^ SecurelyStoredPassword = "";
      String^ SecurelyStoredDomain = "";
      
      // <Snippet1>
      NetworkCredential^ myCred = gcnew NetworkCredential(
         SecurelyStoredUserName,SecurelyStoredPassword,SecurelyStoredDomain );

      CredentialCache^ myCache = gcnew CredentialCache;

      myCache->Add( gcnew Uri( "www.contoso.com" ), "Basic", myCred );
      myCache->Add( gcnew Uri( "app.contoso.com" ), "Basic", myCred );

      WebRequest^ wr = WebRequest::Create( "www.contoso.com" );
      wr->Credentials = myCache;
      // </Snippet1>
   }
};
