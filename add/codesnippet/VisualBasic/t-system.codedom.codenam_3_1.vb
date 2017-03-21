         Dim compileUnit As New CodeCompileUnit()
         Dim namespace1 As New CodeNamespace("TestNamespace")
         compileUnit.Namespaces.Add(namespace1)

         ' A Visual Basic code generator produces the following source code for the preceeding example code:

         '     Namespace TestNamespace
         '     End Namespace