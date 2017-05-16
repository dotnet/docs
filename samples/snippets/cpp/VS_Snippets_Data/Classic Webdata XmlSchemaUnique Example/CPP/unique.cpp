//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XMLSchemaExamples
{
private:
	static void ValidationCallbackOne(Object^ sender, ValidationEventArgs^ args)
    {
		Console::WriteLine(args->Message);
    }

public:
    static void Main()
    {
        XmlSchema^ schema = gcnew XmlSchema();

        // <xs:complexType name="customerOrderType">
        XmlSchemaComplexType^ customerOrderType = gcnew XmlSchemaComplexType();
        customerOrderType->Name = "customerOrderType";

        // <xs:sequence>
        XmlSchemaSequence^ sequence1 = gcnew XmlSchemaSequence();

        // <xs:element name="item" minOccurs="0" maxOccurs="unbounded">
        XmlSchemaElement^ item = gcnew XmlSchemaElement();
        item->MinOccurs = 0;
        item->MaxOccursString = "unbounded";
        item->Name = "item";

        // <xs:complexType>
        XmlSchemaComplexType^ ct1 = gcnew XmlSchemaComplexType();

        // <xs:attribute name="itemID" type="xs:string"/>
        XmlSchemaAttribute^ itemID = gcnew XmlSchemaAttribute();
        itemID->Name = "itemID";
        itemID->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // </xs:complexType>
        ct1->Attributes->Add(itemID);

        // </xs:element>
        item->SchemaType = ct1;

        // </xs:sequence>
        sequence1->Items->Add(item);
        customerOrderType->Particle = sequence1;

        // <xs:attribute name="CustomerID" type="xs:string"/>
        XmlSchemaAttribute^ CustomerID = gcnew XmlSchemaAttribute();
        CustomerID->Name = "CustomerID";
        CustomerID->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        customerOrderType->Attributes->Add(CustomerID);

        // </xs:complexType>
        schema->Items->Add(customerOrderType);

        // <xs:element name="ordersByCustomer">
        XmlSchemaElement^ ordersByCustomer = gcnew XmlSchemaElement();
        ordersByCustomer->Name = "ordersByCustomer";

        // <xs:complexType>
        XmlSchemaComplexType^ ct2 = gcnew XmlSchemaComplexType();

        // <xs:sequence>
        XmlSchemaSequence^ sequence2 = gcnew XmlSchemaSequence();

        // <xs:element name="customerOrders" type="customerOrderType" minOccurs="0" maxOccurs="unbounded" />
        XmlSchemaElement^ customerOrders = gcnew XmlSchemaElement();
        customerOrders->MinOccurs = 0;
        customerOrders->MaxOccursString = "unbounded";
        customerOrders->Name = "customerOrders";
        customerOrders->SchemaTypeName = gcnew XmlQualifiedName("customerOrderType", "");

        // </xs:sequence>
        sequence2->Items->Add(customerOrders);

        // </xs:complexType>
        ct2->Particle = sequence2;
        ordersByCustomer->SchemaType = ct2;

        // <xs:unique name="oneCustomerOrdersforEachCustomerID">
        XmlSchemaUnique^ element_unique = gcnew XmlSchemaUnique();
        element_unique->Name = "oneCustomerOrdersforEachCustomerID";

        // <xs:selector xpath="customerOrders"/>
        element_unique->Selector = gcnew XmlSchemaXPath();
        element_unique->Selector->XPath = "customerOrders";

        // <xs:field xpath="@customerID"/>
        XmlSchemaXPath^ field = gcnew XmlSchemaXPath();
        field->XPath = "@customerID";

        // </xs:unique>
        element_unique->Fields->Add(field);
        ordersByCustomer->Constraints->Add(element_unique);

        // </xs:element>
        schema->Items->Add(ordersByCustomer);

        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallbackOne);
        schemaSet->Add(schema);
        schemaSet->Compile();

        XmlSchema^ compiledSchema = nullptr;

        for each (XmlSchema^ schema1 in schemaSet->Schemas())
        {
            compiledSchema = schema1;
        }

        XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager(gcnew NameTable());
        nsmgr->AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
		compiledSchema->Write(Console::Out, nsmgr);
    }
};

int main()
{
	XMLSchemaExamples::Main();
	return 0;
}
//</snippet1>