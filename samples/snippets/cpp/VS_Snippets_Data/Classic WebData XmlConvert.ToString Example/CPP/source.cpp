

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Define the order data.  They will be converted to string 
   //before being written out.
   Int16 custID = 32632;
   String^ orderID = "367A54";
   DateTime orderDate = DateTime::Now;
   Double price = 19.95;
   
   //Create a writer that outputs to the console.
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );
   writer->Formatting = Formatting::Indented;
   
   //Write an element (this one is the root)
   writer->WriteStartElement( "order" );
   
   //Write the order date.
   writer->WriteAttributeString( "date", XmlConvert::ToString( orderDate, "yyyy-MM-dd" ) );
   
   //Write the order time.
   writer->WriteAttributeString( "time", XmlConvert::ToString( orderDate, "HH:mm:ss" ) );
   
   //Write the order data.
   writer->WriteElementString( "orderID", orderID );
   writer->WriteElementString( "custID", XmlConvert::ToString( custID ) );
   writer->WriteElementString( "price", XmlConvert::ToString( price ) );
   
   //Write the close tag for the root element
   writer->WriteEndElement();
   
   //Write the XML and close the writer
   writer->Close();
}

// </Snippet1>
