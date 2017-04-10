'<Snippet1>
Imports System
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeNamespaceImportExample

        Public Sub New()
            '<Snippet2>
            ' Declares a compile unit to contain a namespace.
            Dim compileUnit As New CodeCompileUnit()

            ' Declares a namespace named TestNamespace.
            Dim testNamespace As New CodeNamespace("TestNamespace")
            ' Adds the namespace to the namespace collection of the compile unit.
            compileUnit.Namespaces.Add(testNamespace)

            ' Declares a namespace import of the System namespace.
            Dim import1 As New CodeNamespaceImport("System")
            ' Adds the namespace import to the namespace imports collection of the namespace.
            testNamespace.Imports.Add(import1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            'Option Strict Off
            'Option Explicit On
            '
            'Imports System
            '
            'Namespace TestNamespace
            'End Namespace

            '</Snippet2>
        End Sub 'New 

    End Class 'CodeNamespaceImportExample
End Namespace 'CodeDomSamples
'</Snippet1>