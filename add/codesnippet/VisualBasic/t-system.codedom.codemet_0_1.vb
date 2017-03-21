     ' This CodeMethodInvokeExpression calls Me.Dispose(true)

         ' The targetObject parameter indicates the object containing the method to invoke.
         ' The methodName parameter indicates the method to invoke.
         ' The parameters array contains the parameters for the method invoke.

         Dim methodInvoke As New CodeMethodInvokeExpression( _
            New CodeThisReferenceExpression(), _
            "Dispose", _
            New CodeExpression() {New CodePrimitiveExpression(True)})

         ' A Visual Basic code generator produces the following source code for the preceeding example code:

         ' Me.Dispose(true)