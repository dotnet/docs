

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create the reader.
   XmlTextReader^ txtreader = gcnew XmlTextReader( "book4.xml" );
   XmlValidatingReader^ reader = gcnew XmlValidatingReader( txtreader );
   reader->MoveToContent();
   
   // Display each of the attribute nodes, including default attributes.
   while ( reader->MoveToNextAttribute() )
   {
      if ( reader->IsDefault )
            Console::Write( "(default attribute) " );

      Console::WriteLine( " {0} = {1}", reader->Name, reader->Value );
   }

   
   // Close the reader.
   reader->Close();
}

//</snippet1>
