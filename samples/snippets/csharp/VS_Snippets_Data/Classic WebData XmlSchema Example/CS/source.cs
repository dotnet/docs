// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:element name="cat" type="xs:string"/>
        XmlSchemaElement elementCat = new XmlSchemaElement();
        schema.Items.Add(elementCat);
        elementCat.Name = "cat";
        elementCat.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="dog" type="xs:string"/>
        XmlSchemaElement elementDog = new XmlSchemaElement();
        schema.Items.Add(elementDog);
        elementDog.Name = "dog";
        elementDog.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="redDog" substitutionGroup="dog" />
        XmlSchemaElement elementRedDog = new XmlSchemaElement();
        schema.Items.Add(elementRedDog);
        elementRedDog.Name = "redDog";
        elementRedDog.SubstitutionGroup = new XmlQualifiedName("dog");

        // <xs:element name="brownDog" substitutionGroup ="dog" />
        XmlSchemaElement elementBrownDog = new XmlSchemaElement();
        schema.Items.Add(elementBrownDog);
        elementBrownDog.Name = "brownDog";
        elementBrownDog.SubstitutionGroup = new XmlQualifiedName("dog");


        // <xs:element name="pets">
        XmlSchemaElement elementPets = new XmlSchemaElement();
        schema.Items.Add(elementPets);
        elementPets.Name = "pets";

        // <xs:complexType>
        XmlSchemaComplexType complexType = new XmlSchemaComplexType();
        elementPets.SchemaType = complexType;

        // <xs:choice minOccurs="0" maxOccurs="unbounded">
        XmlSchemaChoice choice = new XmlSchemaChoice();
        complexType.Particle = choice;
        choice.MinOccurs = 0;
        choice.MaxOccursString = "unbounded";

        // <xs:element ref="cat"/>
        XmlSchemaElement catRef = new XmlSchemaElement();
        choice.Items.Add(catRef);
        catRef.RefName = new XmlQualifiedName("cat");

        // <xs:element ref="dog"/>
        XmlSchemaElement dogRef = new XmlSchemaElement();
        choice.Items.Add(dogRef);
        dogRef.RefName = new XmlQualifiedName("dog");

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

