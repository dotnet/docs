

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   String^ filename = "items.xml";
   XmlNodeReader^ reader = nullptr;
   try
   {
      
      //Create an XmlNodeReader to read the XmlDocument.
      XmlDocument^ doc = gcnew XmlDocument;
      doc->Load( filename );
      reader = gcnew XmlNodeReader( doc );
      
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
               Console::Write( reader->Value );
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
