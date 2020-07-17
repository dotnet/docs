

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::IO;
ref class Address;
ref class OrderedItem;

/* The XmlRootAttribute allows you to set an alternate name 
   (PurchaseOrder) of the XML element, the element namespace; by 
   default, the XmlSerializer uses the class name. The attribute 
   also allows you to set the XML namespace for the element.  Lastly,
   the attribute sets the IsNullable property, which specifies whether 
   the xsi:null attribute appears if the class instance is set to 
   a null reference. */

[XmlRootAttribute("PurchaseOrder",Namespace="http://www.cpandl.com",
IsNullable=false)]
public ref class PurchaseOrder
{
public:
   Address^ ShipTo;
   String^ OrderDate;

   /* The XmlArrayAttribute changes the XML element name
       from the default of "OrderedItems" to "Items". */

   [XmlArrayAttribute("Items")]
   array<OrderedItem^>^OrderedItems;
   Decimal SubTotal;
   Decimal ShipCost;
   Decimal TotalCost;
};

public ref class Address
{
public:

   /* The XmlAttribute instructs the XmlSerializer to serialize the Name
         field as an XML attribute instead of an XML element (the default
         behavior). */

   [XmlAttributeAttribute]
   String^ Name;
   String^ Line1;

   /* Setting the IsNullable property to false instructs the 
         XmlSerializer that the XML attribute will not appear if 
         the City field is set to a null reference. */

   [XmlElementAttribute(IsNullable=false)]
   String^ City;
   String^ State;
   String^ Zip;
};

public ref class OrderedItem
{
public:
   String^ ItemName;
   String^ Description;
   Decimal UnitPrice;
   int Quantity;
   Decimal LineTotal;

   /* Calculate is a custom method that calculates the price per item,
         and stores the value in a field. */
   void Calculate()
   {
      LineTotal = UnitPrice * Quantity;
   }

};

public ref class Test
{
public:
   static void main()
   {
      // Read and write purchase orders.
      Test^ t = gcnew Test;
      t->CreatePO( "po.xml" );
      t->ReadPO( "po.xml" );
   }

private:
   void CreatePO( String^ filename )
   {
      // Create an instance of the XmlSerializer class;
      // specify the type of object to serialize.
      XmlSerializer^ serializer = gcnew XmlSerializer( PurchaseOrder::typeid );
      TextWriter^ writer = gcnew StreamWriter( filename );
      PurchaseOrder^ po = gcnew PurchaseOrder;

      // Create an address to ship and bill to.
      Address^ billAddress = gcnew Address;
      billAddress->Name = "Teresa Atkinson";
      billAddress->Line1 = "1 Main St.";
      billAddress->City = "AnyTown";
      billAddress->State = "WA";
      billAddress->Zip = "00000";

      // Set ShipTo and BillTo to the same addressee.
      po->ShipTo = billAddress;
      po->OrderDate = System::DateTime::Now.ToLongDateString();

      // Create an OrderedItem object.
      OrderedItem^ i1 = gcnew OrderedItem;
      i1->ItemName = "Widget S";
      i1->Description = "Small widget";
      i1->UnitPrice = (Decimal)5.23;
      i1->Quantity = 3;
      i1->Calculate();

      // Insert the item into the array.
      array<OrderedItem^>^items = {i1};
      po->OrderedItems = items;

      // Calculate the total cost.
      Decimal subTotal = Decimal(0);
      System::Collections::IEnumerator^ myEnum = items->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         OrderedItem^ oi = safe_cast<OrderedItem^>(myEnum->Current);
         subTotal = subTotal + oi->LineTotal;
      }

      po->SubTotal = subTotal;
      po->ShipCost = (Decimal)12.51;
      po->TotalCost = po->SubTotal + po->ShipCost;

      // Serialize the purchase order, and close the TextWriter.
      serializer->Serialize( writer, po );
      writer->Close();
   }

protected:
   void ReadPO( String^ filename )
   {
      // Create an instance of the XmlSerializer class;
      // specify the type of object to be deserialized.
      XmlSerializer^ serializer = gcnew XmlSerializer( PurchaseOrder::typeid );

      /* If the XML document has been altered with unknown 
            nodes or attributes, handle them with the 
            UnknownNode and UnknownAttribute events.*/
      serializer->UnknownNode += gcnew XmlNodeEventHandler( this, &Test::serializer_UnknownNode );
      serializer->UnknownAttribute += gcnew XmlAttributeEventHandler( this, &Test::serializer_UnknownAttribute );

      // A FileStream is needed to read the XML document.
      FileStream^ fs = gcnew FileStream( filename,FileMode::Open );

      // Declare an object variable of the type to be deserialized.
      PurchaseOrder^ po;

      /* Use the Deserialize method to restore the object's state with
            data from the XML document. */
      po = dynamic_cast<PurchaseOrder^>(serializer->Deserialize( fs ));

      // Read the order date.
      Console::WriteLine( "OrderDate: {0}", po->OrderDate );

      // Read the shipping address.
      Address^ shipTo = po->ShipTo;
      ReadAddress( shipTo, "Ship To:" );

      // Read the list of ordered items.
      array<OrderedItem^>^items = po->OrderedItems;
      Console::WriteLine( "Items to be shipped:" );
      System::Collections::IEnumerator^ myEnum1 = items->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         OrderedItem^ oi = safe_cast<OrderedItem^>(myEnum1->Current);
         Console::WriteLine( "\t{0}\t{1}\t{2}\t{3}\t{4}", oi->ItemName, oi->Description, oi->UnitPrice, oi->Quantity, oi->LineTotal );
      }

      Console::WriteLine( "\t\t\t\t\t Subtotal\t{0}", po->SubTotal );
      Console::WriteLine( "\t\t\t\t\t Shipping\t{0}", po->ShipCost );
      Console::WriteLine( "\t\t\t\t\t Total\t\t{0}", po->TotalCost );
   }

   void ReadAddress( Address^ a, String^ label )
   {
      // Read the fields of the Address object.
      Console::WriteLine( label );
      Console::WriteLine( "\t{0}", a->Name );
      Console::WriteLine( "\t{0}", a->Line1 );
      Console::WriteLine( "\t{0}", a->City );
      Console::WriteLine( "\t{0}", a->State );
      Console::WriteLine( "\t{0}", a->Zip );
      Console::WriteLine();
   }

private:
   void serializer_UnknownNode( Object^ /*sender*/, XmlNodeEventArgs^ e )
   {
      Console::WriteLine( "Unknown Node:{0}\t{1}", e->Name, e->Text );
   }

   void serializer_UnknownAttribute( Object^ /*sender*/, XmlAttributeEventArgs^ e )
   {
      System::Xml::XmlAttribute^ attr = e->Attr;
      Console::WriteLine( "Unknown attribute {0}='{1}'", attr->Name, attr->Value );
   }
};

int main()
{
   Test::main();
}
// </Snippet1>
