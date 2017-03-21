    static void ExportXSD()
    {
        XsdDataContractExporter exporter = new XsdDataContractExporter();
        if (exporter.CanExport(typeof(Employee)))
        {
            exporter.Export(typeof(Employee));
            Console.WriteLine("number of schemas: {0}", exporter.Schemas.Count);
            Console.WriteLine();
            XmlSchemaSet mySchemas = exporter.Schemas;

            XmlQualifiedName XmlNameValue = exporter.GetRootElementName(typeof(Employee));
            string EmployeeNameSpace = XmlNameValue.Namespace;

            foreach (XmlSchema schema in mySchemas.Schemas(EmployeeNameSpace))
            {
                schema.Write(Console.Out);
            }
        }
    }