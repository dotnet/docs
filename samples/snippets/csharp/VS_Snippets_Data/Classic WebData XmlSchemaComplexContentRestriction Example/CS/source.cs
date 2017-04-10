// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:complexType name="phoneNumber">
        XmlSchemaComplexType phoneNumber = new XmlSchemaComplexType();
        phoneNumber.Name = "phoneNumber";

        // <xs:sequence>
        XmlSchemaSequence phoneNumberSequence = new XmlSchemaSequence();

        // <xs:element name="areaCode"/>
        XmlSchemaElement areaCode1 = new XmlSchemaElement();
        areaCode1.MinOccurs = 0;
        areaCode1.MaxOccursString = "1";
        areaCode1.Name = "areaCode";
        phoneNumberSequence.Items.Add(areaCode1);

        // <xs:element name="prefix"/>
        XmlSchemaElement prefix1 = new XmlSchemaElement();
        prefix1.MinOccurs = 1;
        prefix1.MaxOccursString = "1";
        prefix1.Name = "prefix";
        phoneNumberSequence.Items.Add(prefix1);

        // <xs:element name="number"/>
        XmlSchemaElement number1 = new XmlSchemaElement();
        number1.MinOccurs = 1;
        number1.MaxOccursString = "1";
        number1.Name = "number";
        phoneNumberSequence.Items.Add(number1);

        phoneNumber.Particle = phoneNumberSequence;

        schema.Items.Add(phoneNumber);

        // <xs:complexType name="localPhoneNumber">
        XmlSchemaComplexType localPhoneNumber = new XmlSchemaComplexType();
        localPhoneNumber.Name = "localPhoneNumber";

        // <xs:complexContent>
        XmlSchemaComplexContent complexContent = new XmlSchemaComplexContent();

        // <xs:restriction base="phoneNumber">
        XmlSchemaComplexContentRestriction restriction = new XmlSchemaComplexContentRestriction();
        restriction.BaseTypeName = new XmlQualifiedName("phoneNumber", "");

        // <xs:sequence>
        XmlSchemaSequence sequence2 = new XmlSchemaSequence();

        // <xs:element name="areaCode" minOccurs="0"/>
        XmlSchemaElement areaCode2 = new XmlSchemaElement();
        areaCode2.MinOccurs = 0;
        areaCode2.MaxOccursString = "1";
        areaCode2.Name = "areaCode";
        sequence2.Items.Add(areaCode2);

        // <xs:element name="prefix"/>
        XmlSchemaElement prefix2 = new XmlSchemaElement();
        prefix2.MinOccurs = 1;
        prefix2.MaxOccursString = "1";
        prefix2.Name = "prefix";
        sequence2.Items.Add(prefix2);

        // <xs:element name="number"/>
        XmlSchemaElement number2 = new XmlSchemaElement();
        number2.MinOccurs = 1;
        number2.MaxOccursString = "1";
        number2.Name = "number";
        sequence2.Items.Add(number2);

        restriction.Particle = sequence2;
        complexContent.Content = restriction;
        localPhoneNumber.ContentModel = complexContent;

        schema.Items.Add(localPhoneNumber);

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

