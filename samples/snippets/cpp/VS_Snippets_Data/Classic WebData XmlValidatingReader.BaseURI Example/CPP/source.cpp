

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlValidatingReader^ reader = nullptr;
   XmlTextReader^ txtreader = nullptr;
   try
   {
      
      //Create the validating reader.
      txtreader = gcnew XmlTextReader( "http://localhost/uri.xml" );
      reader = gcnew XmlValidatingReader( txtreader );
      reader->ValidationType = ValidationType::None;
      
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
