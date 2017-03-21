         // Declares a property of type String named StringProperty.
         CodeMemberProperty^ property1 = gcnew CodeMemberProperty;
         property1->Name = "StringProperty";
         property1->Type = gcnew CodeTypeReference( "System.String" );
         property1->Attributes = MemberAttributes::Public;
         property1->GetStatements->Add( gcnew CodeMethodReturnStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"testStringField" ) ) );
         property1->SetStatements->Add( gcnew CodeAssignStatement( gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"testStringField" ),gcnew CodePropertySetValueReferenceExpression ) );
         
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