'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples
    _
    Public Class CodeTypeDelegateExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type to contain the delegate and constructor method.
            Dim type1 As New CodeTypeDeclaration("DelegateTest")

            ' Declares an event that accepts a custom delegate type of "TestDelegate".
            Dim event1 As New CodeMemberEvent()
            event1.Name = "TestEvent"
            event1.Type = New CodeTypeReference("DelegateTest.TestDelegate")
            type1.Members.Add(event1)

            '<Snippet3>
            ' Declares a delegate type called TestDelegate with an EventArgs parameter.
            Dim delegate1 As New CodeTypeDelegate("TestDelegate")
            delegate1.Parameters.Add(New CodeParameterDeclarationExpression("System.Object", "sender"))
            delegate1.Parameters.Add(New CodeParameterDeclarationExpression("System.EventArgs", "e"))
            
            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '	    Public Delegate Sub TestDelegate(ByVal sender As Object, ByVal e As System.EventArgs)
            '		End Class
            '</Snippet3>
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
            Dim createDelegate1 As New CodeDelegateCreateExpression(New CodeTypeReference("DelegateTest.TestDelegate"), New CodeThisReferenceExpression(), "TestMethod")
            Dim attachStatement1 As New CodeAttachEventStatement(New CodeThisReferenceExpression(), "TestEvent", createDelegate1)
            constructor1.Statements.Add(attachStatement1)
            type1.Members.Add(constructor1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '	Public Class DelegateTest
            '       
            '	    Public Sub New()
            '	    MyBase.New
            '	        AddHandler TestEvent, AddressOf Me.TestMethod
            '	    End Sub
            '      
            '	    Private Event TestEvent As DelegateTest.TestDelegate
            '       
            '	    Private Sub TestMethod(ByVal sender As Object, ByVal e As System.EventArgs)
            '		End Sub
            '        
            '	    Public Delegate Sub TestDelegate(ByVal sender As Object, ByVal e As System.EventArgs)
            '		End Class

            '</Snippet2>
        End Sub 'New 

    End Class 'CodeTypeDelegateExample 
End Namespace 'CodeDomSamples
'</Snippet1>