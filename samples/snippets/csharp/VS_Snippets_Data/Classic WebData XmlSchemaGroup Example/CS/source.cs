// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:element name="thing1" type="xs:string"/>
        XmlSchemaElement elementThing1 = new XmlSchemaElement();
        schema.Items.Add(elementThing1);
        elementThing1.Name = "thing1";
        elementThing1.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="thing2" type="xs:string"/>
        XmlSchemaElement elementThing2 = new XmlSchemaElement();
        schema.Items.Add(elementThing2);
        elementThing2.Name = "thing2";
        elementThing2.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="thing3" type="xs:string"/>
        XmlSchemaElement elementThing3 = new XmlSchemaElement();
        schema.Items.Add(elementThing3);
        elementThing3.Name = "thing3";
        elementThing3.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:attribute name="myAttribute" type="xs:decimal"/>
        XmlSchemaAttribute myAttribute = new XmlSchemaAttribute();
        schema.Items.Add(myAttribute);
        myAttribute.Name = "myAttribute";
        myAttribute.SchemaTypeName = new XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");

        // <xs:group name="myGroupOfThings">
        XmlSchemaGroup myGroupOfThings = new XmlSchemaGroup();
        schema.Items.Add(myGroupOfThings);
        myGroupOfThings.Name = "myGroupOfThings";

        // <xs:sequence>
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        myGroupOfThings.Particle = sequence;

        // <xs:element ref="thing1"/>
        XmlSchemaElement elementThing1Ref = new XmlSchemaElement();
        sequence.Items.Add(elementThing1Ref);
        elementThing1Ref.RefName = new XmlQualifiedName("thing1");

        // <xs:element ref="thing2"/>
        XmlSchemaElement elementThing2Ref = new XmlSchemaElement();
        sequence.Items.Add(elementThing2Ref);
        elementThing2Ref.RefName = new XmlQualifiedName("thing2");

        // <xs:element ref="thing3"/>
        XmlSchemaElement elementThing3Ref = new XmlSchemaElement();
        sequence.Items.Add(elementThing3Ref);
        elementThing3Ref.RefName = new XmlQualifiedName("thing3");

        // <xs:complexType name="myComplexType">
        XmlSchemaComplexType myComplexType = new XmlSchemaComplexType();
        schema.Items.Add(myComplexType);
        myComplexType.Name = "myComplexType";

        // <xs:group ref="myGroupOfThings"/>
        XmlSchemaGroupRef myGroupOfThingsRef = new XmlSchemaGroupRef();
        myComplexType.Particle = myGroupOfThingsRef;
        myGroupOfThingsRef.RefName = new XmlQualifiedName("myGroupOfThings");

        // <xs:attribute ref="myAttribute"/>
        XmlSchemaAttribute myAttributeRef = new XmlSchemaAttribute();
        myComplexType.Attributes.Add(myAttributeRef);
        myAttributeRef.RefName = new XmlQualifiedName("myAttribute");

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

