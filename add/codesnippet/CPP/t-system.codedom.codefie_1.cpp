         CodeFieldReferenceExpression^ fieldRef1 = gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"TestField" );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    this.TestField