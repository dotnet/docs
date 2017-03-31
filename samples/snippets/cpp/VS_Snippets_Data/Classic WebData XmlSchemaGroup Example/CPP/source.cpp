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

        // <xs:element name="thing1" type="xs:string"/>
        XmlSchemaElement^ elementThing1 = gcnew XmlSchemaElement();
        schema->Items->Add(elementThing1);
        elementThing1->Name = "thing1";
        elementThing1->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="thing2" type="xs:string"/>
        XmlSchemaElement^ elementThing2 = gcnew XmlSchemaElement();
        schema->Items->Add(elementThing2);
        elementThing2->Name = "thing2";
        elementThing2->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="thing3" type="xs:string"/>
        XmlSchemaElement^ elementThing3 = gcnew XmlSchemaElement();
        schema->Items->Add(elementThing3);
        elementThing3->Name = "thing3";
        elementThing3->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:attribute name="myAttribute" type="xs:decimal"/>
        XmlSchemaAttribute^ myAttribute = gcnew XmlSchemaAttribute();
        schema->Items->Add(myAttribute);
        myAttribute->Name = "myAttribute";
        myAttribute->SchemaTypeName = gcnew XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");

        // <xs:group name="myGroupOfThings">
        XmlSchemaGroup^ myGroupOfThings = gcnew XmlSchemaGroup();
        schema->Items->Add(myGroupOfThings);
        myGroupOfThings->Name = "myGroupOfThings";

        // <xs:sequence>
        XmlSchemaSequence^ sequence = gcnew XmlSchemaSequence();
        myGroupOfThings->Particle = sequence;

        // <xs:element ref="thing1"/>
        XmlSchemaElement^ elementThing1Ref = gcnew XmlSchemaElement();
        sequence->Items->Add(elementThing1Ref);
        elementThing1Ref->RefName = gcnew XmlQualifiedName("thing1");

        // <xs:element ref="thing2"/>
        XmlSchemaElement^ elementThing2Ref = gcnew XmlSchemaElement();
        sequence->Items->Add(elementThing2Ref);
        elementThing2Ref->RefName = gcnew XmlQualifiedName("thing2");

        // <xs:element ref="thing3"/>
        XmlSchemaElement^ elementThing3Ref = gcnew XmlSchemaElement();
        sequence->Items->Add(elementThing3Ref);
        elementThing3Ref->RefName = gcnew XmlQualifiedName("thing3");

        // <xs:complexType name="myComplexType">
        XmlSchemaComplexType^ myComplexType = gcnew XmlSchemaComplexType();
        schema->Items->Add(myComplexType);
        myComplexType->Name = "myComplexType";

        // <xs:group ref="myGroupOfThings"/>
        XmlSchemaGroupRef^ myGroupOfThingsRef = gcnew XmlSchemaGroupRef();
        myComplexType->Particle = myGroupOfThingsRef;
        myGroupOfThingsRef->RefName = gcnew XmlQualifiedName("myGroupOfThings");

        // <xs:attribute ref="myAttribute"/>
        XmlSchemaAttribute^ myAttributeRef = gcnew XmlSchemaAttribute();
        myComplexType->Attributes->Add(myAttributeRef);
        myAttributeRef->RefName = gcnew XmlQualifiedName("myAttribute");

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