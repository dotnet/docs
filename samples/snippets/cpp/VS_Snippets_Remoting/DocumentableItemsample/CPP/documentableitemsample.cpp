

// System::Web::Services::Description.DocumentableItem::Documentation;
/* 
The following program demonstrates the property 'Documentation' of abstract class 'DocumentableItem'
The program reads a wsdl document S"MathService::wsdl" and instantiates a ServiceDescription instance
from the WSDL document.
This program demonstrates a generic utility function which can accept any of Types, PortType and Binding 
classes as parameters.
*/
// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services::Description;
using namespace System::Collections;

// Prints documentation associated with a wsdl element.
void PrintDocumentation( DocumentableItem^ myItem )
{
   Console::WriteLine( "\t {0}", myItem->Documentation );
}

int main()
{
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_cpp.wsdl" );
   Console::WriteLine( "Documentation Element for type is " );
   PrintDocumentation( myServiceDescription->Types );
   IEnumerator^ myEnum = myServiceDescription->PortTypes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      PortType^ myPortType = safe_cast<PortType^>(myEnum->Current);
      Console::WriteLine( "Documentation Element for Port Type {0} is ", myPortType->Name );
      PrintDocumentation( myPortType );
   }

   myEnum = myServiceDescription->Bindings->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Binding^ myBinding = safe_cast<Binding^>(myEnum->Current);
      Console::WriteLine( "Documentation Element for Port Type {0} is ", myBinding->Name );
      PrintDocumentation( myBinding );
   }
}
// </Snippet1>
