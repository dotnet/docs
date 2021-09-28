

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Xml::Serialization;

// This is the class that will be deserialized.
public ref class OrderedItem
{
public:
    String^ ItemName;
    String^ Description;
    Decimal UnitPrice;
    int Quantity;
    Decimal LineTotal;

    // A custom method used to calculate price per item.
    void Calculate()
    {
        LineTotal = UnitPrice * Quantity;
    }
};

void DeserializeObject( String^ filename )
{
    Console::WriteLine( "Reading with TextReader" );

    // Create an instance of the XmlSerializer specifying type.
    XmlSerializer^ serializer = gcnew XmlSerializer( OrderedItem::typeid );

    /* Create a TextReader to read the file. Specify an
       Encoding to use. */
    TextReader^ reader = gcnew StreamReader( filename,Encoding::Unicode );

    // Declare an object variable of the type to be deserialized.
    OrderedItem^ i;

    // Use the Deserialize method to restore the object's state.
    i = dynamic_cast<OrderedItem^>(serializer->Deserialize( reader ));

    // Write out the properties of the object.
    Console::Write( "{0}\t{1}\t{2}\t{3}\t{4}", i->ItemName, i->Description, i->UnitPrice, i->Quantity, i->LineTotal );
}

int main()
{
    // Read a purchase order.
    DeserializeObject( "simple.xml" );
}
// </Snippet1>
