    Shared Sub GenCodeFromMember(ByVal provider As CodeDomProvider, ByVal options As CodeGeneratorOptions) 
        options.BracingStyle = "C"
        Dim method1 As New CodeMemberMethod()
        method1.Name = "ReturnString"
        method1.Attributes = MemberAttributes.Public
        method1.ReturnType = New CodeTypeReference("System.String")
        method1.Parameters.Add(New CodeParameterDeclarationExpression("System.String", "text"))
        method1.Statements.Add(New CodeMethodReturnStatement(New CodeArgumentReferenceExpression("text")))
        Dim sw As New StringWriter()
        provider.GenerateCodeFromMember(method1, sw, options)
        snippetMethod = New CodeSnippetTypeMember(sw.ToString())
    
    End Sub 'GenCodeFromMember
End Class 'Program 