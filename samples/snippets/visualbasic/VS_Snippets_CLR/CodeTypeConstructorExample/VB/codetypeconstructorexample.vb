'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeTypeConstructorExample

        Public Sub New()
            '<Snippet2>
            ' Declares a new type for a static constructor.
            Dim type1 As New CodeTypeDeclaration("Type1")
            ' Declares a static constructor.
            Dim constructor2 As New CodeTypeConstructor()
            ' Adds the static constructor to the type.
            type1.Members.Add(constructor2)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '   Public Class Type1
            '
            '       Shared Sub New()            
            '       End Sub
            '   End Class
            '</Snippet2>

        End Sub 'New 
    End Class 'CodeTypeConstructorExample 
End Namespace 'CodeDomSamples
'</Snippet1>