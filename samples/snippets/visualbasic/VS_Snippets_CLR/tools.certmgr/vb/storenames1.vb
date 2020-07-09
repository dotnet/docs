' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports System.Security.Cryptography.X509Certificates

Module Example
    Public Sub Main()
        For Each storeValue In [Enum].GetValues(GetType(StoreName))
            Dim store As New X509Store(CType(storeValue, StoreName))
            store.Open(OpenFlags.ReadOnly)
            Console.WriteLine(store.Name)
        Next
    End Sub
End Module
' </Snippet1>
