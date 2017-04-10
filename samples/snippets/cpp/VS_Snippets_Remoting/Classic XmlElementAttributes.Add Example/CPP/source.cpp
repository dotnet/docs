#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Truck{
   // Class added so sample will compile
};

public ref class Train{
   // Class added so sample will compile
};

public ref class Transportation{
   // Class added so sample will compile
};

public ref class Sample
{
   // <Snippet1>
public:
   XmlSerializer^ CreateOverrider()
   {
      // Create XmlAttributes and XmlAttributeOverrides instances.

      XmlAttributes^ attrs = gcnew XmlAttributes;
      XmlAttributeOverrides^ xOver =
         gcnew XmlAttributeOverrides;

      /* Create an XmlElementAttributes to override 
            the Vehicles property. */
      XmlElementAttribute^ xElement1 =
         gcnew XmlElementAttribute( Truck::typeid );
      // Add the XmlElementAttribute to the collection.
      attrs->XmlElements->Add( xElement1 );

      /* Create a second XmlElementAttribute, and 
            add to the collection. */
      XmlElementAttribute^ xElement2 =
         gcnew XmlElementAttribute( Train::typeid );
      attrs->XmlElements->Add( xElement2 );

      /* Add the XmlAttributes to the XmlAttributeOverrides,
            specifying the member to override. */
      xOver->Add( Transportation::typeid, "Vehicles", attrs );

      // Create the XmlSerializer, and return it.
      XmlSerializer^ xSer = gcnew XmlSerializer(
         Transportation::typeid,xOver );
      return xSer;
   }
   // </Snippet1>
};
