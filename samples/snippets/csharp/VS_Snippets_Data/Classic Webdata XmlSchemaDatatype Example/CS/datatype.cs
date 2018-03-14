// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {
        XmlTextReader xtr = new XmlTextReader("example.xsd");
        XmlSchema schema = XmlSchema.Read(xtr, new ValidationEventHandler(ValidationCallbackOne));

        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallbackOne);
        schemaSet.Add(schema);
        schemaSet.Compile();

        XmlSchema compiledSchema = null;

        foreach (XmlSchema schema1 in schemaSet.Schemas())
        {
            compiledSchema = schema1;
        }



        foreach (XmlSchemaObject schemaObject in compiledSchema.Items)
        {
            if (schemaObject.GetType() == typeof(XmlSchemaSimpleType))
            {
                XmlSchemaSimpleType simpleType = (XmlSchemaSimpleType)schemaObject;
                Console.WriteLine("{0} {1}", simpleType.Name, simpleType.Datatype.ValueType);
            }
            if (schemaObject.GetType() == typeof(XmlSchemaComplexType))
            {
                XmlSchemaComplexType complexType = (XmlSchemaComplexType)schemaObject;
                Console.WriteLine("{0} {1}", complexType.Name, complexType.Datatype.ValueType);
            }
        }
        xtr.Close();
    }

    public static void ValidationCallbackOne(object sender, ValidationEventArgs args)
    {
        Console.WriteLine(args.Message);
    }
}
// </Snippet1>

