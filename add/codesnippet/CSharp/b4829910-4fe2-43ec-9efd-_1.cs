public override string ImportSchemaType(string name, string ns, 
    XmlSchemaObject context, XmlSchemas schemas, 
    XmlSchemaImporter importer, 
    CodeCompileUnit compileUnit, CodeNamespace codeNamespace, 
    CodeGenerationOptions options, CodeDomProvider codeGenerator)
    {
        if (name.Equals("Order") && ns.Equals("http://orders/"))
        {
            compileUnit.ReferencedAssemblies.Add("Order.dll");
            codeNamespace.Imports.Add
               (new CodeNamespaceImport("Microsoft.Samples"));
             return "Order";
        }
        return null;
    }