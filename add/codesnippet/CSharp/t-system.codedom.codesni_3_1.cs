        static void GenCodeFromMember(CodeDomProvider provider, CodeGeneratorOptions options)
        {
            options.BracingStyle = "C";
            CodeMemberMethod method1 = new CodeMemberMethod();
            method1.Name = "ReturnString";
            method1.Attributes = MemberAttributes.Public;
            method1.ReturnType = new CodeTypeReference("System.String");
            method1.Parameters.Add(new CodeParameterDeclarationExpression("System.String", "text"));
            method1.Statements.Add(new CodeMethodReturnStatement(new CodeArgumentReferenceExpression("text")));
            StringWriter sw = new StringWriter();
            provider.GenerateCodeFromMember(method1, sw, options);
            snippetMethod = new CodeSnippetTypeMember(sw.ToString());
        }