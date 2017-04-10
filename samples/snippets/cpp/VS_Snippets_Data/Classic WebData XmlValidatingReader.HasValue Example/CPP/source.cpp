

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the validating reader.
   XmlTextReader^ txtreader = gcnew XmlTextReader( "book1.xml" );
   txtreader->WhitespaceHandling = WhitespaceHandling::None;
   XmlValidatingReader^ reader = gcnew XmlValidatingReader( txtreader );
   reader->ValidationType = ValidationType::None;
   
   //Parse the file and each node and its value.
   while ( reader->Read() )
   {
      if ( reader->HasValue )
            Console::WriteLine( "({0})  {1}={2}", reader->NodeType, reader->Name, reader->Value );
      else
            Console::WriteLine( "({0}) {1}", reader->NodeType, reader->Name );
   }

   
   //Close the reader.
   reader->Close();
}

// </Snippet1>
