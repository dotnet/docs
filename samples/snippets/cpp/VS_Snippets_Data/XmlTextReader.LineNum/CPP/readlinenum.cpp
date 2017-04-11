

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create the XML fragment to be parsed.
   String^ xmlFrag = "<book>\n"
   "<misc>\n"
   "<style>paperback</style>\n"
   "<pages>240</pages>\n"
   "</misc>\n"
   "</book>\n";
   
   // Create the XmlNamespaceManager.
   NameTable^ nt = gcnew NameTable;
   XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager( nt );
   
   // Create the XmlParserContext.
   XmlParserContext^ context = gcnew XmlParserContext( nullptr,nsmgr,nullptr,XmlSpace::None );
   
   // Create the reader.
   XmlTextReader^ reader = gcnew XmlTextReader( xmlFrag,XmlNodeType::Element,context );
   
   // Parse the XML and display each node.
   while ( reader->Read() )
   {
      switch ( reader->NodeType )
      {
         case XmlNodeType::Element:
            Console::Write( " {0} {1}, {2}  ", reader->Depth, reader->LineNumber, reader->LinePosition );
            Console::WriteLine( "< {0}>", reader->Name );
            break;

         case XmlNodeType::Text:
            Console::Write( " {0} {1}, {2}  ", reader->Depth, reader->LineNumber, reader->LinePosition );
            Console::WriteLine( " {0}", reader->Value );
            break;

         case XmlNodeType::EndElement:
            Console::Write( " {0} {1}, {2}  ", reader->Depth, reader->LineNumber, reader->LinePosition );
            Console::WriteLine( "</ {0}>", reader->Name );
            break;
      }
   }

   
   // Close the reader.
   reader->Close();
}

//</snippet1>
