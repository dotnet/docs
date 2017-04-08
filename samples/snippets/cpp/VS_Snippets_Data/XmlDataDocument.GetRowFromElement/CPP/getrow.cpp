

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
   doc->Load( "2books.xml" );

   //Change the price on the first book.
   XmlElement^ root = doc->DocumentElement;
   DataRow^ row = doc->GetRowFromElement( safe_cast<XmlElement^>(root->FirstChild) );
   row["price"] = "12.95";
   Console::WriteLine( "Display the modified XML data..." );
   Console::WriteLine( doc->DocumentElement->OuterXml );
}
//</snippet1>
