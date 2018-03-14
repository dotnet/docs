' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim names As List(Of String) = GetData()
      PopulateNames(names)
   End Sub
   
   Private Sub PopulateNames(names As List(Of String))
      Dim arrNames() As String = { "Dakota", "Samuel", "Nikita",
                                   "Koani", "Saya", "Yiska", "Yumaevsky" }
      For Each arrName In arrNames
         names.Add(arrName)
      Next
   End Sub
   
   Private Function GetData() As List(Of String)
      Return Nothing   
   End Function
End Module
' The example displays output like the following:
'    Unhandled Exception: System.NullReferenceException: Object reference 
'    not set to an instance of an object.
'       at Example.PopulateNames(List`1 names)
'       at Example.Main()
' </Snippet3>
