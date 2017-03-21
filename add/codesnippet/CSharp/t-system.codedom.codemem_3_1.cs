            // Defines a method that returns a string passed to it.
            CodeMemberMethod method1 = new CodeMemberMethod();            
            method1.Name = "ReturnString";
            method1.ReturnType = new CodeTypeReference("System.String");
            method1.Parameters.Add( new CodeParameterDeclarationExpression("System.String", "text") );
            method1.Statements.Add( new CodeMethodReturnStatement( new CodeArgumentReferenceExpression("text") ) );            
            
            // A C# code generator produces the following source code for the preceeding example code:

            //    private string ReturnString(string text) 
            //    {
            //        return text;
            //    }