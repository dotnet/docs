 '<Snippet1>
Imports System
Imports System.CodeDom


Namespace CodeDomSamples
    _
   Public Class CodeMemberEventExample
      
      Public Sub New()

         '<Snippet2>
         Dim compileUnit As New CodeCompileUnit()
         Dim namespace1 As New CodeNamespace("TestNamespace")
         compileUnit.Namespaces.Add(namespace1)

         ' A Visual Basic code generator produces the following source code for the preceeding example code:

         '     Namespace TestNamespace
         '     End Namespace
         '</Snippet2>

      End Sub 'New 
   End Class 'CodeMemberEventExample 
End Namespace 'CodeDomSamples

'</Snippet1>
