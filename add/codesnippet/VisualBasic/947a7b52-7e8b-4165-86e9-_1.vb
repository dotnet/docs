        Public Shared Sub GenerateCode(ByVal provider As CodeDomProvider, ByVal compileunit As CodeCompileUnit)

            ' Build the source file name with the appropriate
            ' language extension.
            Dim sourceFile As String
            If provider.FileExtension.StartsWith(".") Then
                sourceFile = "TestGraph" + provider.FileExtension
            Else
                sourceFile = "TestGraph." + provider.FileExtension
            End If

            ' Create an IndentedTextWriter, constructed with
            ' a StreamWriter to the source file.
            Dim tw As New IndentedTextWriter(New StreamWriter(sourceFile, False), "    ")
            ' Generate source code using the code generator.
            provider.GenerateCodeFromCompileUnit(compileunit, tw, New CodeGeneratorOptions())
            ' Close the output file.
            tw.Close()
        End Sub