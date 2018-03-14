// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        //<xs:simpleType name="StringOrIntType">
        XmlSchemaSimpleType StringOrIntType = new XmlSchemaSimpleType();
        StringOrIntType.Name = "StringOrIntType";
        schema.Items.Add(StringOrIntType);

        // <xs:union>
        XmlSchemaSimpleTypeUnion union = new XmlSchemaSimpleTypeUnion();
        StringOrIntType.Content = union;

        // <xs:simpleType>
        XmlSchemaSimpleType simpleType1 = new XmlSchemaSimpleType();
        union.BaseTypes.Add(simpleType1);

        // <xs:restriction base="xs:string"/>
        XmlSchemaSimpleTypeRestriction restriction1 = new XmlSchemaSimpleTypeRestriction();
        restriction1.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        simpleType1.Content = restriction1;

        // <xs:simpleType>
        XmlSchemaSimpleType simpleType2 = new XmlSchemaSimpleType();
        union.BaseTypes.Add(simpleType2);

        // <xs:restriction base="xs:int"/>
        XmlSchemaSimpleTypeRestriction restriction2 = new XmlSchemaSimpleTypeRestriction();
        restriction2.BaseTypeName = new XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema");
        simpleType2.Content = restriction2;


        // <xs:element name="size" type="StringOrIntType"/>
        XmlSchemaElement elementSize = new XmlSchemaElement();
        elementSize.Name = "size";
        elementSize.SchemaTypeName = new XmlQualifiedName("StringOrIntType");
        schema.Items.Add(elementSize);

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