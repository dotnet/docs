

//<snippet1>
#using <System.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Data;
using namespace System::Xml;
int main()
{
   // Create an XmlDataDocument.
   XmlDataDocument^ doc = gcnew XmlDataDocument;

   // Load the schema file.
   doc->DataSet->ReadXmlSchema( "store.xsd" );

   // Load the XML data.
   XmlTextReader^ reader = gcnew XmlTextReader( "2books.xml" );
   reader->MoveToContent(); // Moves the reader to the root node.
   doc->Load( reader );

   // Update the price on the first book using the DataSet methods.
   DataTable^ books = doc->DataSet->Tables["book"];
   books->Rows[0]["price"] = "12.95";
   Console::WriteLine( "Display the modified XML data..." );
   doc->Save( Console::Out );
}

//</snippet1>
