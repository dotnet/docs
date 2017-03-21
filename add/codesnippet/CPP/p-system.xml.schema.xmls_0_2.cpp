		XmlReader^ reader = XmlReader::Create("input.xml");
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        XmlSchemaInference^ schema = gcnew XmlSchemaInference();

		schema->TypeInference = XmlSchemaInference::InferenceOption::Relaxed;

        schemaSet = schema->InferSchema(reader);

        for each (XmlSchema^ s in schemaSet->Schemas())
        {
            s->Write(Console::Out);
        }