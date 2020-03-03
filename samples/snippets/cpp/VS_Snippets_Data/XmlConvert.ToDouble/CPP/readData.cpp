

//<snippet1>
#using <System.dll>
#using <System.xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextReader^ reader = gcnew XmlTextReader( "orderData.xml" );
   
   //Parse the file and pull out the order date and price.
   while ( reader->Read() )
   {
      if ( reader->NodeType == XmlNodeType::Element )
      {
         if ( reader->Name->Equals( "order" ) )
         {
            DateTime orderDate = XmlConvert::ToDateTime( reader->GetAttribute( "date" ) );
            Console::WriteLine( "order date: {0}", orderDate.ToString() );
         }
         else
         if ( reader->Name->Equals( "price" ) )
         {
            Double price = XmlConvert::ToDouble( reader->ReadInnerXml() );
            Console::WriteLine( "price: {0}", price );
         }
      }
   }

   
   //Close the reader.
   reader->Close();
}

//</snippet1>
