'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeGotoStatementExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type to contain the example code.
            Dim type1 As New CodeTypeDeclaration("Type1")
            ' Declares an entry point method.
            Dim entry1 As New CodeEntryPointMethod()
            type1.Members.Add(entry1)
            ' Adds a goto statement to continue program flow at the "JumpToLabel" label.
            Dim goto1 As New CodeGotoStatement("JumpToLabel")
            entry1.Statements.Add(goto1)
            ' Invokes Console.WriteLine to print "Test Output", which is skipped by the goto statement.
            Dim method1 As New CodeMethodInvokeExpression(New CodeTypeReferenceExpression("System.Console"), "WriteLine", New CodePrimitiveExpression("Test Output."))
            entry1.Statements.Add(method1)
            ' Declares a label named "JumpToLabel" associated with a method to output a test string using Console.WriteLine.
            Dim method2 As New CodeMethodInvokeExpression(New CodeTypeReferenceExpression("System.Console"), "WriteLine", New CodePrimitiveExpression("Output from labeled statement."))
            Dim label1 As New CodeLabeledStatement("JumpToLabel", New CodeExpressionStatement(method2))
            entry1.Statements.Add(label1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '   Public Class Type1
            '
            '       Public Shared Sub Main()
            '           GoTo JumpToLabel
            '           System.Console.WriteLine("Test Output")
            '           JumpToLabel:
            '           System.Console.WriteLine("Output from labeled statement.")
            '       End Sub
            '   End Class
            '</Snippet2>

        End Sub 'New 
    End Class 'CodeGotoStatementExample 
End Namespace 'CodeDomSamples
'</Snippet1>
