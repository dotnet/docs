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

        XmlSchemaElement^ thing1 = gcnew XmlSchemaElement();
        thing1->Name = "thing1";
        thing1->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        schema->Items->Add(thing1);

        XmlSchemaElement^ thing2 = gcnew XmlSchemaElement();
        thing2->Name = "thing2";
        thing2->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        schema->Items->Add(thing2);

        XmlSchemaElement^ thing3 = gcnew XmlSchemaElement();
        thing3->Name = "thing3";
        thing3->SchemaTypeName =
        gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        schema->Items->Add(thing3);

        XmlSchemaElement^ thing4 = gcnew XmlSchemaElement();
        thing4->Name = "thing4";
        thing4->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        schema->Items->Add(thing4);

        XmlSchemaAttribute^ myAttribute = gcnew XmlSchemaAttribute();
        myAttribute->Name = "myAttribute";
        myAttribute->SchemaTypeName = gcnew XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");
        schema->Items->Add(myAttribute);

        XmlSchemaComplexType^ myComplexType = gcnew XmlSchemaComplexType();
        myComplexType->Name = "myComplexType";

        XmlSchemaAll^ complexType_all = gcnew XmlSchemaAll();

        XmlSchemaElement^ complexType_all_thing1 = gcnew XmlSchemaElement();
        complexType_all_thing1->RefName = gcnew XmlQualifiedName("thing1", "");
        complexType_all->Items->Add(complexType_all_thing1);

        XmlSchemaElement^ complexType_all_thing2 = gcnew XmlSchemaElement();
        complexType_all_thing2->RefName = gcnew XmlQualifiedName("thing2", "");
        complexType_all->Items->Add(complexType_all_thing2);

        XmlSchemaElement^ complexType_all_thing3 = gcnew XmlSchemaElement();
        complexType_all_thing3->RefName = gcnew XmlQualifiedName("thing3", "");
        complexType_all->Items->Add(complexType_all_thing3);

        XmlSchemaElement^ complexType_all_thing4 = gcnew XmlSchemaElement();
        complexType_all_thing4->RefName = gcnew XmlQualifiedName("thing4", "");
        complexType_all->Items->Add(complexType_all_thing4);

        myComplexType->Particle = complexType_all;

        XmlSchemaAttribute^ complexType_myAttribute = gcnew XmlSchemaAttribute();
        complexType_myAttribute->RefName = gcnew XmlQualifiedName("myAttribute", "");
        myComplexType->Attributes->Add(complexType_myAttribute);

        schema->Items->Add(myComplexType);

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