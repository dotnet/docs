' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim list As New List(Of String) 
      list.AddRange( { "A", "B", "C" } )
      ' Get the index of the element whose value is "Z".
      Dim index As Integer = list.FindIndex(AddressOf (New StringSearcher("Z")).FindEquals)
      Try
         Console.WriteLine("Index {0} contains '{1}'", index, list(index)) 
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine(e.Message)
      End Try
   End Sub
End Module

Friend Class StringSearcher
   Dim value As String
   
   Public Sub New(value As String)
      Me.value = value
   End Sub
   
   Public Function FindEquals(s As String) As Boolean
      Return s.Equals(value, StringComparison.InvariantCulture) 
   End Function
End Class
' The example displays the following output:
'   Index was out of range. Must be non-negative and less than the size of the collection.
'   Parameter name: index
' </Snippet6>

Public Class Example2
   Public Sub Test
      Dim list As New List(Of String) 
      list.AddRange( { "A", "B", "C" } )
      ' <Snippet7>
      ' Get the index of the element whose value is "Z".
      Dim index As Integer = list.FindIndex(AddressOf (New StringSearcher("Z")).FindEquals)
      If index >= 0 Then
         Console.WriteLine("Index {0} contains '{1}'", index, list(index)) 
      End If
      ' </Snippet7>
   End Sub
End Class

