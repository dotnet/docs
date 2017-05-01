' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim test As New Sample()
    End Sub 'Main
    
    Public Sub New()
        ' Create the XmlNamespaceManager.
        Dim nt As New NameTable()
        Dim nsmgr As New XmlNamespaceManager(nt)
        
        ' Add prefix/namespace pairs to the XmlNamespaceManager.
        nsmgr.AddNamespace("", "www.wideworldimporters.com") 'Adds a default namespace.
        nsmgr.AddNamespace("europe", "www.wideworldimporters.com/europe")
        nsmgr.PushScope() 'Pushes a namespace scope on the stack.
        nsmgr.AddNamespace("", "www.lucernepublishing.com") 'Adds another default namespace.
        nsmgr.AddNamespace("partners", "www.lucernepublishing.com/partners")
        
        Console.WriteLine("Show all the prefix/namespace pairs in the XmlNamespaceManager...")
        ShowAllNamespaces(nsmgr)
    End Sub 'New
    
    
    Private Sub ShowAllNamespaces(nsmgr As XmlNamespaceManager)
        Do
            Dim prefix As String
            For Each prefix In  nsmgr
                Console.WriteLine("Prefix={0}, Namespace={1}", prefix, nsmgr.LookupNamespace(prefix))
            Next prefix
        Loop While nsmgr.PopScope()
    End Sub 'ShowAllNamespaces
End Class 'Sample
' </Snippet1>