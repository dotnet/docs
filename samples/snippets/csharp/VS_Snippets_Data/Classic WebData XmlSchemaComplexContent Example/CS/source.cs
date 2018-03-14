// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:complexType name="address">
        XmlSchemaComplexType address = new XmlSchemaComplexType();
        schema.Items.Add(address);
        address.Name = "address";

        // <xs:sequence>
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        address.Particle = sequence;

        // <xs:element name="name"   type="xs:string"/>
        XmlSchemaElement elementName = new XmlSchemaElement();
        sequence.Items.Add(elementName);
        elementName.Name = "name";
        elementName.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="street"   type="xs:string"/>
        XmlSchemaElement elementStreet = new XmlSchemaElement();
        sequence.Items.Add(elementStreet);
        elementStreet.Name = "street";
        elementStreet.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="city"   type="xs:string"/>
        XmlSchemaElement elementCity = new XmlSchemaElement();
        sequence.Items.Add(elementCity);
        elementCity.Name = "city";
        elementCity.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:complexType name="USAddress">
        XmlSchemaComplexType USAddress = new XmlSchemaComplexType();
        schema.Items.Add(USAddress);
        USAddress.Name = "USAddress";

        // <xs:complexContent>
        XmlSchemaComplexContent complexContent = new XmlSchemaComplexContent();
        USAddress.ContentModel = complexContent;

        // <xs:extension base="address">
        XmlSchemaComplexContentExtension extensionAddress = new XmlSchemaComplexContentExtension();
        complexContent.Content = extensionAddress;
        extensionAddress.BaseTypeName = new XmlQualifiedName("address");

        // <xs:sequence>
        XmlSchemaSequence sequence2 = new XmlSchemaSequence();
        extensionAddress.Particle = sequence2;

        // <xs:element name="state" type="xs:string"/>
        XmlSchemaElement elementUSState = new XmlSchemaElement();
        sequence2.Items.Add(elementUSState);
        elementUSState.Name = "state";
        elementUSState.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");


        // <xs:element name="zipcode" type="xs:positiveInteger"/>
        XmlSchemaElement elementZipcode = new XmlSchemaElement();
        sequence2.Items.Add(elementZipcode);
        elementZipcode.Name = "zipcode";
        elementZipcode.SchemaTypeName = new XmlQualifiedName("positiveInteger", "http://www.w3.org/2001/XMLSchema");

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

