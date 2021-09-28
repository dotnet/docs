// System::Web::Services::Description.ImportCollection
// System::Web::Services::Description.ImportCollection::Item
// System::Web::Services::Description.ImportCollection::CopyTo
// System::Web::Services::Description.ImportCollection::Contains
// System::Web::Services::Description.ImportCollection::IndexOf
// System::Web::Services::Description.ImportCollection::Remove

/* The following program demonstrates the methods 'CopyTo', 'Contains', 'IndexOf', 'Remove'
and property 'Item' of class 'ImportCollection'.
The program reads a 'WSDL' document and gets a 'ServiceDescription' instance
An 'ImportCollection' instance is then retrieved from this 'ServiceDescription'
instance and its members have been demonstrated.
*/

// <Snippet1>
#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Xml;
int main()
{
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "StockQuoteService_cpp.wsdl" );
   Console::WriteLine( " ImportCollection Sample " );
   
   // <Snippet2>
   // Get Import Collection.
   ImportCollection^ myImportCollection = myServiceDescription->Imports;
   Console::WriteLine( "Total Imports in the document = {0}", myServiceDescription->Imports->Count );
   
   // Print 'Import' properties to console.
   for ( int i = 0; i < myImportCollection->Count; ++i )
      Console::WriteLine( "\tImport Namespace : {0} Import Location : {1} ",
         myImportCollection[ i ]->Namespace, myImportCollection[ i ]->Location );
   // </Snippet2>

   // <Snippet3>
   array<Import^>^myImports = gcnew array<Import^>(myServiceDescription->Imports->Count);
   
   // Copy 'ImportCollection' to an array.
   myServiceDescription->Imports->CopyTo( myImports, 0 );
   Console::WriteLine( "Imports that are copied to Importarray ..." );
   for ( int i = 0; i < myImports->Length; ++i )
      Console::WriteLine( "\tImport Namespace : {0} Import Location : {1} ",
         myImports[ i ]->Namespace, myImports[ i ]->Location );
   // </Snippet3>

   // <Snippet4>
   // <Snippet5>
   // <Snippet6>
   // Get Import by Index.
   Import^ myImport = myServiceDescription->Imports[ myServiceDescription->Imports->Count - 1 ];
   Console::WriteLine( "Import by Index..." );
   if ( myImportCollection->Contains( myImport ) )
   {
      Console::WriteLine( "Import Namespace ' {0} ' is found in 'ImportCollection'.", myImport->Namespace );
      Console::WriteLine( "Index of '{0}' in 'ImportCollection' = {1}",
         myImport->Namespace, myImportCollection->IndexOf( myImport ) );
      Console::WriteLine( "Deleting Import from 'ImportCollection'..." );
      myImportCollection->Remove( myImport );
      if ( myImportCollection->IndexOf( myImport ) == -1 )
            Console::WriteLine( "Import is successfully removed from Import Collection." );
   }
   // </Snippet6>
   // </Snippet5>
   // </Snippet4>
}

// </snippet1>
