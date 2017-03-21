      // Invokes the TestMethod method of the current type object.
      CodeMethodReferenceExpression^ methodRef1 = gcnew CodeMethodReferenceExpression( gcnew CodeThisReferenceExpression,"TestMethod" );
      array<CodeParameterDeclarationExpression^>^temp1;
      CodeMethodInvokeExpression^ invoke1 = gcnew CodeMethodInvokeExpression( methodRef1,temp1 );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //        this.TestMethod();