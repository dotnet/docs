            ' Invokes the delegates for an event named TestEvent, passing a local object reference and a new System.EventArgs.
            Dim invoke1 As New CodeDelegateInvokeExpression( _
                New CodeEventReferenceExpression(New CodeThisReferenceExpression(), "TestEvent"), _
                New CodeExpression() {New CodeThisReferenceExpression(), New CodeObjectCreateExpression("System.EventArgs")})

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '   RaiseEvent TestEvent(Me, New System.EventArgs())            