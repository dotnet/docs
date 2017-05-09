' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections

Module Example
   Public Sub Main()
      Dim t As Type = GetType(IEnumerable)
      Dim c As Type = GetType(Array)
      
      Dim instanceOfT As IEnumerable
      Dim instanceOfC As Integer() = { 1, 2, 3, 4 }
      If t.IsAssignableFrom(c) Then
         ' <Snippet4>
         instanceOfT = instanceOfC
         ' </Snippet4>
      End If  
   End Sub
End Module
' </Snippet3>
