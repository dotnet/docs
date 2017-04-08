

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
      
      //Create and load the XML document.
      XmlDocument^ doc = gcnew XmlDocument;
      doc->LoadXml( "<!-- sample XML -->"
      "<book>"
      "<title>Pride And Prejudice</title>"
      "<price>19.95</price>"
      "</book>" );
      
      //Load the XmlNodeReader 
      reader = gcnew XmlNodeReader( doc );
      reader->MoveToContent(); //Move to the book node.
      reader->Read(); //Read the book start tag.
      reader->Skip(); //Skip the title element.
      Console::WriteLine( reader->ReadOuterXml() ); //Read the price element.
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
