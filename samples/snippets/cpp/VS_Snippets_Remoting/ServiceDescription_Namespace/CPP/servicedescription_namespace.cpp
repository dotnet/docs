// System::Web::Services::Description.ServiceDescription::Namespace

/*
The following example demonstrates 'Namespace' property of 'ServiceDescription' class.The input to the program is a
WSDL file 'MyWsdl::wsdl'.This program displays the Namespace of 'ServiceDescription' class.
*/

#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Web::Services::Description;

int main()
{
   try
   {
// <Snippet1>
      ServiceDescription^ myDescription = 
         ServiceDescription::Read( "MyWsdl_CS.wsdl" );
      Console::WriteLine( "Namespace : " + ServiceDescription::Namespace );
// </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: " + e->Message );
   }
}
