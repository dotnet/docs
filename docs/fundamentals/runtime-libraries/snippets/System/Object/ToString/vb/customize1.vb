' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Collections.Generic

Public Class CList(Of T) : Inherits List(Of T)
   Public Sub New(capacity As Integer)
      MyBase.New(capacity)
   End Sub

   Public Sub New(collection As IEnumerable(Of T))
      MyBase.New(collection)
   End Sub

   Public Sub New()
      MyBase.New()
   End Sub

   Public Overrides Function ToString() As String
      Dim retVal As String = String.Empty
      For Each item As T In Me
         If String.IsNullOrEmpty(retval) Then
            retVal += item.ToString()
         Else
            retval += String.Format(", {0}", item)
         End If
      Next
      Return retVal
   End Function
End Class

Module Example1
    Public Sub Main()
        Dim list2 As New CList(Of Integer)
        list2.Add(1000)
        list2.Add(2000)
        Console.WriteLine(list2.ToString())
    End Sub
End Module
' The example displays the following output:
'       1000, 2000
' </Snippet7>
