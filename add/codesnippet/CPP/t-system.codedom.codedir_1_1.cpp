      // Declares a parameter passed by reference using a CodeDirectionExpression.
      array<CodeDirectionExpression^>^param1 = {gcnew CodeDirectionExpression( FieldDirection::Ref,gcnew CodeFieldReferenceExpression( gcnew CodeThisReferenceExpression,"TestParameter" ) )};
      
      // Invokes a method on this named TestMethod using the direction expression as a parameter.
      CodeMethodInvokeExpression^ methodInvoke1 = gcnew CodeMethodInvokeExpression( gcnew CodeThisReferenceExpression,"TestMethod",param1 );
      
      // A C# code generator produces the following source code for the preceeding example code:
      //        this.TestMethod(ref TestParameter);