

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlValidatingReader^ reader = nullptr;
   try
   {
      
      //Create the XML fragment to be parsed.
      String^ xmlFrag = "<book genre='novel' misc='sale-item &h; 1987'></book>";
      
      //Create the XmlParserContext.
      XmlParserContext^ context;
      String^ subset = "<!ENTITY h 'hardcover'>";
      context = gcnew XmlParserContext( nullptr,nullptr,"book",nullptr,nullptr,subset,"","",XmlSpace::None );
      
      //Create the reader and set it to not expand general entities. 
      reader = gcnew XmlValidatingReader( xmlFrag,XmlNodeType::Element,context );
      reader->ValidationType = ValidationType::None;
      reader->EntityHandling = EntityHandling::ExpandCharEntities;
      
      //Read the misc attribute. Because EntityHandling is set to
      //ExpandCharEntities, the attribute is parsed into multiple text
      //and entity reference nodes.
      reader->MoveToContent();
      reader->MoveToAttribute( "misc" );
      while ( reader->ReadAttributeValue() )
      {
         if ( reader->NodeType == XmlNodeType::EntityReference )
                  
         //To expand the entity, call ResolveEntity.
         Console::WriteLine( "{0} {1}", reader->NodeType, reader->Name );
         else
                  Console::WriteLine( "{0} {1}", reader->NodeType, reader->Value );
      }
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
