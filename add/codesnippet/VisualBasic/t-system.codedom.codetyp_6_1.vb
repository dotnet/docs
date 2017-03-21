            ' Creates an expression referencing the System.DateTime type.
            Dim typeRef1 As new CodeTypeReferenceExpression("System.DateTime")

            ' Create a Visual Basic code provider
            Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic")

            ' Generate code and send the output to the console
            provider.GenerateCodeFromExpression(typeRef1, Console.Out, New CodeGeneratorOptions())
            ' The code generator produces the following source code for the preceeding example code:

            '    Date
