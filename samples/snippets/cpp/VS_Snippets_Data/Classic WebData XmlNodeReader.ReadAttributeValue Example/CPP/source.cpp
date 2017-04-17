

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlNodeReader^ reader = nullptr;
   try
   {
      
      //Create and load an XML document.
      XmlDocument^ doc = gcnew XmlDocument;
      doc->LoadXml( "<!DOCTYPE book [<!ENTITY h 'harcover'>]>"
      "<book genre='novel' misc='sale-item &h; 1987'>"
      "</book>" );
      
      //Create the reader. 
      reader = gcnew XmlNodeReader( doc );
      
      //Read the misc attribute. The attribute is parsed into multiple 
      //text and entity reference nodes.
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
