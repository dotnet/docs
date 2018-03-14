' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.Resources

Module Example
   Public Sub Main()
      Dim rw As New ResourceWriter(".\TypeResources.resources")
      Dim n1 As Integer = 1032
      rw.AddResourceData("Integer1", "ResourceTypeCode.Int32", BitConverter.GetBytes(n1))
      Dim n2 As Integer = 2064       
      rw.AddResourceData("Integer2", "ResourceTypeCode.Int32", BitConverter.GetBytes(n2))
      rw.Generate()
      rw.Close()

      Dim rr As New ResourceReader(".\TypeResources.resources")
      Dim e As IDictionaryEnumerator = rr.GetEnumerator()
      Do While e.MoveNext()
         Console.WriteLine("{0}: {1}", e.Key, e.Value)
      Loop
    End Sub
End Module
' The example displays the following output:
'       Integer2: 2064
'       Integer1: 1032
' </Snippet1>
