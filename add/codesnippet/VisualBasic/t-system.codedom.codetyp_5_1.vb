            ' Declares a delegate type called TestDelegate with an EventArgs parameter.
            Dim delegate1 As New CodeTypeDelegate("TestDelegate")
            delegate1.Parameters.Add(New CodeParameterDeclarationExpression("System.Object", "sender"))
            delegate1.Parameters.Add(New CodeParameterDeclarationExpression("System.EventArgs", "e"))
            
            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '	    Public Delegate Sub TestDelegate(ByVal sender As Object, ByVal e As System.EventArgs)
            '		End Class