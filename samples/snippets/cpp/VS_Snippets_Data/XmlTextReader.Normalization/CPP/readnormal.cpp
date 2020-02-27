

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create the XML fragment to be parsed.
   String^ xmlFrag = "<item attr1='  test A B C\n"
   "1 2 3'/>\n"
   "<item attr2='&#01;'/>\n";
   
   // Create the XmlNamespaceManager.
   XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager( gcnew NameTable );
   
   // Create the XmlParserContext.
   XmlParserContext^ context = gcnew XmlParserContext( nullptr,nsmgr,nullptr,XmlSpace::Preserve );
   
   // Create the reader.
   XmlTextReader^ reader = gcnew XmlTextReader( xmlFrag,XmlNodeType::Element,context );
   
   // Show attribute value normalization.
   reader->Read();
   reader->Normalization = false;
   Console::WriteLine( "Attribute value: {0}", reader->GetAttribute( "attr1" ) );
   reader->Normalization = true;
   Console::WriteLine( "Attribute value: {0}", reader->GetAttribute( "attr1" ) );
   
   // Set Normalization back to false.  This allows the reader to accept
   // character entities in the &#00; to &#20; range.  If Normalization had
   // been set to true, character entities in this range throw an exception.
   reader->Normalization = false;
   reader->Read();
   reader->MoveToContent();
   Console::WriteLine( "Attribute value: {0}", reader->GetAttribute( "attr2" ) );
   
   // Close the reader.
   reader->Close();
}

//</snippet1>
