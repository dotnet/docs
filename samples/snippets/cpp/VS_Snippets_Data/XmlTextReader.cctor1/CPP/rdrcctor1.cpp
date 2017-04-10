

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   String^ xmlData = "<book>\r\n       <title>Oberon's Legacy</title>\r\n       <price>5.95</price>\r\n      </book>";
   
   // Create the reader.
   XmlTextReader^ reader = gcnew XmlTextReader( gcnew StringReader( xmlData ) );
   reader->WhitespaceHandling = WhitespaceHandling::None;
   
   // Display each element node.
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

         case XmlNodeType::EndElement:
            Console::Write( "</{0}>", reader->Name );
            break;
      }
   }

   
   // Close the reader.
   reader->Close();
}

//</snippet1>
