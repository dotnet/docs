#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD formatted string to create a SoapBase64Binary object.
   // The string "AgMFBws=" is byte[]{ 2, 3, 5, 7, 11 } expressed in
   // Base 64 format.
   String^ xsdBase64Binary = L"AgMFBws=";
   SoapBase64Binary^ base64Binary = SoapBase64Binary::Parse( xsdBase64Binary );

   // Print the value of the SoapBase64Binary object in XSD format.
      Console::WriteLine( L"The SoapBase64Binary object in XSD format is {0}.",
         base64Binary );

   // Print the XSD type string of the SoapBase64Binary object.
   Console::WriteLine( L"The XSD type of the SoapBase64Binary "
      L"object is {0}.", base64Binary->GetXsdType() );   

   // Print the value of the SoapBase64Binary object.
   Console::Write( L"base64Binary.Value contains:" );
   for ( int i = 0; i < base64Binary->Value->Length; ++i )
   {
      Console::Write( L" {0}", base64Binary->Value[ i ] );

   }
   Console::WriteLine();

   // Print the XSD type string of the SoapBase64Binary class.
   Console::WriteLine( L"The XSD type of the class SoapBase64Binary "
      L"is {0}.", SoapBase64Binary::XsdType );
}