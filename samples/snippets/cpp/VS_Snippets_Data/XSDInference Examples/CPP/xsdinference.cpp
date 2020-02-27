#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Collections;

namespace XsdInferenceExample
{
    ref class XsdInference
    {
    public:      
        static void XsdInferenceOverallExample()
        {
            //<snippet1>
            XmlReader^ reader1 = XmlReader::Create
				("contosoBooks.xml");
            XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet;
            XmlSchemaInference^ schema = gcnew XmlSchemaInference;
            schemaSet = schema->InferSchema(reader1);                      
            for each (XmlSchema^ currentSchema in schemaSet->Schemas())
            {                
                currentSchema->Write(Console::Out);
            }
            //</snippet1>
         }

        static void XsdInferenceOccurrence()
        {
            //<snippet2>
            XmlReader^ reader2 = XmlReader::Create("input.xml");
            XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet;
            XmlSchemaInference^ schema = gcnew XmlSchemaInference;
            schema->Occurrence = XmlSchemaInference::InferenceOption::Relaxed;
            schemaSet = schema->InferSchema(reader2);
            //</snippet2>
        }

        static void XsdInferenceTypeInference()
        {
            //<snippet3>
            XmlReader^ reader3 = XmlReader::Create("input.xml");
            XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet;
            XmlSchemaInference^ schema = gcnew XmlSchemaInference;
            schema->TypeInference = 
                XmlSchemaInference::InferenceOption::Relaxed;
            schemaSet = schema->InferSchema(reader3);
            //</snippet3>
        }

        static void RefinementProcess()
        {
            //<snippet4>
            XmlReader^ reader4 = XmlReader::Create("item1.xml");
            XmlReader^ reader5 = XmlReader::Create("item2.xml");
            XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet;
            XmlSchemaInference^ inference = gcnew XmlSchemaInference;
            schemaSet = inference->InferSchema(reader4);

            // Display the inferred schema.
            Console::WriteLine("Original schema:\n");
            for each (XmlSchema^ currentSchema in schemaSet->Schemas())
            {                
                currentSchema->Write(Console::Out);
            }

            // Use the additional data in item2.xml 
            // to refine the original schema.
            schemaSet = inference->InferSchema(reader5);

            // Display the refined schema.
            Console::WriteLine("\n\nRefined schema:\n");
            for each (XmlSchema^ currentSchema in schemaSet->Schemas())
            {                
                currentSchema->Write(Console::Out);
            }
            //</snippet4>
        }
    };
}

int main()
{
    return 0;
}