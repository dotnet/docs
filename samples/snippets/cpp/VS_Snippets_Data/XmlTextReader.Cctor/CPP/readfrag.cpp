

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create the XML fragment to be parsed.
   String^ xmlFrag = "<book> <title>Pride And Prejudice</title> <bk:genre>novel</bk:genre> </book>";
   
   // Create the XmlNamespaceManager.
   NameTable^ nt = gcnew NameTable;
   XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager( nt );
   nsmgr->AddNamespace( "bk", "urn:sample" );
   
   // Create the XmlParserContext.
   XmlParserContext^ context = gcnew XmlParserContext( nullptr,nsmgr,nullptr,XmlSpace::None );
   
   // Create the reader. 
   XmlTextReader^ reader = gcnew XmlTextReader( xmlFrag,XmlNodeType::Element,context );
   
   // Parse the XML.  If they exist, display the prefix and  
   // namespace URI of each element.
   while ( reader->Read() )
   {
      if ( reader->IsStartElement() )
      {
         if ( reader->Prefix == String::Empty )
                  Console::WriteLine( "< {0}>", reader->LocalName );
         else
         {
            Console::Write( "< {0}: {1}>", reader->Prefix, reader->LocalName );
            Console::WriteLine( " The namespace URI is {0}", reader->NamespaceURI );
         }
      }
   }

   
   // Close the reader.
   reader->Close();
}

//</snippet1>
