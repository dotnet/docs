            ' Represents a reference to an event.
            Dim eventRef1 As New CodeEventReferenceExpression(New CodeThisReferenceExpression(), "TestEvent")

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '       Me.TestEvent