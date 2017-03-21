         // Declares a method.
         CodeMemberMethod^ method1 = gcnew CodeMemberMethod;
         method1->Name = "TestMethod";
         
         // Declares a string parameter passed by reference.
         CodeParameterDeclarationExpression^ param1 = gcnew CodeParameterDeclarationExpression( "System.String","stringParam" );
         param1->Direction = FieldDirection::Ref;
         method1->Parameters->Add( param1 );
         
         // Declares a Int32 parameter passed by incoming field.
         CodeParameterDeclarationExpression^ param2 = gcnew CodeParameterDeclarationExpression( "System.Int32","intParam" );
         param2->Direction = FieldDirection::Out;
         method1->Parameters->Add( param2 );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //        private void TestMethod(ref string stringParam, out int intParam) {
         //        }