            // Declares a property of type String named StringProperty.
            CodeMemberProperty property1 = new CodeMemberProperty();
            property1.Name = "StringProperty";
            property1.Type = new CodeTypeReference("System.String");
            property1.Attributes = MemberAttributes.Public;
            property1.GetStatements.Add( new CodeMethodReturnStatement( new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "testStringField") ) );
            property1.SetStatements.Add( new CodeAssignStatement( new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "testStringField"), new CodePropertySetValueReferenceExpression()));
            
            // A C# code generator produces the following source code for the preceeding example code:

            //       public virtual string StringProperty 
            //       {
            //              get 
            //            {
            //                return this.testStringField;
            //            }
            //            set 
            //            {
            //                this.testStringField = value;
            //            }
            //       }            