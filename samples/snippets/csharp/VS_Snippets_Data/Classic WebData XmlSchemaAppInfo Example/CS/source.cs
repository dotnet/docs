// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:element name="State">
        XmlSchemaElement element = new XmlSchemaElement();
        schema.Items.Add(element);
        element.Name = "State";

        // <xs:annotation>
        XmlSchemaAnnotation annNorthwestStates = new XmlSchemaAnnotation();
        element.Annotation = annNorthwestStates;

        // <xs:documentation>State Name</xs:documentation>
        XmlSchemaDocumentation docNorthwestStates = new XmlSchemaDocumentation();
        annNorthwestStates.Items.Add(docNorthwestStates);
        docNorthwestStates.Markup = TextToNodeArray("State Name");

        // <xs:appInfo>Application Information</xs:appInfo>
        XmlSchemaAppInfo appInfo = new XmlSchemaAppInfo();
        annNorthwestStates.Items.Add(appInfo);
        appInfo.Markup = TextToNodeArray("Application Information");

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

    public static XmlNode[] TextToNodeArray(string text)
    {
        XmlDocument doc = new XmlDocument();
        return new XmlNode[1] { doc.CreateTextNode(text) };
    }
}
// </Snippet1>

