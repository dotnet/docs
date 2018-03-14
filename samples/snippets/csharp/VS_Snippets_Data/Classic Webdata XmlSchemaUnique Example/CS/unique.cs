// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:complexType name="customerOrderType">
        XmlSchemaComplexType customerOrderType = new XmlSchemaComplexType();
        customerOrderType.Name = "customerOrderType";

        // <xs:sequence>
        XmlSchemaSequence sequence1 = new XmlSchemaSequence();

        // <xs:element name="item" minOccurs="0" maxOccurs="unbounded">
        XmlSchemaElement item = new XmlSchemaElement();
        item.MinOccurs = 0;
        item.MaxOccursString = "unbounded";
        item.Name = "item";

        // <xs:complexType>
        XmlSchemaComplexType ct1 = new XmlSchemaComplexType();

        // <xs:attribute name="itemID" type="xs:string"/>
        XmlSchemaAttribute itemID = new XmlSchemaAttribute();
        itemID.Name = "itemID";
        itemID.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // </xs:complexType>
        ct1.Attributes.Add(itemID);

        // </xs:element>
        item.SchemaType = ct1;

        // </xs:sequence>
        sequence1.Items.Add(item);
        customerOrderType.Particle = sequence1;

        // <xs:attribute name="CustomerID" type="xs:string"/>
        XmlSchemaAttribute CustomerID = new XmlSchemaAttribute();
        CustomerID.Name = "CustomerID";
        CustomerID.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        customerOrderType.Attributes.Add(CustomerID);

        // </xs:complexType>
        schema.Items.Add(customerOrderType);

        // <xs:element name="ordersByCustomer">
        XmlSchemaElement ordersByCustomer = new XmlSchemaElement();
        ordersByCustomer.Name = "ordersByCustomer";

        // <xs:complexType>
        XmlSchemaComplexType ct2 = new XmlSchemaComplexType();

        // <xs:sequence>
        XmlSchemaSequence sequence2 = new XmlSchemaSequence();

        // <xs:element name="customerOrders" type="customerOrderType" minOccurs="0" maxOccurs="unbounded" />
        XmlSchemaElement customerOrders = new XmlSchemaElement();
        customerOrders.MinOccurs = 0;
        customerOrders.MaxOccursString = "unbounded";
        customerOrders.Name = "customerOrders";
        customerOrders.SchemaTypeName = new XmlQualifiedName("customerOrderType", "");

        // </xs:sequence>
        sequence2.Items.Add(customerOrders);

        // </xs:complexType>
        ct2.Particle = sequence2;
        ordersByCustomer.SchemaType = ct2;

        // <xs:unique name="oneCustomerOrdersforEachCustomerID">
        XmlSchemaUnique element_unique = new XmlSchemaUnique();
        element_unique.Name = "oneCustomerOrdersforEachCustomerID";

        // <xs:selector xpath="customerOrders"/>
        element_unique.Selector = new XmlSchemaXPath();
        element_unique.Selector.XPath = "customerOrders";

        // <xs:field xpath="@customerID"/>
        XmlSchemaXPath field = new XmlSchemaXPath();
        field.XPath = "@customerID";

        // </xs:unique>
        element_unique.Fields.Add(field);
        ordersByCustomer.Constraints.Add(element_unique);

        // </xs:element>
        schema.Items.Add(ordersByCustomer);

        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallbackOne);
        schemaSet.Add(schema);
        schemaSet.Compile();

        XmlSchema compiledSchema = null;

        foreach (XmlSchema schema1 in schemaSet.Schemas())
        {
            compiledSchema = schema1;
        }

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
        nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
        compiledSchema.Write(Console.Out, nsmgr);
    }

    public static void ValidationCallbackOne(object sender, ValidationEventArgs args)
    {
        Console.WriteLine(args.Message);
    }
}
// </Snippet1>