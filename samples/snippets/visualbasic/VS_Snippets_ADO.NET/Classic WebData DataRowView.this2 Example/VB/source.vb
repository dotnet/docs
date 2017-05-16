Imports System
Imports System.Data
Imports Microsoft.VisualBasic

Public Class Sample
    
' <Snippet1>

 Private Shared Sub WriteViewRows(view As DataView)
    Dim colCount As Integer = view.Table.Columns.Count

    ' Iterate through the rows of the DataView.
    Dim rowView As DataRowView
    Dim i As Integer

    For Each rowView In view
      ' Display the value in each item of the DataRowView
      For i = 0 To colCount
         Console.Write(rowView(i) & vbTab)
      Next
      Console.WriteLine()
    Next
 End Sub
' </Snippet1>
End Class
