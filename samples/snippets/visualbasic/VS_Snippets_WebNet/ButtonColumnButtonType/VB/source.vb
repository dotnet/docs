Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls



Public Class Page1
    Inherits Page
    Private ItemsGrid As DataGrid
    
    ' <Snippet1>
    Private Sub Page_Init(sender As Object, e As EventArgs)
        
        ' Create dynamic column to add to Columns collection.
        Dim AddColumn As New ButtonColumn()
        AddColumn.HeaderText = "Add Item"
        AddColumn.Text = "Add"
        AddColumn.CommandName = "Add"
        AddColumn.ButtonType = ButtonColumnType.PushButton

        
        ' Add column to Columns collection.
        ItemsGrid.Columns.AddAt(2, AddColumn)
    End Sub 'Page_Init 
    ' </Snippet1>
End Class 'Page1


