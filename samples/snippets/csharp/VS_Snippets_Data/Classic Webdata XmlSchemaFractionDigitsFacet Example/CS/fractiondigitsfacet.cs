// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:simpleType name="RatingType">
        XmlSchemaSimpleType RatingType = new XmlSchemaSimpleType();
        RatingType.Name = "RatingType";

        // <xs:restriction base="xs:number">
        XmlSchemaSimpleTypeRestriction restriction = new XmlSchemaSimpleTypeRestriction();
        restriction.BaseTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");

        // <xs:totalDigits value="2"/>
        XmlSchemaTotalDigitsFacet totalDigits = new XmlSchemaTotalDigitsFacet();
        totalDigits.Value = "2";
        restriction.Facets.Add(totalDigits);

        // <xs:fractionDigits value="1"/>
        XmlSchemaFractionDigitsFacet fractionDigits = new XmlSchemaFractionDigitsFacet();
        fractionDigits.Value = "1";
        restriction.Facets.Add(fractionDigits);

        RatingType.Content = restriction;

        schema.Items.Add(RatingType);

        // <xs:element name="movie">
        XmlSchemaElement element = new XmlSchemaElement();
        element.Name = "movie";

        // <xs:complexType>
        XmlSchemaComplexType complexType = new XmlSchemaComplexType();

        // <xs:attribute name="rating" type="RatingType"/>
        XmlSchemaAttribute ratingAttribute = new XmlSchemaAttribute();
        ratingAttribute.Name = "rating";
        ratingAttribute.SchemaTypeName = new XmlQualifiedName("RatingType", "");
        complexType.Attributes.Add(ratingAttribute);

        element.SchemaType = complexType;

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