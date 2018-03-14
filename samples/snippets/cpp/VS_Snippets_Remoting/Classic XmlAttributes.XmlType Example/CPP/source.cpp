

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
public ref class Car
{
public:
   int ID;
};

public ref class Transportation
{
public:
   array<Car^>^Cars;
};

// Return an XmlSerializer used for overriding.
XmlSerializer^ CreateOverrider()
{
   // Create the XmlAttributes and XmlAttributeOverrides objects.
   XmlAttributes^ attrs = gcnew XmlAttributes;
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;

   /* Create an XmlTypeAttribute and change the name of the 
      XML type. */
   XmlTypeAttribute^ xType = gcnew XmlTypeAttribute;
   xType->TypeName = "Autos";

   // Set the XmlTypeAttribute to the XmlType property.
   attrs->XmlType = xType;

   /* Add the XmlAttributes to the XmlAttributeOverrides,
      specifying the member to override. */
   xOver->Add( Car::typeid, attrs );

   // Create the XmlSerializer, and return it.
   XmlSerializer^ xSer = gcnew XmlSerializer( Transportation::typeid,xOver );
   return xSer;
}

void SerializeObject( String^ filename )
{
   // Create an XmlSerializer instance.
   XmlSerializer^ xSer = CreateOverrider();

   // Create object and serialize it.
   Transportation^ myTransportation = gcnew Transportation;
   Car^ c1 = gcnew Car;
   c1->ID = 12;
   Car^ c2 = gcnew Car;
   c2->ID = 44;
   array<Car^>^temp0 = {c1,c2};
   myTransportation->Cars = temp0;

   // To write the file, a TextWriter is required.
   TextWriter^ writer = gcnew StreamWriter( filename );
   xSer->Serialize( writer, myTransportation );
}

int main()
{
   SerializeObject( "XmlType.xml" );
}
// </Snippet1>
