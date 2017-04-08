// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Xsl;
using namespace System::Xml::Schema;
public ref class XmlSchemaObjectGenerator
{
private:
    static void ValidationCallback( Object^ /*sender*/, ValidationEventArgs^ args )
    {
        if ( args->Severity == XmlSeverityType::Warning )
            Console::Write( "WARNING: " );
        else
            if ( args->Severity == XmlSeverityType::Error )
                Console::Write( "ERROR: " );

        Console::WriteLine( args->Message );
    }

    // XmlSchemaObjectGenerator
    int main()
    {
        XmlTextReader^ tr = gcnew XmlTextReader( "empty.xsd" );
        XmlSchema^ schema = XmlSchema::Read( tr, gcnew ValidationEventHandler( XmlSchemaObjectGenerator::ValidationCallback ) );
        schema->ElementFormDefault = XmlSchemaForm::Qualified;
        schema->TargetNamespace = "http://www.example.com/Report";
        {
            XmlSchemaElement^ element = gcnew XmlSchemaElement;
            element->Name = "purchaseReport";
            XmlSchemaComplexType^ element_complexType = gcnew XmlSchemaComplexType;
            XmlSchemaSequence^ element_complexType_sequence = gcnew XmlSchemaSequence;
            {
                XmlSchemaElement^ element_complexType_sequence_element = gcnew XmlSchemaElement;
                element_complexType_sequence_element->Name = "region";
                element_complexType_sequence_element->SchemaTypeName = gcnew XmlQualifiedName( "String*","http://www.w3.org/2001/XMLSchema" );
                {
                    XmlSchemaKeyref^ element_complexType_sequence_element_keyref = gcnew XmlSchemaKeyref;
                    element_complexType_sequence_element_keyref->Name = "dummy2";
                    element_complexType_sequence_element_keyref->Selector = gcnew XmlSchemaXPath;
                    element_complexType_sequence_element_keyref->Selector->XPath = "r:zip/r:part";
                    {
                        XmlSchemaXPath^ field = gcnew XmlSchemaXPath;
                        field->XPath = "@number";
                        element_complexType_sequence_element_keyref->Fields->Add( field );
                    }
                    element_complexType_sequence_element_keyref->Refer = gcnew XmlQualifiedName( "pNumKey","http://www.example.com/Report" );
                    element_complexType_sequence_element->Constraints->Add( element_complexType_sequence_element_keyref );
                }
                element_complexType_sequence->Items->Add( element_complexType_sequence_element );
            }
            element_complexType->Particle = element_complexType_sequence;
            {
                XmlSchemaAttribute^ element_complexType_attribute = gcnew XmlSchemaAttribute;
                element_complexType_attribute->Name = "periodEnding";
                element_complexType_attribute->SchemaTypeName = gcnew XmlQualifiedName( "date","http://www.w3.org/2001/XMLSchema" );
                element_complexType->Attributes->Add( element_complexType_attribute );
            }
            element->SchemaType = element_complexType;
            {
                XmlSchemaKey^ element_key = gcnew XmlSchemaKey;
                element_key->Name = "pNumKey";
                element_key->Selector = gcnew XmlSchemaXPath;
                element_key->Selector->XPath = "r:parts/r:part";
                {
                    XmlSchemaXPath^ field = gcnew XmlSchemaXPath;
                    field->XPath = "@number";
                    element_key->Fields->Add( field );
                }
                element->Constraints->Add( element_key );
            }
            schema->Items->Add( element );
        }
        schema->Write( Console::Out );

        return 0;
    } // main
};
// </Snippet1>
