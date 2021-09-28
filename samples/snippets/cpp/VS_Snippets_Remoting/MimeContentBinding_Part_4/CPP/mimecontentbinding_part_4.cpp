// System::Web::Services::Description.MimeContentBinding::Type
// System::Web::Services::Description.MimeContentBinding::Part
// System::Web::Services::Description.MimeContentBinding::NameSpace
// System::Web::Services::Description.MimeContentBinding

/* The following program demonstrates properties 'Type', 'Part'
and field 'NameSpace'of class 'MimeContentBinding'.It reads 'MimeContentSample_cs::wsdl'file
and instantiates a ServiceDescription Object*.'MimeContentBinding' objects  are retrieved from Extension
points of OutputBinding for one of the Binding Object* and its properties 'Type', 'Part'are displayed.It also        
displays 'NameSpace' of the 'MimeContentBinding' Object*.
*/

// <Snippet4>
#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;

int main()
{
   // <Snippet3>
   // <Snippet1>
   // <Snippet2>
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MimeContentSample_cpp.wsdl" );

   // Get the Binding.
   Binding^ myBinding = myServiceDescription->Bindings[ "b1" ];

   // Get the first OperationBinding.
   OperationBinding^ myOperationBinding = myBinding->Operations[ 0 ];
   OutputBinding^ myOutputBinding = myOperationBinding->Output;
   ServiceDescriptionFormatExtensionCollection ^ myServiceDescriptionFormatExtensionCollection = myOutputBinding->Extensions;

   // Find all MimeContentBinding objects in extensions.
   array<MimeContentBinding^>^myMimeContentBindings = (array<MimeContentBinding^>^)myServiceDescriptionFormatExtensionCollection->FindAll( MimeContentBinding::typeid );

   // Enumerate the array and display MimeContentBinding properties.
   IEnumerator^ myEnum = myMimeContentBindings->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      MimeContentBinding^ myMimeContentBinding = safe_cast<MimeContentBinding^>(myEnum->Current);
      Console::WriteLine( "Type: {0}", myMimeContentBinding->Type );
      Console::WriteLine( "Part: {0}", myMimeContentBinding->Part );
   }
   // </Snippet2>
   // </Snippet1>
   Console::WriteLine( "Namespace: {0}", MimeContentBinding::Namespace );
   // </Snippet3>
}
// </Snippet4>
