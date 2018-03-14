Imports System
Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private WithEvents button1 As New Button()
    Private WithEvents dataGridView1 As New DataGridView()

    Public Sub New()

        dataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(dataGridView1)

        button1.Text = "Automatically Resize Cells"
        button1.Dock = DockStyle.Top
        Me.Controls.Add(button1)

        Me.Size = New Size(600, 300)

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        InitializeDataGridView()
        InitializeContextMenu()

    End Sub

    '<snippet2>
    '<snippet1>
    Private Sub InitializeDataGridView()

        ' Create an unbound DataGridView by declaring a column count.
        dataGridView1.ColumnCount = 4
        dataGridView1.ColumnHeadersVisible = True

        ' Set the column header style.
        Dim columnHeaderStyle As New DataGridViewCellStyle()

        columnHeaderStyle.BackColor = Color.Beige
        columnHeaderStyle.Font = New Font("Verdana", 10, FontStyle.Bold)
        dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle

        ' Set the column header names.
        dataGridView1.Columns(0).Name = "Recipe"
        dataGridView1.Columns(1).Name = "Category"
        dataGridView1.Columns(2).Name = "Main Ingredients"
        dataGridView1.Columns(3).Name = "Rating"

        ' Populate the rows.
        Dim row1() As String = {"Meatloaf", "Main Dish", "ground beef", "**"}
        Dim row2() As String = _
            {"Key Lime Pie", "Dessert", "lime juice, evaporated milk", "****"}
        Dim row3() As String = {"Orange-Salsa Pork Chops", "Main Dish", _
            "pork chops, salsa, orange juice", "****"}
        Dim row4() As String = {"Black Bean and Rice Salad", "Salad", _
            "black beans, brown rice", "****"}
        Dim row5() As String = _
            {"Chocolate Cheesecake", "Dessert", "cream cheese", "***"}
        Dim row6() As String = _
            {"Black Bean Dip", "Appetizer", "black beans, sour cream", "***"}
        Dim rows() As Object = {row1, row2, row3, row4, row5, row6}

        Dim rowArray As String()
        For Each rowArray In rows
            dataGridView1.Rows.Add(rowArray)
        Next rowArray

    End Sub

    '<snippet3>
    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles button1.Click

        ' Resize the height of the column headers. 
        dataGridView1.AutoResizeColumnHeadersHeight()

        ' Resize all the row heights to fit the contents of all 
        ' non-header cells.
        dataGridView1.AutoResizeRows( _
            DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)

    End Sub
    '</snippet3>
    '</snippet1>

    Private Sub InitializeContextMenu()

        ' Create the menu item.
        Dim getRecipe As New ToolStripMenuItem( _
            "Search for recipe", Nothing, AddressOf ShortcutMenuClick)

        ' Add the menu item to the shortcut menu.
        Dim recipeMenu As New ContextMenuStrip()
        recipeMenu.Items.Add(getRecipe)

        ' Set the shortcut menu for the first column.
        dataGridView1.Columns(0).ContextMenuStrip = recipeMenu

    End Sub

    '<snippet4>
    Private clickedCell As DataGridViewCell

    Private Sub dataGridView1_MouseDown(ByVal sender As Object, _
        ByVal e As MouseEventArgs) Handles dataGridView1.MouseDown

        ' If the user right-clicks a cell, store it for use by the 
        ' shortcut menu.
        If e.Button = MouseButtons.Right Then
            Dim hit As DataGridView.HitTestInfo = _
                dataGridView1.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                clickedCell = _
                    dataGridView1.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            End If
        End If

    End Sub
    '</snippet4>

    Private Sub ShortcutMenuClick(ByVal sender As Object, _
        ByVal e As System.EventArgs)

        If (clickedCell IsNot Nothing) Then
            'Retrieve the recipe name.
            Dim recipeName As String = CStr(clickedCell.Value)

            'Search for the recipe.
            System.Diagnostics.Process.Start( _
                "http://search.msn.com/results.aspx?q=" + recipeName)
        End If

    End Sub
    '</snippet2>

End Class
