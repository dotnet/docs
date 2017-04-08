// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:simpleType name="northwestStates">
        XmlSchemaSimpleType simpleType = new XmlSchemaSimpleType();
        simpleType.Name = "northwestStates";
        schema.Items.Add(simpleType);

        // <xs:annotation>
        XmlSchemaAnnotation annNorthwestStates = new XmlSchemaAnnotation();
        simpleType.Annotation = annNorthwestStates;

        // <xs:documentation>States in the Pacific Northwest of US</xs:documentation>
        XmlSchemaDocumentation docNorthwestStates = new XmlSchemaDocumentation();
        annNorthwestStates.Items.Add(docNorthwestStates);
        docNorthwestStates.Markup = TextToNodeArray("States in the Pacific Northwest of US");

        // <xs:restriction base="xs:string">
        XmlSchemaSimpleTypeRestriction restriction = new XmlSchemaSimpleTypeRestriction();
        simpleType.Content = restriction;
        restriction.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:enumeration value='WA'>
        XmlSchemaEnumerationFacet enumerationWA = new XmlSchemaEnumerationFacet();
        restriction.Facets.Add(enumerationWA);
        enumerationWA.Value = "WA";

        // <xs:annotation>
        XmlSchemaAnnotation annWA = new XmlSchemaAnnotation();
        enumerationWA.Annotation = annWA;

        // <xs:documentation>Washington</documentation>
        XmlSchemaDocumentation docWA = new XmlSchemaDocumentation();
        annWA.Items.Add(docWA);
        docWA.Markup = TextToNodeArray("Washington");

        // <xs:enumeration value='OR'>
        XmlSchemaEnumerationFacet enumerationOR = new XmlSchemaEnumerationFacet();
        restriction.Facets.Add(enumerationOR);
        enumerationOR.Value = "OR";

        // <xs:annotation>
        XmlSchemaAnnotation annOR = new XmlSchemaAnnotation();
        enumerationOR.Annotation = annOR;

        // <xs:documentation>Oregon</xs:documentation>
        XmlSchemaDocumentation docOR = new XmlSchemaDocumentation();
        annOR.Items.Add(docOR);
        docOR.Markup = TextToNodeArray("Oregon");

        // <xs:enumeration value='ID'>
        XmlSchemaEnumerationFacet enumerationID = new XmlSchemaEnumerationFacet();

        restriction.Facets.Add(enumerationID);
        enumerationID.Value = "ID";

        // <xs:annotation>
        XmlSchemaAnnotation annID = new XmlSchemaAnnotation();
        enumerationID.Annotation = annID;

        // <xs:documentation>Idaho</xs:documentation>
        XmlSchemaDocumentation docID = new XmlSchemaDocumentation();
        annID.Items.Add(docID);
        docID.Markup = TextToNodeArray("Idaho");

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

