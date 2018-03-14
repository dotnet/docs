//<snippet1>
#using <mscorlib.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

class XmlSchemaExamples
{
public:
	
	static void Main()
    {
        XmlSchema^ schema = gcnew XmlSchema();

        // <xs:attributeGroup name="myAttributeGroup">
        XmlSchemaAttributeGroup^ myAttributeGroup = gcnew XmlSchemaAttributeGroup();
        schema->Items->Add(myAttributeGroup);
        myAttributeGroup->Name = "myAttributeGroup";

        // <xs:attribute name="someattribute1" type="xs:integer"/>
        XmlSchemaAttribute^ someattribute1 = gcnew XmlSchemaAttribute();
        myAttributeGroup->Attributes->Add(someattribute1);
        someattribute1->Name = "someattribute1";
        someattribute1->SchemaTypeName = gcnew XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema");


        // <xs:attribute name="someattribute2" type="xs:string"/>
        XmlSchemaAttribute^ someattribute2 = gcnew XmlSchemaAttribute();
        myAttributeGroup->Attributes->Add(someattribute2);
        someattribute2->Name = "someattribute2";
        someattribute2->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:complexType name="myElementType">
        XmlSchemaComplexType^ myElementType = gcnew XmlSchemaComplexType();
        schema->Items->Add(myElementType);
        myElementType->Name = "myElementType";

        // <xs:attributeGroup ref="myAttributeGroup"/>
        XmlSchemaAttributeGroupRef^ myAttributeGroupRef = gcnew XmlSchemaAttributeGroupRef();
        myElementType->Attributes->Add(myAttributeGroupRef);
        myAttributeGroupRef->RefName = gcnew XmlQualifiedName("myAttributeGroup");

        // <xs:attributeGroup name="myAttributeGroupA">
        XmlSchemaAttributeGroup^ myAttributeGroupA = gcnew XmlSchemaAttributeGroup();
        schema->Items->Add(myAttributeGroupA);
        myAttributeGroupA->Name = "myAttributeGroupA";

        // <xs:attribute name="someattribute10" type="xs:integer"/>
        XmlSchemaAttribute^ someattribute10 = gcnew XmlSchemaAttribute();
        myAttributeGroupA->Attributes->Add(someattribute10);
        someattribute10->Name = "someattribute10";
        someattribute10->SchemaTypeName = gcnew XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema");

        // <xs:attribute name="someattribute11" type="xs:string"/>
        XmlSchemaAttribute^ someattribute11 = gcnew XmlSchemaAttribute();
        myAttributeGroupA->Attributes->Add(someattribute11);
        someattribute11->Name = "someattribute11";
        someattribute11->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:attributeGroup name="myAttributeGroupB">
        XmlSchemaAttributeGroup^ myAttributeGroupB = gcnew XmlSchemaAttributeGroup();
        schema->Items->Add(myAttributeGroupB);
        myAttributeGroupB->Name = "myAttributeGroupB";

        // <xs:attribute name="someattribute20" type="xs:date"/>
        XmlSchemaAttribute^ someattribute20 = gcnew XmlSchemaAttribute();
        myAttributeGroupB->Attributes->Add(someattribute20);
        someattribute20->Name = "someattribute20";
        someattribute20->SchemaTypeName = gcnew XmlQualifiedName("date", "http://www.w3.org/2001/XMLSchema");

        // <xs:attributeGroup ref="myAttributeGroupA"/>
        XmlSchemaAttributeGroupRef^ myAttributeGroupRefA = gcnew XmlSchemaAttributeGroupRef();
        myAttributeGroupB->Attributes->Add(myAttributeGroupRefA);
        myAttributeGroupRefA->RefName = gcnew XmlQualifiedName("myAttributeGroupA");

        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallbackOne);
        schemaSet->Add(schema);
        schemaSet->Compile();

        XmlSchema^ compiledSchema;

        for each (XmlSchema^ schema1 in schemaSet->Schemas())
        {
            compiledSchema = schema1;
        }

        XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager(gcnew NameTable());
        nsmgr->AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
		compiledSchema->Write(Console::Out, nsmgr);
    }

    static void ValidationCallbackOne(Object^ sender, ValidationEventArgs^ args)
    {
		Console::WriteLine(args->Message);
    }
};

int main()
{
	XmlSchemaExamples::Main();
    return 0;
};
//</snippet1>
