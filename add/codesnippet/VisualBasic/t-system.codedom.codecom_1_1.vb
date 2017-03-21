        ' Build a Hello World program graph using 
        ' System.CodeDom types.
        Public Shared Function BuildHelloWorldGraph() As CodeCompileUnit

            ' Create a new CodeCompileUnit to contain 
            ' the program graph.
            Dim compileUnit As New CodeCompileUnit()

            ' Declare a new namespace called Samples.
            Dim samples As New CodeNamespace("Samples")

            ' Add the new namespace to the compile unit.
            compileUnit.Namespaces.Add(samples)

            ' Add the new namespace import for the System namespace.
            samples.Imports.Add(New CodeNamespaceImport("System"))

            ' Declare a new type called Class1.
            Dim class1 As New CodeTypeDeclaration("Class1")

            ' Add the new type to the namespace type collection.
            samples.Types.Add(class1)

            ' Declare a new code entry point method.
            Dim start As New CodeEntryPointMethod()

            ' Create a type reference for the System.Console class.
            Dim csSystemConsoleType As New CodeTypeReferenceExpression( _
                "System.Console")

            ' Build a Console.WriteLine statement.
            Dim cs1 As New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("Hello World!"))

            ' Add the WriteLine call to the statement collection.
            start.Statements.Add(cs1)

            ' Build another Console.WriteLine statement.
            Dim cs2 As New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("Press the Enter key to continue."))

            ' Add the WriteLine call to the statement collection.
            start.Statements.Add(cs2)

            ' Build a call to System.Console.ReadLine.
            Dim csReadLine As New CodeMethodInvokeExpression( _
                csSystemConsoleType, "ReadLine")

            ' Add the ReadLine statement.
            start.Statements.Add(csReadLine)

            ' Add the code entry point method to
            ' the Members collection of the type.
            class1.Members.Add(start)

            Return compileUnit
        End Function