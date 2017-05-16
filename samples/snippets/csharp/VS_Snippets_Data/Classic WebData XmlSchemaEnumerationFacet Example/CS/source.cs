// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:simpleType name="SizeType">
        XmlSchemaSimpleType SizeType = new XmlSchemaSimpleType();
        SizeType.Name = "SizeType";

        // <xs:restriction base="xs:string">
        XmlSchemaSimpleTypeRestriction restriction = new XmlSchemaSimpleTypeRestriction();
        restriction.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:enumeration value="Small"/>
        XmlSchemaEnumerationFacet enumerationSmall = new XmlSchemaEnumerationFacet();
        enumerationSmall.Value = "Small";
        restriction.Facets.Add(enumerationSmall);

        // <xs:enumeration value="Medium"/>
        XmlSchemaEnumerationFacet enumerationMedium = new XmlSchemaEnumerationFacet();
        enumerationMedium.Value = "Medium";
        restriction.Facets.Add(enumerationMedium);

        // <xs:enumeration value="Large"/>
        XmlSchemaEnumerationFacet enumerationLarge = new XmlSchemaEnumerationFacet();
        enumerationLarge.Value = "Large";
        restriction.Facets.Add(enumerationLarge);

        SizeType.Content = restriction;

        schema.Items.Add(SizeType);

        // <xs:element name="Item">
        XmlSchemaElement elementItem = new XmlSchemaElement();
        elementItem.Name = "Item";

        // <xs:complexType>
        XmlSchemaComplexType complexType = new XmlSchemaComplexType();

        // <xs:attribute name="Size" type="SizeType"/>
        XmlSchemaAttribute attributeSize = new XmlSchemaAttribute();
        attributeSize.Name = "Size";
        attributeSize.SchemaTypeName = new XmlQualifiedName("SizeType", "");
        complexType.Attributes.Add(attributeSize);

        elementItem.SchemaType = complexType;

        schema.Items.Add(elementItem);

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

