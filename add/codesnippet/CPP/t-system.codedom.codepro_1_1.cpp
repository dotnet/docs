         CodePropertyReferenceExpression^ propertyRef1 = gcnew CodePropertyReferenceExpression( gcnew CodeThisReferenceExpression,"TestProperty" );
         
         // A C# code generator produces the following source code for the preceeding example code:
         //    this.TestProperty