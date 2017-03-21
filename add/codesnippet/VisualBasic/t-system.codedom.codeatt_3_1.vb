            ' Defines a delegate creation expression that creates an EventHandler delegate pointing to TestMethod.
            Dim createDelegate1 As New CodeDelegateCreateExpression(New CodeTypeReference("System.EventHandler"), New CodeThisReferenceExpression(), "TestMethod")

            ' Attaches an EventHandler delegate pointing to TestMethod to the TestEvent event.
            Dim attachStatement1 As New CodeAttachEventStatement(New CodeThisReferenceExpression(), "TestEvent", createDelegate1)
            
            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '     AddHandler TestEvent, AddressOf Me.TestMethod