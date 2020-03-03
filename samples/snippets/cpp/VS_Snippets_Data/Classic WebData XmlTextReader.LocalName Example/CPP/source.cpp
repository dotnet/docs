

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
      
      // Load the reader with the XML file.
      reader = gcnew XmlTextReader( "book2.xml" );
      
      // Parse the file.  If they exist, display the prefix and 
      // namespace URI of each node.
      while ( reader->Read() )
      {
         if ( reader->IsStartElement() )
         {
            if ( reader->Prefix == String::Empty )
                        Console::WriteLine( "<{0}>", reader->LocalName );
            else
            {
               Console::Write( "<{0}:{1}>", reader->Prefix, reader->LocalName );
               Console::WriteLine( " The namespace URI is {0}", reader->NamespaceURI );
            }
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
