'<snippet00>
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Private WithEvents sortButton As New Button()
    Private WithEvents dataGridView1 As New DataGridView()

    ' Initializes the form.
    ' You can replace this code with designer-generated code.
    Public Sub New()
        With dataGridView1
            .Dock = DockStyle.Fill
            .AllowUserToAddRows = False
            .SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect
            .MultiSelect = False
        End With

        sortButton.Dock = DockStyle.Bottom
        sortButton.Text = "Sort"
 
        Controls.Add(dataGridView1)
        Controls.Add(sortButton)
        Text = "DataGridView programmatic sort demo"

        PopulateDataGridView()
    End Sub

    ' Establish the main entry point for the application.
    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    '<snippet20>
    ' Populates the DataGridView.
    ' Replace this with your own code to populate the DataGridView.
    Public Sub PopulateDataGridView()

        ' Add columns to the DataGridView.
        dataGridView1.ColumnCount = 2
        dataGridView1.Columns(0).HeaderText = "Last Name"
        dataGridView1.Columns(1).HeaderText = "City"
        ' Put the new columns into programmatic sort mode
        dataGridView1.Columns(0).SortMode = _
            DataGridViewColumnSortMode.Programmatic
        dataGridView1.Columns(1).SortMode = _
            DataGridViewColumnSortMode.Programmatic


        ' Populate the DataGridView.
        dataGridView1.Rows.Add(New String() {"Parker", "Seattle"})
        dataGridView1.Rows.Add(New String() {"Watson", "Seattle"})
        dataGridView1.Rows.Add(New String() {"Osborn", "New York"})
        dataGridView1.Rows.Add(New String() {"Jameson", "New York"})
        dataGridView1.Rows.Add(New String() {"Brock", "New Jersey"})
    End Sub
    '</snippet20>

    '<snippet10>
    Private Sub SortButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles sortButton.Click

        ' Check which column is selected, otherwise set NewColumn to Nothing.
        Dim newColumn As DataGridViewColumn
        If dataGridView1.Columns.GetColumnCount(DataGridViewElementStates _
            .Selected) = 1 Then
            newColumn = dataGridView1.SelectedColumns(0)
        Else
            newColumn = Nothing
        End If

        Dim oldColumn As DataGridViewColumn = dataGridView1.SortedColumn
        Dim direction As ListSortDirection

        ' If oldColumn is null, then the DataGridView is not currently sorted.
        If oldColumn IsNot Nothing Then

            ' Sort the same column again, reversing the SortOrder.
            If oldColumn Is newColumn AndAlso dataGridView1.SortOrder = _
                SortOrder.Ascending Then
                direction = ListSortDirection.Descending
            Else

                ' Sort a new column and remove the old SortGlyph.
                direction = ListSortDirection.Ascending
                oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None
            End If
        Else
            direction = ListSortDirection.Ascending
        End If


        ' If no column has been selected, display an error dialog  box.
        If newColumn Is Nothing Then
            MessageBox.Show("Select a single column and try again.", _
                "Error: Invalid Selection", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        Else
            dataGridView1.Sort(newColumn, direction)
            If direction = ListSortDirection.Ascending Then
                newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
            Else
                newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
            End If
        End If

    End Sub
    '</snippet10>

End Class
'</snippet00>
