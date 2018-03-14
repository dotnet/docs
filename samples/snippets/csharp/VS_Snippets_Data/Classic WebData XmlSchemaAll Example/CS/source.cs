// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

public class Sample
{
    public static void Main()
    {
        XmlSchema schema = new XmlSchema();

        XmlSchemaElement thing1 = new XmlSchemaElement();
        thing1.Name = "thing1";
        thing1.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        schema.Items.Add(thing1);

        XmlSchemaElement thing2 = new XmlSchemaElement();
        thing2.Name = "thing2";
        thing2.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        schema.Items.Add(thing2);

        XmlSchemaElement thing3 = new XmlSchemaElement();
        thing3.Name = "thing3";
        thing3.SchemaTypeName =
        new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        schema.Items.Add(thing3);

        XmlSchemaElement thing4 = new XmlSchemaElement();
        thing4.Name = "thing4";
        thing4.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        schema.Items.Add(thing4);

        XmlSchemaAttribute myAttribute = new XmlSchemaAttribute();
        myAttribute.Name = "myAttribute";
        myAttribute.SchemaTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");
        schema.Items.Add(myAttribute);

        XmlSchemaComplexType myComplexType = new XmlSchemaComplexType();
        myComplexType.Name = "myComplexType";

        XmlSchemaAll complexType_all = new XmlSchemaAll();

        XmlSchemaElement complexType_all_thing1 = new XmlSchemaElement();
        complexType_all_thing1.RefName = new XmlQualifiedName("thing1", "");
        complexType_all.Items.Add(complexType_all_thing1);

        XmlSchemaElement complexType_all_thing2 = new XmlSchemaElement();
        complexType_all_thing2.RefName = new XmlQualifiedName("thing2", "");
        complexType_all.Items.Add(complexType_all_thing2);

        XmlSchemaElement complexType_all_thing3 = new XmlSchemaElement();
        complexType_all_thing3.RefName = new XmlQualifiedName("thing3", "");
        complexType_all.Items.Add(complexType_all_thing3);

        XmlSchemaElement complexType_all_thing4 = new XmlSchemaElement();
        complexType_all_thing4.RefName = new XmlQualifiedName("thing4", "");
        complexType_all.Items.Add(complexType_all_thing4);

        myComplexType.Particle = complexType_all;

        XmlSchemaAttribute complexType_myAttribute = new XmlSchemaAttribute();
        complexType_myAttribute.RefName = new XmlQualifiedName("myAttribute", "");
        myComplexType.Attributes.Add(complexType_myAttribute);

        schema.Items.Add(myComplexType);

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

    private static void ValidationCallbackOne(object sender, ValidationEventArgs args)
    {
        Console.WriteLine(args.Message);
    }

}
// </Snippet1>