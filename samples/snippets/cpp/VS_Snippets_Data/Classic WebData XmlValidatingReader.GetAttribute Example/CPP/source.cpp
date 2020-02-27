

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
   
   //Read the ISBN attribute.
   reader->MoveToContent();
   String^ isbn = reader->GetAttribute( "ISBN" );
   Console::WriteLine( "The ISBN value: {0}", isbn );
   
   //Close the reader.
   reader->Close();
}

// </Snippet1>
