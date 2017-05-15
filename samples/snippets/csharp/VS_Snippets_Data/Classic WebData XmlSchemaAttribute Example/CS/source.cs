// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:attribute name="mybaseattribute">
        XmlSchemaAttribute attributeBase = new XmlSchemaAttribute();
        schema.Items.Add(attributeBase);
        attributeBase.Name = "mybaseattribute";

        // <xs:simpleType>
        XmlSchemaSimpleType simpleType = new XmlSchemaSimpleType();
        attributeBase.SchemaType = simpleType;

        // <xs:restriction base="integer">
        XmlSchemaSimpleTypeRestriction restriction = new XmlSchemaSimpleTypeRestriction();
        simpleType.Content = restriction;
        restriction.BaseTypeName = new XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema");

        // <xs:maxInclusive value="1000"/>
        XmlSchemaMaxInclusiveFacet maxInclusive = new XmlSchemaMaxInclusiveFacet();
        restriction.Facets.Add(maxInclusive);
        maxInclusive.Value = "1000";

        // <xs:complexType name="myComplexType">
        XmlSchemaComplexType complexType = new XmlSchemaComplexType();
        schema.Items.Add(complexType);
        complexType.Name = "myComplexType";

        // <xs:attribute ref="mybaseattribute"/>
        XmlSchemaAttribute attributeBaseRef = new XmlSchemaAttribute();
        complexType.Attributes.Add(attributeBaseRef);
        attributeBaseRef.RefName = new XmlQualifiedName("mybaseattribute");

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

