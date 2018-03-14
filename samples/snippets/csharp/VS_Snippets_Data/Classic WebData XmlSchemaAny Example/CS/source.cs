// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <element name='htmlText'>
        XmlSchemaElement xeHtmlText = new XmlSchemaElement();
        xeHtmlText.Name = "htmlText";

        // <complexType>
        XmlSchemaComplexType ct = new XmlSchemaComplexType();

        // <sequence>
        XmlSchemaSequence sequence = new XmlSchemaSequence();

        // <any namespace='http://www.w3.org/1999/xhtml'
        //    minOccurs='1' maxOccurs='unbounded'
        //    processContents='lax'/>
        XmlSchemaAny any = new XmlSchemaAny();
        any.MinOccurs = 1;
        any.MaxOccursString = "unbounded";
        any.Namespace = "http://www.w3.org/1999/xhtml";
        any.ProcessContents = XmlSchemaContentProcessing.Lax;
        sequence.Items.Add(any);

        ct.Particle = sequence;
        xeHtmlText.SchemaType = ct;

        schema.Items.Add(xeHtmlText);

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
        schema.Write(Console.Out, nsmgr);
    }

    public static void ValidationCallbackOne(object sender, ValidationEventArgs args)
    {
        Console.WriteLine(args.Message);
    }
}
// </Snippet1>

