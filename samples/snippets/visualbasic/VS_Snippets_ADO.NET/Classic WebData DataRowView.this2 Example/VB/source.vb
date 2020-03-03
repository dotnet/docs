Imports System.Data

Public Class Sample
    
' <Snippet1>

 Private Shared Sub WriteViewRows(view As DataView)
    Dim colCount As Integer = view.Table.Columns.Count

    ' Iterate through the rows of the DataView.
    For Each rowView As DataRowView In view
      ' Display the value in each item of the DataRowView
      For i As Integer = 0 To colCount - 1
         Console.Write(rowView(i) & vbTab)
      Next
      Console.WriteLine()
    Next
 End Sub
' </Snippet1>
End Class
