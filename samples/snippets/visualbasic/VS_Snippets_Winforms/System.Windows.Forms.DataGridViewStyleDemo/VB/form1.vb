' <snippet10>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private WithEvents dataGridView1 As New DataGridView()

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)

        ' Create the columns and load the data.
        PopulateDataGridView()

        ' Configure the appearance and behavior of the DataGridView.
        InitializeDataGridView()

        ' Initialize the form.
        Me.Text = "DataGridView style demo"
        Me.Size = New Size(600, 250)
        Me.Controls.Add(dataGridView1)
        MyBase.OnLoad(e)

    End Sub

    ' <snippet20>
    ' Configures the appearance and behavior of a DataGridView control.
    Private Sub InitializeDataGridView()

        ' Initialize basic DataGridView properties.
        dataGridView1.Dock = DockStyle.Fill
        dataGridView1.BackgroundColor = Color.LightGray
        dataGridView1.BorderStyle = BorderStyle.Fixed3D

        ' Set property values appropriate for read-only display and 
        ' limited interactivity. 
        dataGridView1.AllowUserToAddRows = False
        dataGridView1.AllowUserToDeleteRows = False
        dataGridView1.AllowUserToOrderColumns = True
        dataGridView1.ReadOnly = True
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dataGridView1.MultiSelect = False
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dataGridView1.AllowUserToResizeColumns = False
        dataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dataGridView1.AllowUserToResizeRows = False
        dataGridView1.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.DisableResizing

        ' Set the selection background color for all the cells.
        dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White
        dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
        ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
        dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        ' Set the background color for all rows and for alternating rows. 
        ' The value for alternating rows overrides the value for all rows. 
        dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray
        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray

        ' Set the row and column header styles.
        dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Black

        ' Set the Format property on the "Last Prepared" column to cause
        ' the DateTime to be formatted as "Month, Year".
        dataGridView1.Columns("Last Prepared").DefaultCellStyle.Format = "y"

        ' Specify a larger font for the "Ratings" column. 
        Dim font As New Font( _
            dataGridView1.DefaultCellStyle.Font.FontFamily, 25, FontStyle.Bold)
        Try
            dataGridView1.Columns("Rating").DefaultCellStyle.Font = font
        Finally
            font.Dispose()
        End Try

    End Sub
    ' </snippet20>

    ' <snippet30>
    ' Changes the foreground color of cells in the "Ratings" column 
    ' depending on the number of stars. 
    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles dataGridView1.CellFormatting

        If e.ColumnIndex = dataGridView1.Columns("Rating").Index _
            AndAlso e.Value IsNot Nothing Then

            Select Case e.Value.ToString().Length
                Case 1
                    e.CellStyle.SelectionForeColor = Color.Red
                    e.CellStyle.ForeColor = Color.Red
                Case 2
                    e.CellStyle.SelectionForeColor = Color.Yellow
                    e.CellStyle.ForeColor = Color.Yellow
                Case 3
                    e.CellStyle.SelectionForeColor = Color.Green
                    e.CellStyle.ForeColor = Color.Green
                Case 4
                    e.CellStyle.SelectionForeColor = Color.Blue
                    e.CellStyle.ForeColor = Color.Blue
            End Select

        End If

    End Sub
    ' </snippet30>

    ' Creates the columns and loads the data.
    Private Sub PopulateDataGridView()

        ' Set the column header names.
        dataGridView1.ColumnCount = 5
        dataGridView1.Columns(0).Name = "Recipe"
        dataGridView1.Columns(1).Name = "Category"
        dataGridView1.Columns(2).Name = "Main Ingredients"
        dataGridView1.Columns(3).Name = "Last Prepared"
        dataGridView1.Columns(4).Name = "Rating"

        ' Populate the rows.
        Dim row1() As Object = {"Meatloaf", "Main Dish", _
            "ground beef", New DateTime(2000, 3, 23), "*"}
        Dim row2() As Object = {"Key Lime Pie", "Dessert", _
            "lime juice, evaporated milk", New DateTime(2002, 4, 12), "****"}
        Dim row3() As Object = {"Orange-Salsa Pork Chops", "Main Dish", _
            "pork chops, salsa, orange juice", New DateTime(2000, 8, 9), "****"}
        Dim row4() As Object = {"Black Bean and Rice Salad", "Salad", _
            "black beans, brown rice", New DateTime(1999, 5, 7), "****"}
        Dim row5() As Object = {"Chocolate Cheesecake", "Dessert", _
            "cream cheese", New DateTime(2003, 3, 12), "***"}
        Dim row6() As Object = {"Black Bean Dip", "Appetizer", _
            "black beans, sour cream", New DateTime(2003, 12, 23), "***"}

        ' Add the rows to the DataGridView.
        Dim rows() As Object = {row1, row2, row3, row4, row5, row6}
        Dim rowArray As Object()
        For Each rowArray In rows
            dataGridView1.Rows.Add(rowArray)
        Next rowArray

        ' Adjust the row heights so that all content is visible.
        dataGridView1.AutoResizeRows( _
            DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)

    End Sub
End Class
' </snippet10>