#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;

// Creates an Import object with namespace and location.
Import^ CreateImport( String^ targetNamespace, String^ targetlocation )
{
   Import^ myImport = gcnew Import;
   myImport->Location = targetlocation;
   myImport->Namespace = targetNamespace;
   return myImport;
}

void PrintImportCollection( String^ fileName_wsdl )
{
   // Read import collection properties from generated WSDL file.
   ServiceDescription^ myServiceDescription1 = ServiceDescription::Read( fileName_wsdl );
   ImportCollection^ myImportCollection = myServiceDescription1->Imports;
   Console::WriteLine( "Enumerating Import Collection for file ' {0}'...", fileName_wsdl );
   
   // Print Import properties to console.
   for ( int i = 0; i < myImportCollection->Count; ++i )
   {
      Console::WriteLine( "Namespace : {0}", myImportCollection[ i ]->Namespace );
      Console::WriteLine( "Location  : {0}", myImportCollection[ i ]->Location );
      Console::WriteLine( "ServiceDescription  : {0}", myImportCollection[ i ]->ServiceDescription->Name );
   }
}

int main()
{
   Console::WriteLine( "Import Sample" );
   
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "StockQuote_cpp.wsdl" );
   myServiceDescription->Imports->Add( CreateImport( "http://localhost/stockquote/schemas", "http://localhost/stockquote/stockquote_cpp.xsd" ) );

   // Save the ServiceDescripition to an external file.
   myServiceDescription->Write( "StockQuote_cpp.wsdl" );
   Console::WriteLine( "document 'StockQuote_cpp.wsdl'" );
   
   // Print the import collection to the console.
   PrintImportCollection( "StockQuote_cpp.wsdl" );
   
   myServiceDescription = ServiceDescription::Read( "StockQuoteService_cpp.wsdl" );
   myServiceDescription->Imports->Insert( 0, CreateImport( "http://localhost/stockquote/definitions", "http://localhost/stockquote/stockquote_cpp.wsdl" ) );

   // Save the ServiceDescripition to an external file.
   myServiceDescription->Write( "StockQuoteService_cs::wsdl" );
   Console::WriteLine( "" );
   Console::WriteLine( "document 'StockQuoteService_cpp.wsdl'" );
   
   //Print the import collection to the console.
   PrintImportCollection( "StockQuoteService_cpp.wsdl" );
}