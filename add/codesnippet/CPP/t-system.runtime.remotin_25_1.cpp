#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD formatted string to create a SoapHexBinary object.
   String^ xsdHexBinary = L"3f789ABC";
   SoapHexBinary^ hexBinary = SoapHexBinary::Parse( xsdHexBinary );

   // Print the value of the SoapHexBinary object in XSD format.
   Console::WriteLine( L"The SoapHexBinary object in XSD format is {0}.",
      hexBinary );

   // Print the XSD type string of this particular SoapHexBinary object.
   Console::WriteLine( L"The XSD type of the SoapHexBinary object is {0}.",
      hexBinary->GetXsdType() );

   // Print the value of the SoapHexBinary object.
   Console::Write( L"hexBinary.Value contains:" );
   for ( int i = 0; i < hexBinary->Value->Length; ++i )
   {
      Console::Write( L" {0}", hexBinary->Value[ i ] );

   }
   Console::WriteLine();

   // Print the XSD type string of the SoapHexBinary class.
   Console::WriteLine( L"The XSD type of the class SoapHexBinary is {0}.",
      SoapHexBinary::XsdType );
}
