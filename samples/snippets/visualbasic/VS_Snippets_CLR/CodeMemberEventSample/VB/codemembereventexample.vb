'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    _
    Public Class CodeMemberEventExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type to contain an event and constructor method.
            Dim type1 As New CodeTypeDeclaration("EventTest")

            '<Snippet3>
            ' Declares an event that accepts a delegate type of System.EventHandler.
            Dim event1 As New CodeMemberEvent()
            ' Sets a name for the event.
            event1.Name = "TestEvent"
            ' Sets the type of event.
            event1.Type = New CodeTypeReference("System.EventHandler")

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '     Private Event TestEvent As System.EventHandler
            '</Snippet3>

            ' Adds the event to the type members collection.
            type1.Members.Add(event1)

            ' Declares an empty type constructor.
            Dim constructor1 As New CodeConstructor()
            constructor1.Attributes = MemberAttributes.Public
            type1.Members.Add(constructor1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            ' Public Class EventTest
            '
            '     Public Sub New()
            '         MyBase.New()
            '     End Sub
            '
            '     Private Event TestEvent As System.EventHandler
            ' End Class
            '</Snippet2>

        End Sub 'New 
    End Class 'CodeMemberEventExample
End Namespace 'CodeDomSamples
'</Snippet1>