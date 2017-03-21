            // Creates an expression referencing the System.DateTime type.
            CodeTypeReferenceExpression^ typeRef1 = gcnew CodeTypeReferenceExpression("System.DateTime");

            // Create a C# code provider
            CodeDomProvider^ provider = CodeDomProvider::CreateProvider("CSharp");

            // Generate code and send the output to the console
            provider->GenerateCodeFromExpression(typeRef1, Console::Out, gcnew CodeGeneratorOptions());
            // The code generator produces the following source code for the preceeding example code:

            //    System.DateTime
