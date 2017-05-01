

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
      
      //Create and load an XmlDocument.
      XmlDocument^ doc = gcnew XmlDocument;
      doc->Load( "http://localhost/uri.xml" );
      reader = gcnew XmlNodeReader( doc );
      
      //Parse the file and display the base URI for each node.
      while ( reader->Read() )
      {
         Console::WriteLine( "({0}) {1}", reader->NodeType, reader->BaseURI );
      }
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
