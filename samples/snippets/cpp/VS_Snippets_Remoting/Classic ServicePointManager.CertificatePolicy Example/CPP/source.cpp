#using <System.Web.Services.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Windows::Forms;
using namespace System::Web;
using namespace System::Web::Services;

// Class added so sample will compile
public ref class MyCertificatePolicy: public ICertificatePolicy
{
public:
   virtual bool CheckValidationResult( System::Net::ServicePoint^, System::Security::Cryptography::X509Certificates::X509Certificate^, System::Net::WebRequest^, int )
   {
      return true;
   }
};

public ref class Form1: public Form
{
public:
   void Method( Uri^ myUri )
   {
      // <Snippet1>
      ServicePointManager::CertificatePolicy = gcnew MyCertificatePolicy;

      // Create the request and receive the response
      try
      {
         WebRequest^ myRequest = WebRequest::Create( myUri );
         WebResponse^ myResponse = myRequest->GetResponse();
         ProcessResponse( myResponse );
         myResponse->Close();
      }
      // Catch any exceptions
      catch ( WebException^ e ) 
      {
         if ( e->Status == WebExceptionStatus::TrustFailure )
         {
            // Code for handling security certificate problems goes here.
         }
         // Other exception handling goes here
      }
      // </Snippet1>
   }

   // Method added so sample will compile
   void ProcessResponse( WebResponse^ ){}
};
