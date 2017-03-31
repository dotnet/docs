

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

// This is the class that will be deserialized.
public ref class OrderedItem
{
public:

   [XmlElement(Namespace="http://www.cpandl.com")]
   String^ ItemName;

   [XmlElement(Namespace="http://www.cpandl.com")]
   String^ Description;

   [XmlElement(Namespace="http://www.cohowinery.com")]
   Decimal UnitPrice;

   [XmlElement(Namespace="http://www.cpandl.com")]
   int Quantity;

   [XmlElement(Namespace="http://www.cohowinery.com")]
   Decimal LineTotal;

   // A custom method used to calculate price per item.
   void Calculate()
   {
      LineTotal = UnitPrice * Quantity;
   }
};

void DeserializeObject(String^ filename)
{
	Console::WriteLine("Reading with Stream");

	// Create an instance of the XmlSerializer.
	XmlSerializer^ serializer = gcnew XmlSerializer(OrderedItem::typeid);

	// Declare an object variable of the type to be deserialized.
	OrderedItem^ i;
	
	// Reading the XML document requires a FileStream.
	Stream^ reader = gcnew FileStream(filename, FileMode::Open);

	try
	{
		// Call the Deserialize method to restore the object's state.
		i = dynamic_cast<OrderedItem^>(serializer->Deserialize(reader));
	}
	finally
	{
		delete reader;
	}

	// Write out the properties of the object.
	Console::Write("{0}\t{1}\t{2}\t{3}\t{4}", i->ItemName, i->Description, i->UnitPrice, i->Quantity, i->LineTotal);
}

int main()
{
   // Read a purchase order.
   DeserializeObject( "simple.xml" );
}
// </Snippet1>
