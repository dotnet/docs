

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the validating reader.
   XmlTextReader^ txtreader = gcnew XmlTextReader( "attrs.xml" );
   XmlValidatingReader^ reader = gcnew XmlValidatingReader( txtreader );
   
   //Read the genre attribute.
   reader->MoveToContent();
   reader->MoveToFirstAttribute();
   String^ genre = reader->Value;
   Console::WriteLine( "The genre value: {0}", genre );
   
   //Close the reader.
   reader->Close();
}

// </Snippet1>
