

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
      reader = gcnew XmlTextReader( "book1.xml" );
      reader->WhitespaceHandling = WhitespaceHandling::None;
      
      //Parse the file and display each node.
      while ( reader->Read() )
      {
         if ( reader->HasValue )
                  Console::WriteLine( "({0})  {1}={2}", reader->NodeType, reader->Name, reader->Value );
         else
                  Console::WriteLine( "({0}) {1}", reader->NodeType, reader->Name );
      }
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
