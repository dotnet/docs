// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:simpleType name="ZipCodeType">
        XmlSchemaSimpleType ZipCodeType = new XmlSchemaSimpleType();
        ZipCodeType.Name = "ZipCodeType";

        // <xs:restriction base="xs:string">
        XmlSchemaSimpleTypeRestriction restriction = new XmlSchemaSimpleTypeRestriction();
        restriction.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:minLength value="5"/>
        XmlSchemaMinLengthFacet minLength = new XmlSchemaMinLengthFacet();
        minLength.Value = "5";
        restriction.Facets.Add(minLength);

        ZipCodeType.Content = restriction;

        schema.Items.Add(ZipCodeType);

        // <xs:element name="Address">
        XmlSchemaElement element = new XmlSchemaElement();
        element.Name = "Address";

        // <xs:complexType>
        XmlSchemaComplexType complexType = new XmlSchemaComplexType();

        // <xs:attribute name="ZipCode" type="ZipCodeType"/>
        XmlSchemaAttribute ZipCodeAttribute = new XmlSchemaAttribute();
        ZipCodeAttribute.Name = "ZipCode";
        ZipCodeAttribute.SchemaTypeName = new XmlQualifiedName("ZipCodeType", "");
        complexType.Attributes.Add(ZipCodeAttribute);

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