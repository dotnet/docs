

#using <System.dll>
#using <System.Web.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Net;
using namespace System::Web;
using namespace System::Web::UI;

public ref class Page1: public Page
{
private:
   void Page_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // <Snippet1>
      HttpWebRequest^ httpReq = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com" ));
      httpReq->AllowAutoRedirect = false;
      HttpWebResponse^ httpRes = dynamic_cast<HttpWebResponse^>(httpReq->GetResponse());
      if ( httpRes->StatusCode == HttpStatusCode::Moved )
      {
         // Code for moved resources goes here.
      }

      // Close the response.
      httpRes->Close();
      // </Snippet1>
   }
};
