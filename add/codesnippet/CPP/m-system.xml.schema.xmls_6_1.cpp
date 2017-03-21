		XmlReader^ reader = XmlReader::Create("contosoBooks.xml");
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        XmlSchemaInference^ schema = gcnew XmlSchemaInference();

        schemaSet = schema->InferSchema(reader);

        for each (XmlSchema^ s in schemaSet->Schemas())
        {
            s->Write(Console::Out);
        }