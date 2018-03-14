

// System::Web::Services::Description.BindingCollection;System::Web::Services::Description.BindingCollection::Item->Item[Int32];
// System::Web::Services::Description.BindingCollection::Item->Item[String];System::Web::Services::Description.BindingCollection::CopyTo
/* The program reads a wsdl document S"MathService::wsdl" and instantiates a 
// ServiceDescription instance from the WSDL document.A BindingCollection instance 
// is then retrieved from this ServiceDescription instance and it's members are demonstrated. 
*/
#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;

int main()
{
   Binding^ myBinding;
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_input.wsdl" );
   Console::WriteLine( "Total Number of bindings : {0}", myServiceDescription->Bindings->Count );
   
   // <Snippet1>      
   for ( int i = 0; i < myServiceDescription->Bindings->Count; ++i )
   {
      Console::WriteLine( "\nBinding {0}", i );

      // Get Binding at index i.
      myBinding = myServiceDescription->Bindings[ i ];
      Console::WriteLine( "\t Name : {0}", myBinding->Name );
      Console::WriteLine( "\t Type : {0}", myBinding->Type );
   }
   // </Snippet1>

   // <Snippet2>
   array<Binding^>^myBindings = gcnew array<Binding^>(myServiceDescription->Bindings->Count);

   // Copy BindingCollection to an Array.
   myServiceDescription->Bindings->CopyTo( myBindings, 0 );
   Console::WriteLine( "\n\n Displaying array copied from BindingCollection" );
   for ( int i = 0; i < myServiceDescription->Bindings->Count; ++i )
   {
      Console::WriteLine( "\nBinding {0}", i );
      Console::WriteLine( "\t Name : {0}", myBindings[ i ]->Name );
      Console::WriteLine( "\t Type : {0}", myBindings[ i ]->Type );
   }
   // </Snippet2>
   
   // <Snippet3>    
   // Get Binding Name = S"MathServiceSoap".
   myBinding = myServiceDescription->Bindings[ "MathServiceHttpGet" ];
   if ( myBinding != nullptr )
   {
      Console::WriteLine( "\n\nName : {0}", myBinding->Name );
      Console::WriteLine( "Type : {0}", myBinding->Type );
   }
   // </Snippet3>

   myServiceDescription = nullptr;
   myBinding = nullptr;
}
