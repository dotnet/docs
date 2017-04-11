

//<Snippet1>
#using <System.dll>
#using <System.Security.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   array<String^>^args = System::Environment::GetCommandLineArgs();
   Console::WriteLine( "Verifying {0}...", args[ 1 ] );

   // Create a SignedXml.
   SignedXml^ signedXml = gcnew SignedXml;

   // Load the XML.
   XmlDocument^ xmlDocument = gcnew XmlDocument;
   xmlDocument->PreserveWhitespace = true;
   xmlDocument->Load( gcnew XmlTextReader( args[ 1 ] ) );
   XmlNodeList^ nodeList = xmlDocument->GetElementsByTagName( "Signature" );
   signedXml->LoadXml( safe_cast<XmlElement^>(nodeList[ 0 ]) );
   if ( signedXml->CheckSignature() )
   {
      Console::WriteLine( "Signature check OK" );
   }
   else
   {
      Console::WriteLine( "Signature check FAILED" );
   }
}
//</Snippet1>
