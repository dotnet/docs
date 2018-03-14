// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:simpleType name="WaitQueueLengthType">
        XmlSchemaSimpleType WaitQueueLengthType = new XmlSchemaSimpleType();
        WaitQueueLengthType.Name = "WaitQueueLengthType";

        // <xs:restriction base="xs:int">
        XmlSchemaSimpleTypeRestriction restriction = new XmlSchemaSimpleTypeRestriction();
        restriction.BaseTypeName = new XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema");

        // <xs:maxExclusive value="5"/>
        XmlSchemaMaxExclusiveFacet maxExclusive = new XmlSchemaMaxExclusiveFacet();
        maxExclusive.Value = "5";
        restriction.Facets.Add(maxExclusive);

        WaitQueueLengthType.Content = restriction;

        schema.Items.Add(WaitQueueLengthType);

        // <xs:element name="Lobby">
        XmlSchemaElement element = new XmlSchemaElement();
        element.Name = "Lobby";

        // <xs:complexType>
        XmlSchemaComplexType complexType = new XmlSchemaComplexType();

        // <xs:attribute name="WaitQueueLength" type="WaitQueueLengthType"/>
        XmlSchemaAttribute WaitQueueLengthAttribute = new XmlSchemaAttribute();
        WaitQueueLengthAttribute.Name = "WaitQueueLength";
        WaitQueueLengthAttribute.SchemaTypeName = new XmlQualifiedName("WaitQueueLengthType", "");
        complexType.Attributes.Add(WaitQueueLengthAttribute);

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