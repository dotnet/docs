Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub dataGrid1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim newLine As String = ControlChars.Cr
        Console.WriteLine(newLine)
        Dim myHitTest As System.Windows.Forms.DataGrid.HitTestInfo
        ' Use the DataGrid control's HitTest method with the x and y properties.
        myHitTest = dataGrid1.HitTest(e.X, e.Y)
        Console.WriteLine(("Hit " & ReturnHitTest(myHitTest.Type)))
    End Sub 'dataGrid1_MouseDown
    
    
    Private Function ReturnHitTest(hit As System.Windows.Forms.DataGrid.HitTestType) As String
        ' Use this function to return the part of the grid clicked.   
        Select Case hit
            Case System.Windows.Forms.DataGrid.HitTestType.Cell
                    Return "Cell"
            
            Case System.Windows.Forms.DataGrid.HitTestType.Caption
                    Return "Caption"
            
            Case System.Windows.Forms.DataGrid.HitTestType.ColumnHeader
                    Return "ColumnHeader"
            
            Case System.Windows.Forms.DataGrid.HitTestType.ColumnResize
                    Return "Resize"
            
            Case System.Windows.Forms.DataGrid.HitTestType.ParentRows
                    Return "ParentRows"
            
            Case System.Windows.Forms.DataGrid.HitTestType.RowHeader
                    Return "RowHeader"
            
            Case System.Windows.Forms.DataGrid.HitTestType.RowResize
                    Return "RowResize"
            
            Case System.Windows.Forms.DataGrid.HitTestType.None
                    Return "None"
            
            Case Else
                    Return "Unknown"
        End Select
    End Function 'ReturnHitTest
    ' </Snippet1>
End Class 'Form1 

