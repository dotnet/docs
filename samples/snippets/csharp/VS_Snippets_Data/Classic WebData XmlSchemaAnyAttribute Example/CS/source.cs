// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <element name="stringElementWithAnyAttribute">
        XmlSchemaElement element = new XmlSchemaElement();
        schema.Items.Add(element);
        element.Name = "stringElementWithAnyAttribute";

        // <complexType>
        XmlSchemaComplexType complexType = new XmlSchemaComplexType();
        element.SchemaType = complexType;

        // <simpleContent>
        XmlSchemaSimpleContent simpleContent = new XmlSchemaSimpleContent();
        complexType.ContentModel = simpleContent;

        // <extension base="xs:string">
        XmlSchemaSimpleContentExtension extension = new XmlSchemaSimpleContentExtension();
        simpleContent.Content = extension;
        extension.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <anyAttribute namespace="##targetNamespace"/>
        XmlSchemaAnyAttribute anyAttribute = new XmlSchemaAnyAttribute();
        extension.AnyAttribute = anyAttribute;
        anyAttribute.Namespace = "##targetNamespace";

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

