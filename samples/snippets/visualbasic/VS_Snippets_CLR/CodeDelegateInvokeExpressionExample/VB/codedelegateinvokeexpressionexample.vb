'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeDelegateInvokeExpressionExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type to contain the delegate and constructor method.
            Dim type1 As New CodeTypeDeclaration("DelegateInvokeTest")

            ' Declares an event that accepts a custom delegate type of "TestDelegate".
            Dim event1 As New CodeMemberEvent()
            event1.Name = "TestEvent"
            event1.Type = New CodeTypeReference("DelegateInvokeTest.TestDelegate")
            type1.Members.Add(event1)

            ' Declares a delegate type called TestDelegate with an EventArgs parameter.
            Dim delegate1 As New CodeTypeDelegate("TestDelegate")
            delegate1.Parameters.Add(New CodeParameterDeclarationExpression("System.Object", "sender"))
            delegate1.Parameters.Add(New CodeParameterDeclarationExpression("System.EventArgs", "e"))
            type1.Members.Add(delegate1)

            ' Declares a method that matches the "TestDelegate" method signature.
            Dim method1 As New CodeMemberMethod()
            method1.Name = "TestMethod"
            method1.Parameters.Add(New CodeParameterDeclarationExpression("System.Object", "sender"))
            method1.Parameters.Add(New CodeParameterDeclarationExpression("System.EventArgs", "e"))
            type1.Members.Add(method1)

            ' Defines a constructor that attaches a TestDelegate delegate pointing to the TestMethod method
            ' to the TestEvent event.
            Dim constructor1 As New CodeConstructor()
            constructor1.Attributes = MemberAttributes.Public

            constructor1.Statements.Add(New CodeCommentStatement("Attaches a delegate to the TestEvent event."))

            ' Creates and attaches a delegate to the TestEvent.
            Dim createDelegate1 As New CodeDelegateCreateExpression( _
                New CodeTypeReference("DelegateInvokeTest.TestDelegate"), New CodeThisReferenceExpression(), "TestMethod")
            Dim attachStatement1 As New CodeAttachEventStatement(New CodeThisReferenceExpression(), "TestEvent", createDelegate1)
            constructor1.Statements.Add(attachStatement1)

            constructor1.Statements.Add(New CodeCommentStatement("Invokes the TestEvent event."))

            ' Invokes the TestEvent.
            Dim invoke1 As New CodeDelegateInvokeExpression( _
                New CodeEventReferenceExpression(New CodeThisReferenceExpression(), "TestEvent"), _
                New CodeExpression() {New CodeThisReferenceExpression(), New CodeObjectCreateExpression("System.EventArgs")})
            constructor1.Statements.Add(invoke1)

            type1.Members.Add(constructor1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '   Public Class DelegateInvokeTest
            '
            '       Public Sub New()
            '           MyBase.New()
            '       
            '           'Attaches a delegate to the TestEvent event.
            '           AddHandler TestEvent, AddressOf Me.TestMethod
            '           'Invokes the TestEvent event.
            '           RaiseEvent TestEvent(Me, New System.EventArgs())
            '       End Sub
            '
            '       Private Event TestEvent As DelegateInvokeTest.TestDelegate
            '
            '       Private Sub TestMethod(ByVal sender As Object, ByVal e As System.EventArgs)
            '       End Sub            
            '
            '       Public Delegate Sub TestDelegate(ByVal sender As Object, ByVal e As System.EventArgs)
            '  End Class
            '</Snippet2>

        End Sub 'New 


        Public Sub DelegateInvokeOnlyType()
            '<Snippet3>
            ' Invokes the delegates for an event named TestEvent, passing a local object reference and a new System.EventArgs.
            Dim invoke1 As New CodeDelegateInvokeExpression( _
                New CodeEventReferenceExpression(New CodeThisReferenceExpression(), "TestEvent"), _
                New CodeExpression() {New CodeThisReferenceExpression(), New CodeObjectCreateExpression("System.EventArgs")})

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '   RaiseEvent TestEvent(Me, New System.EventArgs())            
            '</Snippet3>		
        End Sub 'DelegateInvokeOnlyType
        
    End Class 'CodeDelegateInvokeExpressionExample 
End Namespace 'CodeDomSamples
'</Snippet1>