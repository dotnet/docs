// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:simpleType name="OrderQuantityType">
        XmlSchemaSimpleType OrderQuantityType = new XmlSchemaSimpleType();
        OrderQuantityType.Name = "OrderQuantityType";

        // <xs:restriction base="xs:int">
        XmlSchemaSimpleTypeRestriction restriction = new XmlSchemaSimpleTypeRestriction();
        restriction.BaseTypeName = new XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema");

        // <xs:minInclusive value="5"/>
        XmlSchemaMinInclusiveFacet minInclusive = new XmlSchemaMinInclusiveFacet();
        minInclusive.Value = "5";
        restriction.Facets.Add(minInclusive);

        OrderQuantityType.Content = restriction;

        schema.Items.Add(OrderQuantityType);

        // <xs:element name="item">
        XmlSchemaElement element = new XmlSchemaElement();
        element.Name = "item";

        // <xs:complexType>
        XmlSchemaComplexType complexType = new XmlSchemaComplexType();

        // <xs:attribute name="OrderQuantity" type="OrderQuantityType"/>
        XmlSchemaAttribute OrderQuantityAttribute = new XmlSchemaAttribute();
        OrderQuantityAttribute.Name = "OrderQuantity";
        OrderQuantityAttribute.SchemaTypeName = new XmlQualifiedName("OrderQuantityType", "");
        complexType.Attributes.Add(OrderQuantityAttribute);

        element.SchemaType = complexType;

        schema.Items.Add(element);

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