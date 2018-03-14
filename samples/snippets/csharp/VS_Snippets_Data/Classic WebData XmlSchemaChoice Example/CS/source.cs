// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:element name="selected"/>
        XmlSchemaElement xeSelected = new XmlSchemaElement();
        xeSelected.Name = "selected";
        schema.Items.Add(xeSelected);

        // <xs:element name="unselected"/>
        XmlSchemaElement xeUnselected = new XmlSchemaElement();
        xeUnselected.Name = "unselected";
        schema.Items.Add(xeUnselected);

        // <xs:element name="dimpled"/>
        XmlSchemaElement xeDimpled = new XmlSchemaElement();
        xeDimpled.Name = "dimpled";
        schema.Items.Add(xeDimpled);

        // <xs:element name="perforated"/>
        XmlSchemaElement xePerforated = new XmlSchemaElement();
        xePerforated.Name = "perforated";
        schema.Items.Add(xePerforated);

        // <xs:complexType name="chadState">
        XmlSchemaComplexType chadState = new XmlSchemaComplexType();
        schema.Items.Add(chadState);
        chadState.Name = "chadState";

        // <xs:choice minOccurs="1" maxOccurs="1">
        XmlSchemaChoice choice = new XmlSchemaChoice();
        chadState.Particle = choice;
        choice.MinOccurs = 1;
        choice.MaxOccurs = 1;

        // <xs:element ref="selected"/>
        XmlSchemaElement elementSelected = new XmlSchemaElement();
        choice.Items.Add(elementSelected);
        elementSelected.RefName = new XmlQualifiedName("selected");

        // <xs:element ref="unselected"/>
        XmlSchemaElement elementUnselected = new XmlSchemaElement();
        choice.Items.Add(elementUnselected);
        elementUnselected.RefName = new XmlQualifiedName("unselected");

        // <xs:element ref="dimpled"/>
        XmlSchemaElement elementDimpled = new XmlSchemaElement();
        choice.Items.Add(elementDimpled);
        elementDimpled.RefName = new XmlQualifiedName("dimpled");

        // <xs:element ref="perforated"/>
        XmlSchemaElement elementPerforated = new XmlSchemaElement();
        choice.Items.Add(elementPerforated);
        elementPerforated.RefName = new XmlQualifiedName("perforated");

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

