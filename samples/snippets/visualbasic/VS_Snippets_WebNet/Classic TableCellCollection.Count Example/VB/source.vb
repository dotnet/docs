Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Page1
    Inherits Page
    Protected Table1 As Table
    
' <Snippet1>
    Sub Button_Click_Coord(sender As Object, e As EventArgs)
        
        Dim i As Integer
        For i = 0 To Table1.Rows.Count - 1
            Dim j As Integer
            For j = 0 To (Table1.Rows(i).Cells.Count) - 1                
                Table1.Rows(i).Cells(j).Text = "(" & j.ToString() & _
                    ", " & i.ToString() & ")"
            Next j
        Next i 
    End Sub

' </Snippet1>
End Class

