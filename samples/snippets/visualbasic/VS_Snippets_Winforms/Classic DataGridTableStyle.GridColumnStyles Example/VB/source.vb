Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel



Public Class Form1
    Inherits Form
    Protected myDataGrid As DataGrid
    Protected myDataSet As DataSet
    
    ' <Snippet1>
    Private Sub WriteMappingNames()
        Dim dgt As DataGridTableStyle
        For Each dgt In  myDataGrid.TableStyles
            Console.WriteLine(dgt.MappingName)
            Dim dgc As DataGridColumnStyle
            For Each dgc In  dgt.GridColumnStyles
                Console.WriteLine(dgc.MappingName)
            Next dgc
        Next dgt
    End Sub
    ' </Snippet1>
End Class
