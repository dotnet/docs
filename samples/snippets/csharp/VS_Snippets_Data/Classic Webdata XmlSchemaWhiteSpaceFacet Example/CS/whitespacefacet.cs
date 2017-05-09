// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:simpleType name="NameType">
        XmlSchemaSimpleType NameType = new XmlSchemaSimpleType();
        NameType.Name = "NameType";

        // <xs:restriction base="xs:string">
        XmlSchemaSimpleTypeRestriction restriction = new XmlSchemaSimpleTypeRestriction();
        restriction.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:whiteSpace value="collapse"/>
        XmlSchemaWhiteSpaceFacet whiteSpace = new XmlSchemaWhiteSpaceFacet();
        whiteSpace.Value = "collapse";
        restriction.Facets.Add(whiteSpace);

        NameType.Content = restriction;

        schema.Items.Add(NameType);

        // <xs:element name="LastName" type="NameType"/>
        XmlSchemaElement element = new XmlSchemaElement();
        element.Name = "LastName";
        element.SchemaTypeName = new XmlQualifiedName("NameType", "");

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