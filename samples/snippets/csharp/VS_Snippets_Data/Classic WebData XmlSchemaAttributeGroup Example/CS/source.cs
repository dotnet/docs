// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:attributeGroup name="myAttributeGroup">
        XmlSchemaAttributeGroup myAttributeGroup = new XmlSchemaAttributeGroup();
        schema.Items.Add(myAttributeGroup);
        myAttributeGroup.Name = "myAttributeGroup";

        // <xs:attribute name="someattribute1" type="xs:integer"/>
        XmlSchemaAttribute someattribute1 = new XmlSchemaAttribute();
        myAttributeGroup.Attributes.Add(someattribute1);
        someattribute1.Name = "someattribute1";
        someattribute1.SchemaTypeName = new XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema");


        // <xs:attribute name="someattribute2" type="xs:string"/>
        XmlSchemaAttribute someattribute2 = new XmlSchemaAttribute();
        myAttributeGroup.Attributes.Add(someattribute2);
        someattribute2.Name = "someattribute2";
        someattribute2.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:complexType name="myElementType">
        XmlSchemaComplexType myElementType = new XmlSchemaComplexType();
        schema.Items.Add(myElementType);
        myElementType.Name = "myElementType";

        // <xs:attributeGroup ref="myAttributeGroup"/>
        XmlSchemaAttributeGroupRef myAttributeGroupRef = new XmlSchemaAttributeGroupRef();
        myElementType.Attributes.Add(myAttributeGroupRef);
        myAttributeGroupRef.RefName = new XmlQualifiedName("myAttributeGroup");

        // <xs:attributeGroup name="myAttributeGroupA">
        XmlSchemaAttributeGroup myAttributeGroupA = new XmlSchemaAttributeGroup();
        schema.Items.Add(myAttributeGroupA);
        myAttributeGroupA.Name = "myAttributeGroupA";

        // <xs:attribute name="someattribute10" type="xs:integer"/>
        XmlSchemaAttribute someattribute10 = new XmlSchemaAttribute();
        myAttributeGroupA.Attributes.Add(someattribute10);
        someattribute10.Name = "someattribute10";
        someattribute10.SchemaTypeName = new XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema");

        // <xs:attribute name="someattribute11" type="xs:string"/>
        XmlSchemaAttribute someattribute11 = new XmlSchemaAttribute();
        myAttributeGroupA.Attributes.Add(someattribute11);
        someattribute11.Name = "someattribute11";
        someattribute11.SchemaTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:attributeGroup name="myAttributeGroupB">
        XmlSchemaAttributeGroup myAttributeGroupB = new XmlSchemaAttributeGroup();
        schema.Items.Add(myAttributeGroupB);
        myAttributeGroupB.Name = "myAttributeGroupB";

        // <xs:attribute name="someattribute20" type="xs:date"/>
        XmlSchemaAttribute someattribute20 = new XmlSchemaAttribute();
        myAttributeGroupB.Attributes.Add(someattribute20);
        someattribute20.Name = "someattribute20";
        someattribute20.SchemaTypeName = new XmlQualifiedName("date", "http://www.w3.org/2001/XMLSchema");

        // <xs:attributeGroup ref="myAttributeGroupA"/>
        XmlSchemaAttributeGroupRef myAttributeGroupRefA = new XmlSchemaAttributeGroupRef();
        myAttributeGroupB.Attributes.Add(myAttributeGroupRefA);
        myAttributeGroupRefA.RefName = new XmlQualifiedName("myAttributeGroupA");

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

