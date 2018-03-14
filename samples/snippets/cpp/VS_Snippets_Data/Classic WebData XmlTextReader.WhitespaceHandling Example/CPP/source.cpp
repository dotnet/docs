

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
void ReadXML( XmlParserContext^ context, String^ xmlFrag, WhitespaceHandling ws )
{
   
   //Create the reader and specify the WhitespaceHandling setting.
   XmlTextReader^ reader = gcnew XmlTextReader( xmlFrag,XmlNodeType::Element,context );
   reader->WhitespaceHandling = ws;
   
   //Parse the XML and display each of the nodes.
   while ( reader->Read() )
   {
      switch ( reader->NodeType )
      {
         case XmlNodeType::Element:
            Console::WriteLine( "{0}: <{1}>", reader->NodeType, reader->Name );
            break;

         case XmlNodeType::Text:
            Console::WriteLine( "{0}: {1}", reader->NodeType, reader->Value );
            break;

         case XmlNodeType::EndElement:
            Console::WriteLine( "{0}: </{1}>", reader->NodeType, reader->Name );
            break;

         case XmlNodeType::Whitespace:
            Console::WriteLine( "{0}:", reader->NodeType );
            break;

         case XmlNodeType::SignificantWhitespace:
            Console::WriteLine( "{0}:", reader->NodeType );
            break;
      }
   }

   
   //Close the reader.
   reader->Close();
}

int main()
{
   
   //Create the XML fragment to be parsed.
   String^ xmlFrag = "<book> "
   "  <title>Pride And Prejudice</title>"
   "  <genre>novel</genre>"
   "</book>";
   
   //Create the XmlNamespaceManager.
   NameTable^ nt = gcnew NameTable;
   XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager( nt );
   
   //Create the XmlParserContext.
   XmlParserContext^ context = gcnew XmlParserContext( nullptr,nsmgr,nullptr,XmlSpace::Default );
   Console::WriteLine( "Read the XML and ignore all white space..." );
   ReadXML( context, xmlFrag, WhitespaceHandling::None );
   Console::WriteLine( "\r\nRead the XML including white space nodes..." );
   ReadXML( context, xmlFrag, WhitespaceHandling::All );
}

// </Snippet1>
