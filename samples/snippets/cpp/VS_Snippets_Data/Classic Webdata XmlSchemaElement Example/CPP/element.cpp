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

        // <xs:element name="cat" type="string"/>
        XmlSchemaElement^ elementCat = gcnew XmlSchemaElement();
        schema->Items->Add(elementCat);
        elementCat->Name = "cat";
        elementCat->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="dog" type="string"/>
        XmlSchemaElement^ elementDog = gcnew XmlSchemaElement();
        schema->Items->Add(elementDog);
        elementDog->Name = "dog";
        elementDog->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:element name="redDog" substitutionGroup="dog" />
        XmlSchemaElement^ elementRedDog = gcnew XmlSchemaElement();
        schema->Items->Add(elementRedDog);
        elementRedDog->Name = "redDog";
        elementRedDog->SubstitutionGroup = gcnew XmlQualifiedName("dog");

        // <xs:element name="brownDog" substitutionGroup ="dog" />
        XmlSchemaElement^ elementBrownDog = gcnew XmlSchemaElement();
        schema->Items->Add(elementBrownDog);
        elementBrownDog->Name = "brownDog";
        elementBrownDog->SubstitutionGroup = gcnew XmlQualifiedName("dog");

        // <xs:element name="pets">
        XmlSchemaElement^ elementPets = gcnew XmlSchemaElement();
        schema->Items->Add(elementPets);
        elementPets->Name = "pets";

        // <xs:complexType>
        XmlSchemaComplexType^ complexType = gcnew XmlSchemaComplexType();
        elementPets->SchemaType = complexType;

        // <xs:choice minOccurs="0" maxOccurs="unbounded">
        XmlSchemaChoice^ choice = gcnew XmlSchemaChoice();
        complexType->Particle = choice;
        choice->MinOccurs = 0;
        choice->MaxOccursString = "unbounded";

        // <xs:element ref="cat"/>
        XmlSchemaElement^ catRef = gcnew XmlSchemaElement();
        choice->Items->Add(catRef);
        catRef->RefName = gcnew XmlQualifiedName("cat");

        // <xs:element ref="dog"/>
        XmlSchemaElement^ dogRef = gcnew XmlSchemaElement();
        choice->Items->Add(dogRef);
        dogRef->RefName = gcnew XmlQualifiedName("dog");

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