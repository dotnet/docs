

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
      
      // Create and load an XmlDocument.
      XmlDocument^ doc = gcnew XmlDocument;
      doc->LoadXml( "<?xml version='1.0' ?>"
      "<!DOCTYPE book [<!ENTITY h 'hardcover'>]>"
      "<book>"
      "<title>Pride And Prejudice</title>"
      "<misc>&h;</misc>"
      "</book>" );
      reader = gcnew XmlNodeReader( doc );
      
      // Parse the file and display each node.
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
