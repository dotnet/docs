

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
public ref class Sample
{
private:
   XmlNode^ currNode;
   XmlTextReader^ reader;

public:
   Sample()
   {
      reader = nullptr;
      String^ filename = "space.xml";
      XmlDocument^ doc = gcnew XmlDocument;
      doc->LoadXml( "<!-- Sample XML fragment -->"
      "<author xml:space='preserve'>"
      "<first-name>Eva</first-name>"
      "<last-name>Corets</last-name>"
      "</author>" );
      Console::WriteLine( "InnerText before..." );
      Console::WriteLine( doc->DocumentElement->InnerText );
      
      // Add white space.     
      currNode = doc->DocumentElement;
      XmlSignificantWhitespace^ sigws = doc->CreateSignificantWhitespace( "\t" );
      currNode->InsertAfter( sigws, currNode->FirstChild );
      Console::WriteLine();
      Console::WriteLine( "InnerText after..." );
      Console::WriteLine( doc->DocumentElement->InnerText );
      
      // Save and then display the file.
      doc->Save( filename );
      Console::WriteLine();
      Console::WriteLine( "Reading file..." );
      ReadFile( filename );
   }


   // Parse the file and print out each node.
   void ReadFile( String^ filename )
   {
      try
      {
         reader = gcnew XmlTextReader( filename );
         String^ sNodeType = nullptr;
         while ( reader->Read() )
         {
            sNodeType = NodeTypeToString( reader->NodeType );
            
            // Print the node type, name, and value.
            Console::WriteLine( "{0}<{1}> {2}", sNodeType, reader->Name, reader->Value );
         }
      }
      finally
      {
         if ( reader != nullptr )
                  reader->Close();
      }

   }

   static String^ NodeTypeToString( XmlNodeType nodetype )
   {
      String^ sNodeType = nullptr;
      switch ( nodetype )
      {
         case XmlNodeType::None:
            sNodeType = "None";
            break;

         case XmlNodeType::Element:
            sNodeType = "Element";
            break;

         case XmlNodeType::Attribute:
            sNodeType = "Attribute";
            break;

         case XmlNodeType::Text:
            sNodeType = "Text";
            break;

         case XmlNodeType::Comment:
            sNodeType = "Comment";
            break;

         case XmlNodeType::Document:
            sNodeType = "Document";
            break;

         case XmlNodeType::Whitespace:
            sNodeType = "Whitespace";
            break;

         case XmlNodeType::SignificantWhitespace:
            sNodeType = "SignificantWhitespace";
            break;

         case XmlNodeType::EndElement:
            sNodeType = "EndElement";
            break;
      }
      return sNodeType;
   }

};

int main()
{
   gcnew Sample;
}

// </Snippet1>
