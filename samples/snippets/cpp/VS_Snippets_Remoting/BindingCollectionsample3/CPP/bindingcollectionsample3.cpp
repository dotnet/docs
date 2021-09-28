

// System::Web::Services::Description.BindingCollection;System::Web::Services::Description.Remove;System::Web::Services::Description.Add;
// System::Web::Services::Description.Contains;System::Web::Services::Description.IndexOf
/*The following example reads the contents of a file 'MathService::wsdl' into a ServiceDescription instance.
Removes first binding in the BindingCollection of the ServiceDescription instance and writes the current 
'ServiceDescription' instance into a temporary file.
Adds the same binding back again into the instance and writes to another temporary file.
*/
#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;

int main()
{
   Binding^ myBinding;

   // <Snippet1>      
   // <Snippet2>
   // <Snippet3>
   // <Snippet4>
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_input.wsdl" );
   Console::WriteLine( "Total Number of bindings defined are: {0}", myServiceDescription->Bindings->Count );
   myBinding = myServiceDescription->Bindings[ 0 ];

   // Remove the first binding in the collection.
   myServiceDescription->Bindings->Remove( myBinding );
   Console::WriteLine( "Successfully removed binding {0}", myBinding->Name );
   Console::WriteLine( "Total Number of bindings defined now are: {0}", myServiceDescription->Bindings->Count );
   myServiceDescription->Write( "MathService_temp.wsdl" );
   // </Snippet1>      

   // Add binding to the ServiceDescription instance.
   myServiceDescription->Bindings->Add( myBinding );
   // </Snippet2>

   if ( myServiceDescription->Bindings->Contains( myBinding ) )
      Console::WriteLine( "Successfully added binding {0}", myBinding->Name );
   // </Snippet3>

   Console::WriteLine( "Binding was added at index {0}", myServiceDescription->Bindings->IndexOf( myBinding ) );
   Console::WriteLine( "Total Number of bindings defined now are: {0}", myServiceDescription->Bindings->Count );
   myServiceDescription->Write( "MathService_temp1.wsdl" );
   // </Snippet4>
   * myServiceDescription = 0;

   myBinding = nullptr;
}
