         ' Example method invoke expression uses CodeBaseReferenceExpression to produce 
         ' a base.Dispose method call
         Dim methodInvokeExpression As New CodeMethodInvokeExpression( New CodeBaseReferenceExpression(), "Dispose", New CodeExpression() {})    

         ' A Visual Basic code generator produces the following source code for the preceeding example code:

         ' MyBase.Dispose