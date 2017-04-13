' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim names() As String = { "Adam", "Bruce", "Charles", "Daniel", 
                                "Ebenezer", "Francis", "Gilbert", 
                                "Henry", "Irving", "John", "Karl",
                                "Lucian", "Michael" }
      Dim partNames As New ArraySegment(Of String)(names, 2, 5)
      
      ' Cast the ArraySegment object to an IList<String> and enumerate it.
      Dim list = CType(partNames, IList(Of String))
      For ctr As Integer = 0 To list.Count - 1
         Console.WriteLine(list(ctr))
      Next     
   End Sub
End Module
' The example displays the following output:
'    Charles
'    Daniel
'    Ebenezer
'    Francis
'    Gilbert
' </Snippet1>
