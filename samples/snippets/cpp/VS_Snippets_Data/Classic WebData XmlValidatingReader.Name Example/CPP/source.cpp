

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextReader^ txtreader = nullptr;
   XmlValidatingReader^ reader = nullptr;
   String^ filename = "items.xml";
   try
   {
      
      //Load the reader with the data file and ignore all white space nodes.         
      txtreader = gcnew XmlTextReader( filename );
      txtreader->WhitespaceHandling = WhitespaceHandling::None;
      
      //Implement the validating reader over the text reader. 
      reader = gcnew XmlValidatingReader( txtreader );
      reader->ValidationType = ValidationType::None;
      
      //Parse the file and display each of the nodes.
      while ( reader->Read() )
      {
         switch ( reader->NodeType )
         {
            case XmlNodeType::Element:
               Console::Write( "<{0}>", reader->Name );
               break;

            case XmlNodeType::Text:
               Console::Write( reader->Value );
               break;

            case XmlNodeType::CDATA:
               Console::Write( "<![CDATA[{0}]]>", reader->Value );
               break;

            case XmlNodeType::ProcessingInstruction:
               Console::Write( "<?{0} {1}?>", reader->Name, reader->Value );
               break;

            case XmlNodeType::Comment:
               Console::Write( "<!--{0}-->", reader->Value );
               break;

            case XmlNodeType::XmlDeclaration:
               Console::Write( "<?xml version='1.0'?>" );
               break;

            case XmlNodeType::Document:
               break;

            case XmlNodeType::DocumentType:
               Console::Write( "<!DOCTYPE {0} [{1}]", reader->Name, reader->Value );
               break;

            case XmlNodeType::EntityReference:
               Console::Write( reader->Name );
               break;

            case XmlNodeType::EndElement:
               Console::Write( "</{0}>", reader->Name );
               break;
         }
      }
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
