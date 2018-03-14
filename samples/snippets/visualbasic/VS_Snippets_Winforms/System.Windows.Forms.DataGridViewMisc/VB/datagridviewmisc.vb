' This file is for miscellaneous, tiny snippets that do not need to exist within a wider scope.
' Do not wrap the entire file in a snippet tag for use in any topic.

Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing

Public Class DataGridViewMisc
    Inherits Form

    Private WithEvents dataGridView1 As New DataGridView()

    <STAThreadAttribute()> _
    Public Shared Sub Main()

    End Sub

    ' How to: Add an Unbound Column to a Data-Bound Windows Forms DataGridView Control
    '<Snippet010>
    Private Sub CreateUnboundButtonColumn()

        ' Initialize the button column.
        Dim buttonColumn As New DataGridViewButtonColumn

        With buttonColumn
            .HeaderText = "Details"
            .Name = "Details"
            .Text = "View Details"

            ' Use the Text property for the button text for all cells rather
            ' than using each cell's value as the text for its own button.
            .UseColumnTextForButtonValue = True
        End With

        ' Add the button column to the control.
        dataGridView1.Columns.Insert(0, buttonColumn)

    End Sub
    '</Snippet010>

    ' How to: Autogenerate Columns in a Data-Bound Windows Forms DataGridView Control
    Private customersDataGridView As New DataGridView()
    Private customersDataSet As New DataSet()
    '<Snippet020>
    Private Sub BindData()

        With customersDataGridView
            .AutoGenerateColumns = True
            .DataSource = customersDataSet
            .DataMember = "Customers"
        End With

    End Sub
    '</Snippet020>

    ' How to: Change the Border and Gridline Styles in the Windows Forms DataGridView Control
    '<Snippet030>
    Private Sub SetBorderAndGridlineStyles()

        With Me.dataGridView1
            .GridColor = Color.BlueViolet
            .BorderStyle = BorderStyle.Fixed3D
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .RowHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
        End With

    End Sub
    '</Snippet030>

    ' This version of the above is necessary for the sub-snippets, given the With above.
    Private Sub SetBorderAndGridlineStyles2()

        '<Snippet031>
        Me.dataGridView1.GridColor = Color.BlueViolet
        '</Snippet031>
        '<Snippet032>
        Me.dataGridView1.BorderStyle = BorderStyle.Fixed3D
        '</Snippet032>
        '<Snippet033>
        With Me.dataGridView1
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .RowHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Single
        End With
        '</Snippet033>

    End Sub

    ' How to: Change the Order of the Columns in the Windows Forms DataGridView Control
    '<Snippet040>
    Private Sub AdjustColumnOrder()

        With customersDataGridView
            .Columns("CustomerID").Visible = False
            .Columns("ContactName").DisplayIndex = 0
            .Columns("ContactTitle").DisplayIndex = 1
            .Columns("City").DisplayIndex = 2
            .Columns("Country").DisplayIndex = 3
            .Columns("CompanyName").DisplayIndex = 4
        End With

    End Sub
    '</Snippet040>

    ' 1 of 2 for How to: Display Images in Cells of the Windows Forms DataGridView Control
    '<Snippet050>
    Public Sub CreateGraphicsColumn()

        Dim treeIcon As New Icon(Me.GetType(), "tree.ico")
        Dim iconColumn As New DataGridViewImageColumn()

        With iconColumn
            .Image = treeIcon.ToBitmap()
            .Name = "Tree"
            .HeaderText = "Nice tree"
        End With

        dataGridView1.Columns.Insert(2, iconColumn)

    End Sub
    '</Snippet050>

    ' 2 of 2 for How to: Display Images in Cells of the Windows Forms DataGridView Control
    '<Snippet055>
    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
        Handles dataGridView1.CellFormatting

        If dataGridView1.Columns(e.ColumnIndex).Name = "Icon" Then
            If e.RowIndex Mod 5 = 0 Then
                Dim bmp As New Bitmap(Me.GetType(), "Bitmap2.bmp")
                e.Value = bmp
            End If
        End If

    End Sub
    '</Snippet055>

    ' Put one- and two-liners that don't really need to be wrapped in methods here.
    ' If more than ten tiny snippets are needed, create a TinySnippet2() method. 
    Private Sub TinySnippets()

        ' How to: Enable Column Reordering in the Windows Forms DataGridView Control
        '<Snippet060>
        dataGridView1.AllowUserToOrderColumns = True
        '</Snippet060>

        ' How to: Freeze Columns in the Windows Forms DataGridView Control
        '<Snippet061>
        Me.dataGridView1.Columns("AddToCartButton").Frozen = True
        '</Snippet061>

        ' How to: Hide Column Headers in the Windows Forms DataGridView Control
        '<Snippet062>
        dataGridView1.ColumnHeadersVisible = False
        '</Snippet062>

        ' How to: Hide Columns in the Windows Forms DataGridView Control
        '<Snippet063>
        Me.dataGridView1.Columns("CustomerID").Visible = False
        '</Snippet063>

        ' How to: Make Columns in the Windows Forms DataGridView Control Read-Only
        '<Snippet064>
        dataGridView1.Columns("CompanyName").ReadOnly = True
        '</Snippet064>

        ' How to: Set the Selection Mode of the Windows Forms DataGridView Control
        '<Snippet065>
        With Me.dataGridView1
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
        '</Snippet065>

        ' How to: Set the Sort Modes for Columns in the Windows Forms DataGridView Control
        '<Snippet066>
        Me.dataGridView1.Columns("Priority").SortMode = _
            DataGridViewColumnSortMode.Automatic
        '</Snippet066>

        ' How to: Specify the Edit Mode for the Windows Forms DataGridView Control
        '<Snippet067>
        Me.dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
        '</Snippet067>

        ' How to: Set Alternating Row Styles for the Windows Forms DataGridView Control
        '<Snippet068>
        With Me.dataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        '</Snippet068>

        '<Snippet069>
        Me.dataGridView1.EditingPanel.BorderStyle = BorderStyle.Fixed3D
        '</Snippet069>

    End Sub

    ' How to: Format Data in the Windows Forms DataGridView Control
    '<Snippet070>
    Private Sub SetFormatting()
        With Me.dataGridView1
            .Columns("UnitPrice").DefaultCellStyle.Format = "c"
            .Columns("ShipDate").DefaultCellStyle.Format = "d"
            .Columns("CustomerName").DefaultCellStyle.Alignment = _
                DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.NullValue = "no entry"
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
        End With
    End Sub
    '</Snippet070>

    ' This version of the above is necessary for the sub-snippets, given the With above.
    Private Sub SetFormatting2()
        '<Snippet071>
        Me.dataGridView1.Columns("UnitPrice").DefaultCellStyle.Format = "c"
        Me.dataGridView1.Columns("ShipDate").DefaultCellStyle.Format = "d"
        '</Snippet071>

        '<Snippet072>
        Me.dataGridView1.Columns("CustomerName").DefaultCellStyle _
            .Alignment = DataGridViewContentAlignment.MiddleRight
        '</Snippet072>

        '<Snippet073>
        Me.dataGridView1.DefaultCellStyle.NullValue = "no entry"
        '</Snippet073>

        '<Snippet074>
        Me.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        '</Snippet074>
    End Sub

    ' 1 of 2 for How to: Get and Set the Current Cell in the Windows Forms DataGridView Control
    Private WithEvents getCurrentCellButton As New Button()
    '<Snippet080>
    Private Sub getCurrentCellButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles getCurrentCellButton.Click

        Dim msg As String = String.Format("Row: {0}, Column: {1}", _
            dataGridView1.CurrentCell.RowIndex, _
            dataGridView1.CurrentCell.ColumnIndex)
        MessageBox.Show(msg, "Current Cell")

    End Sub
    '</Snippet080>

    ' 2 of 2 for How to: Get and Set the Current Cell in the Windows Forms DataGridView Control
    Private WithEvents setCurrentCellButton As New Button()
    '<Snippet085>
    Private Sub setCurrentCellButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles setCurrentCellButton.Click

        ' Set the current cell to the cell in column 1, Row 0. 
        Me.dataGridView1.CurrentCell = Me.dataGridView1(1, 0)

    End Sub
    '</Snippet085>

    ' How to: Prevent Row Addition and Deletion in the Windows Forms DataGridView Control
    '<Snippet090>
    Private Sub MakeReadOnly()

        With dataGridView1
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
        End With

    End Sub
    '</Snippet090>

    ' How to: Set Font and Color Styles in the Windows Forms DataGridView Control
    '<Snippet100>
    Private Sub SetFontAndColors()

        With Me.dataGridView1.DefaultCellStyle
            .Font = New Font("Tahoma", 15)
            .ForeColor = Color.Blue
            .BackColor = Color.Beige
            .SelectionForeColor = Color.Yellow
            .SelectionBackColor = Color.Black
        End With

    End Sub
    '</Snippet100>

    ' This version of the above is necessary for the sub-snippets, given the With above.
    Private Sub SetFontAndColors2()

        '<Snippet101>
        Me.dataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 15)
        '</Snippet101>

        '<Snippet102>
        Me.dataGridView1.DefaultCellStyle.ForeColor = Color.Blue
        Me.dataGridView1.DefaultCellStyle.BackColor = Color.Beige
        '</Snippet102>

        '<Snippet103>
        Me.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow
        Me.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black
        '</Snippet103>

    End Sub

    ' How to: Remove Autogenerated Columns from a Windows Forms DataGridView Control
    '<Snippet110>
    Private Sub BindDataAndInitializeColumns()

        With dataGridView1
            .AutoGenerateColumns = True
            .DataSource = customersDataSet
            .Columns.Remove("Fax")
            .Columns("CustomerID").Visible = False
        End With

    End Sub
    '</Snippet110>

    ' This version of the above is necessary for the sub-snippets, given the With above.
    Private Sub BindDataAndInitializeColumns2()

        '<Snippet111>
        With dataGridView1
            .AutoGenerateColumns = True
            .DataSource = customersDataSet
            .Columns.Remove("Fax")
        End With
        '</Snippet111>
        '<Snippet112>
        dataGridView1.Columns("CustomerID").Visible = False
        '</Snippet112>

    End Sub

    ' How to: Specify Default Values for New Rows in the Windows Forms DataGridView Control
    Private Function NewCustomerId() As Object
        Return New Object()
    End Function
    '<Snippet120>
    Private Sub dataGridView1_DefaultValuesNeeded(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) _
        Handles dataGridView1.DefaultValuesNeeded

        With e.Row
            .Cells("Region").Value = "WA"
            .Cells("City").Value = "Redmond"
            .Cells("PostalCode").Value = "98052-6399"
            .Cells("Country").Value = "USA"
            .Cells("CustomerID").Value = NewCustomerId()
        End With

    End Sub
    '</Snippet120>

    ' 1 of 2 for How to: Perform a Custom Action Based on Changes in a Cell of a Windows Forms DataGridView Control
    '<Snippet130>
    Private Sub dataGridView1_CellValueChanged(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellValueChanged

        Dim msg As String = String.Format( _
            "Cell at row {0}, column {1} value changed", _
            e.RowIndex, e.ColumnIndex)
        MessageBox.Show(msg, "Cell Value Changed")

    End Sub
    '</Snippet130>

    ' 2 of 2 for How to: Perform a Custom Action Based on Changes in a Cell of a Windows Forms DataGridView Control
    '<Snippet135>
    Private Sub dataGridView1_CellStateChanged(ByVal sender As Object, _
        ByVal e As DataGridViewCellStateChangedEventArgs) _
        Handles dataGridView1.CellStateChanged

        Dim state As DataGridViewElementStates = e.StateChanged
        Dim msg As String = String.Format( _
            "Row {0}, Column {1}, {2}", _
            e.Cell.RowIndex, e.Cell.ColumnIndex, e.StateChanged)
        MessageBox.Show(msg, "Cell State Changed")

    End Sub
    '</Snippet135>

    ' How to: Set Default Cell Styles for the Windows Forms DataGridView Control
    '<Snippet140>
    Private Sub SetDefaultCellStyles()

        Dim highlightCellStyle As New DataGridViewCellStyle
        highlightCellStyle.BackColor = Color.Red

        Dim currencyCellStyle As New DataGridViewCellStyle
        currencyCellStyle.Format = "C"
        currencyCellStyle.ForeColor = Color.Green

        With Me.dataGridView1
            .DefaultCellStyle.BackColor = Color.Beige
            .DefaultCellStyle.Font = New Font("Tahoma", 12)
            .Rows(3).DefaultCellStyle = highlightCellStyle
            .Rows(8).DefaultCellStyle = highlightCellStyle
            .Columns("UnitPrice").DefaultCellStyle = currencyCellStyle
            .Columns("TotalPrice").DefaultCellStyle = currencyCellStyle
        End With

    End Sub
    '</Snippet140>

    ' This version of the above is necessary for the sub-snippets, given the With above.
    Private Sub SetDefaultCellStyles2()

        '<Snippet141>
        Me.dataGridView1.DefaultCellStyle.BackColor = Color.Beige
        Me.dataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 12)
        '</Snippet141>

        '<Snippet142>
        Dim highlightCellStyle As New DataGridViewCellStyle
        highlightCellStyle.BackColor = Color.Red

        Dim currencyCellStyle As New DataGridViewCellStyle
        currencyCellStyle.Format = "C"
        currencyCellStyle.ForeColor = Color.Green
        '</Snippet142>

        '<Snippet143>
        With Me.dataGridView1
            .Rows(3).DefaultCellStyle = highlightCellStyle
            .Rows(8).DefaultCellStyle = highlightCellStyle
            .Columns("UnitPrice").DefaultCellStyle = currencyCellStyle
            .Columns("TotalPrice").DefaultCellStyle = currencyCellStyle
        End With
        '</Snippet143>

    End Sub

    '<Snippet150>
    Private Sub dataGridView1_Sorted(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles dataGridView1.Sorted

        Me.dataGridView1.FirstDisplayedCell = Me.dataGridView1.CurrentCell

    End Sub
    '</Snippet150>

    '<Snippet160>
    Private Sub dataGridView1_ColumnHeaderMouseClick(ByVal sender As Object, _
        ByVal e As DataGridViewCellMouseEventArgs) _
        Handles dataGridView1.ColumnHeaderMouseClick

        Dim newColumn As DataGridViewColumn = _
            dataGridView1.Columns(e.ColumnIndex)
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

        ' Sort the selected column.
        dataGridView1.Sort(newColumn, direction)
        If direction = ListSortDirection.Ascending Then
            newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
        Else
            newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
        End If

    End Sub

    Private Sub dataGridView1_DataBindingComplete(ByVal sender As Object, _
        ByVal e As DataGridViewBindingCompleteEventArgs) _
        Handles dataGridView1.DataBindingComplete

        ' Put each of the columns into programmatic sort mode.
        For Each column As DataGridViewColumn In dataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.Programmatic
        Next
    End Sub
    '</Snippet160>

    Dim WithEvents clearSelectionButton As Button
    '<Snippet170>
    Private Sub clearSelectionButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles clearSelectionButton.Click

        dataGridView1.ClearSelection()

    End Sub
    '</Snippet170>

    Dim WithEvents selectAllButton As Button
    '<Snippet180>
    Private Sub selectAllButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles clearSelectionButton.Click

        dataGridView1.SelectAll()

    End Sub
    '</Snippet180>

    '<Snippet190>
    Private Sub dataGridView1_CellEnter(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellEnter

        dataGridView1(e.ColumnIndex, e.RowIndex).Style _
            .SelectionBackColor = Color.Blue

    End Sub

    Private Sub dataGridView1_CellLeave(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellLeave

        dataGridView1(e.ColumnIndex, e.RowIndex).Style _
            .SelectionBackColor = Color.Empty

    End Sub
    '</Snippet190>

    '<Snippet200>
    Private Sub dataGridView1_RowEnter(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.RowEnter

        Dim i As Integer
        For i = 0 To dataGridView1.Rows(e.RowIndex).Cells.Count - 1
            dataGridView1(i, e.RowIndex).Style _
                .BackColor = Color.Yellow
        Next i

    End Sub

    Private Sub dataGridView1_RowLeave(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.RowLeave

        Dim i As Integer
        For i = 0 To dataGridView1.Rows(e.RowIndex).Cells.Count - 1
            dataGridView1(i, e.RowIndex).Style _
                .BackColor = Color.Empty
        Next i

    End Sub
    '</Snippet200>

    '<Snippet210>
    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, _
        ByVal e As DataGridViewEditingControlShowingEventArgs) _
        Handles dataGridView1.EditingControlShowing

        e.CellStyle.BackColor = Color.Aquamarine

    End Sub
    '</Snippet210>

    '<Snippet220>
    Private Sub dataGridView1_CellBeginEdit(ByVal sender As Object, _
        ByVal e As DataGridViewCellCancelEventArgs) _
        Handles DataGridView1.CellBeginEdit

        Dim msg As String = _
            String.Format("Editing Cell at ({0}, {1})", _
            e.ColumnIndex, e.RowIndex)
        Me.Text = msg

    End Sub

    Private Sub dataGridView1_CellEndEdit(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellEndEdit

        Dim msg As String = _
            String.Format("Finished Editing Cell at ({0}, {1})", _
            e.ColumnIndex, e.RowIndex)
        Me.Text = msg

    End Sub
    '</Snippet220>

    Private Sub DemonstrateIndexer()

        '<Snippet230>
        ' Retrieve the cell value for the cell at column 3, row 7.
        Dim testValue1 As String = CStr(dataGridView1(3, 7).Value)

        ' Retrieve the cell value for the cell in the Name column at row 4.
        Dim testValue2 As String = CStr(dataGridView1("Name", 4).Value)
        '</Snippet230>

    End Sub

End Class
