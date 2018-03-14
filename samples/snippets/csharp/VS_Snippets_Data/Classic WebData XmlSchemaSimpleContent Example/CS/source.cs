// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:element name="generalPrice">
        XmlSchemaElement generalPrice = new XmlSchemaElement();
        generalPrice.Name = "generalPrice";

        // <xs:complexType>
        XmlSchemaComplexType ct = new XmlSchemaComplexType();

        // <xs:simpleContent>
        XmlSchemaSimpleContent simpleContent = new XmlSchemaSimpleContent();

        // <xs:extension base="xs:decimal">
        XmlSchemaSimpleContentExtension simpleContent_extension = new XmlSchemaSimpleContentExtension();
        simpleContent_extension.BaseTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");

        // <xs:attribute name="currency" type="xs:string" />
        XmlSchemaAttribute currency = new XmlSchemaAttribute();
        currency.Name = "currency";
        currency.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        simpleContent_extension.Attributes.Add(currency);

        simpleContent.Content = simpleContent_extension;
        ct.ContentModel = simpleContent;
        generalPrice.SchemaType = ct;

        schema.Items.Add(generalPrice);

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

