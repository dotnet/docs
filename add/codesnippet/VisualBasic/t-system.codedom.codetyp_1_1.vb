            ' Creates a reference to the System.DateTime type.
            Dim typeRef1 As New CodeTypeReference("System.DateTime")

            ' Creates a typeof expression for the specified type reference.
            Dim typeof1 As New CodeTypeOfExpression(typeRef1)

            ' Create a Visual Basic code provider
            Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic")

            ' Generate code and send the output to the console
            provider.GenerateCodeFromExpression(typeof1, Console.Out, new CodeGeneratorOptions())
            ' The code generator produces the following source code for the preceeding example code:
            '    GetType(Date)