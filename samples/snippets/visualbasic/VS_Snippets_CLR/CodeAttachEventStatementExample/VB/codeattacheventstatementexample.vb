'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    _
    Public Class CodeAttachEventStatementExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type to contain the delegate and constructor method.
            Dim type1 As New CodeTypeDeclaration("AttachEventTest")

            ' Declares an event that needs no custom event arguments class.
            Dim event1 As New CodeMemberEvent()
            event1.Name = "TestEvent"
            event1.Type = New CodeTypeReference("System.EventHandler")
            ' Adds the event to the type members.
            type1.Members.Add(event1)

            ' Declares a method that matches the System.EventHandler method signature.
            Dim method1 As New CodeMemberMethod()
            method1.Name = "TestMethod"
            method1.Parameters.Add(New CodeParameterDeclarationExpression("System.Object", "sender"))
            method1.Parameters.Add(New CodeParameterDeclarationExpression("System.EventArgs", "e"))
            ' Adds the method to the type members.
            type1.Members.Add(method1)

            ' Defines a constructor that attaches a TestDelegate delegate pointing to 
            ' the TestMethod method to the TestEvent event.
            Dim constructor1 As New CodeConstructor()
            constructor1.Attributes = MemberAttributes.Public

        '<Snippet3>
            ' Defines a delegate creation expression that creates an EventHandler delegate pointing to TestMethod.
            Dim createDelegate1 As New CodeDelegateCreateExpression(New CodeTypeReference("System.EventHandler"), New CodeThisReferenceExpression(), "TestMethod")

            ' Attaches an EventHandler delegate pointing to TestMethod to the TestEvent event.
            Dim attachStatement1 As New CodeAttachEventStatement(New CodeThisReferenceExpression(), "TestEvent", createDelegate1)
            
            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '     AddHandler TestEvent, AddressOf Me.TestMethod
        '</Snippet3>

            ' Adds the constructor statements to the construtor.
            constructor1.Statements.Add(attachStatement1)
            ' Adds the construtor to the type members.	
            type1.Members.Add(constructor1)

            '    Public Class AttachEventTest
            '
            '       Public Sub New()
            '           MyBase.New()
            '           AddHandler TestEvent, AddressOf Me.TestMethod
            '       End Sub
            '
            '       Private Event TestEvent As System.EventHandler
            '
            '       Private Sub TestMethod(ByVal sender As Object, ByVal e As System.EventArgs)
            '       End Sub
            '   End Class
            '</Snippet2>
        End Sub 'New

    End Class 'CodeAttachEventStatementExample
End Namespace 'CodeDomSamples
'</Snippet1>