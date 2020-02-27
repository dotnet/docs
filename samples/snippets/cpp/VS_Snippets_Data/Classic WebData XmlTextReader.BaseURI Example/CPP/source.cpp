

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextReader^ reader = nullptr;
   try
   {
      
      //Load the reader with the XML file.
      reader = gcnew XmlTextReader( "http://localhost/baseuri.xml" );
      
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
