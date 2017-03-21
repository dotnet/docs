            ' Declares an event that accepts a delegate type of System.EventHandler.
            Dim event1 As New CodeMemberEvent()
            ' Sets a name for the event.
            event1.Name = "TestEvent"
            ' Sets the type of event.
            event1.Type = New CodeTypeReference("System.EventHandler")

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '     Private Event TestEvent As System.EventHandler