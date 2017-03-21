        static CodeCompileUnit Import(XmlSchemaSet schemas)
        {

            XsdDataContractImporter imp = new XsdDataContractImporter();

            // The EnableDataBinding option adds a RaisePropertyChanged method to
            // the generated code. The GenerateInternal causes code access to be
            // set to internal.
            ImportOptions iOptions = new ImportOptions();
            iOptions.EnableDataBinding = true;
            iOptions.GenerateInternal = true;
            imp.Options = iOptions;


            if (imp.CanImport(schemas))
            {
                imp.Import(schemas);
                return imp.CodeCompileUnit;
            }
            else
                return null;
        }