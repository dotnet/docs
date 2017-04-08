

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextReader^ reader = nullptr;
   __try
   {
      
      // Create the XML fragment to be parsed.
      String^ xmlFrag = "<book genre='novel' misc='sale-item &h; 1987'></book>";
      
      // Create the XmlParserContext.
      XmlParserContext^ context;
      String^ subset = "<!ENTITY h 'hardcover'>";
      context = gcnew XmlParserContext( nullptr,nullptr,"book",nullptr,nullptr,subset,"","",XmlSpace::None );
      
      // Create the reader.
      reader = gcnew XmlTextReader( xmlFrag,XmlNodeType::Element,context );
      
      // Read the misc attribute. The attribute is parsed
      // into multiple text and entity reference nodes.
      reader->MoveToContent();
      reader->MoveToAttribute( "misc" );
      while ( reader->ReadAttributeValue() )
      {
         if ( reader->NodeType == XmlNodeType::EntityReference )
                  Console::WriteLine( " {0} {1}", reader->NodeType, reader->Name );
         else
                  Console::WriteLine( " {0} {1}", reader->NodeType, reader->Value );
      }
   }
   __finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

//</snippet1>
