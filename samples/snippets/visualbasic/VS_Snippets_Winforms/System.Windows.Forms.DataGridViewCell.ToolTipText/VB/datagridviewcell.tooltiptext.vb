Imports System
Imports System.Windows.Forms

Class Form1
    Inherits Form

    Private WithEvents dataGridView1 As New DataGridView()

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main

    Public Sub New()
        Me.dataGridView1.Dock = DockStyle.Fill
        ' Set the column header names.
        Me.dataGridView1.ColumnCount = 5
        Me.dataGridView1.Columns(0).Name = "Recipe"
        Me.dataGridView1.Columns(1).Name = "Category"
        Me.dataGridView1.Columns(2).Name = "Main Ingredients"
        Me.dataGridView1.Columns(3).Name = "Last Fixed"
        Me.dataGridView1.Columns(4).Name = "Rating"

        ' Populate the rows.
        Dim row1() As Object = {"Meatloaf", "Main Dish", "ground beef", New DateTime(2000, 3, 23), "*"}
        Dim row2() As Object = {"Key Lime Pie", "Dessert", "lime juice, evaporated milk", New DateTime(2002, 4, 12), "****"}
        Dim row3() As Object = {"Orange-Salsa Pork Chops", "Main Dish", "pork chops, salsa, orange juice", New DateTime(2000, 8, 9), "****"}
        Dim row4() As Object = {"Black Bean and Rice Salad", "Salad", "black beans, brown rice", New DateTime(1999, 5, 7), "****"}
        Dim row5() As Object = {"Chocolate Cheesecake", "Dessert", "cream cheese", New DateTime(2003, 3, 12), "***"}
        Dim row6() As Object = {"Black Bean Dip", "Appetizer", "black beans, sour cream", New DateTime(2003, 12, 23), "***"}
        Dim rows() As Object = {row1, row2, row3, row4, row5, row6}

        Dim rowArray As Object()
        For Each rowArray In rows
            Me.dataGridView1.Rows.Add(rowArray)
        Next rowArray
        Me.Controls.Add(Me.dataGridView1)
        Me.Text = "DataGridView cell ToolTip demo"

    End Sub 'New

    '<Snippet1>
    ' Sets the ToolTip text for cells in the Rating column.
    Sub dataGridView1_CellFormatting(ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles dataGridView1.CellFormatting

        If e.ColumnIndex = Me.dataGridView1.Columns("Rating").Index _
            AndAlso (e.Value IsNot Nothing) Then

            With Me.dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If e.Value.Equals("*") Then
                    .ToolTipText = "very bad"
                ElseIf e.Value.Equals("**") Then
                    .ToolTipText = "bad"
                ElseIf e.Value.Equals("***") Then
                    .ToolTipText = "good"
                ElseIf e.Value.Equals("****") Then
                    .ToolTipText = "very good"
                End If

            End With

        End If

    End Sub 'dataGridView1_CellFormatting
    '</Snippet1>

End Class 'Form1
