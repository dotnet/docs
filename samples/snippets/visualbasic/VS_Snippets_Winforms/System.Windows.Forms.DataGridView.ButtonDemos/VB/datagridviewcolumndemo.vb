'<snippet100>
Imports System.Windows.Forms
Imports System.Drawing

Public Class DataGridViewColumnDemo
    Inherits Form

#Region "set up form"
    Public Sub New()
        InitializeComponent()

        AddButton(Button1, "Reset")
        AddButton(Button2, "Change Column 3 Header")
        AddButton(Button3, "Change Meatloaf Recipe")
        AddAdditionalButtons()
    End Sub

    Friend WithEvents dataGridView As DataGridView
    Friend WithEvents Button1 As Button = New Button()
    Friend WithEvents Button2 As Button = New Button()
    Friend WithEvents Button3 As Button = New Button()
    Friend WithEvents Button4 As Button = New Button()
    Friend WithEvents Button5 As Button = New Button()
    Friend WithEvents Button6 As Button = New Button()
    Friend WithEvents Button7 As Button = New Button()
    Friend WithEvents Button8 As Button = New Button()
    Friend WithEvents Button9 As Button = New Button()
    Friend WithEvents Button10 As Button = New Button()
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel _
        = New FlowLayoutPanel()

    Private Sub InitializeComponent()
        FlowLayoutPanel1.Location = New Point(454, 0)
        FlowLayoutPanel1.AutoSize = True
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel1.Name = "flowlayoutpanel"
        ClientSize = New System.Drawing.Size(614, 360)
        Controls.Add(FlowLayoutPanel1)
        Text = Me.GetType.Name
        AutoSize = True
    End Sub
#End Region

#Region "set up DataGridView"
    Private thirdColumnHeader As String = "Main Ingredients"
    Private boringMeatloaf As String = "ground beef"
    Private boringMeatloafRanking As String = "*"
    Private boringRecipe As Boolean
    Private shortMode As Boolean

    Private Sub InitializeDataGridView(ByVal ignored As Object, _
    ByVal ignoredToo As EventArgs) Handles Me.Load

        dataGridView = New System.Windows.Forms.DataGridView
        Controls.Add(dataGridView)
        dataGridView.Size = New Size(300, 200)

        ' Create an unbound DataGridView by declaring a
        ' column count.
        dataGridView.ColumnCount = 4
        AdjustDataGridViewSizing()

        ' Set the column header style.
        Dim columnHeaderStyle As New DataGridViewCellStyle
        columnHeaderStyle.BackColor = Color.Aqua
        columnHeaderStyle.Font = _
            New Font("Verdana", 10, FontStyle.Bold)
        dataGridView.ColumnHeadersDefaultCellStyle = _
            columnHeaderStyle

        ' Set the column header names.
        dataGridView.Columns(0).Name = "Recipe"
        dataGridView.Columns(1).Name = "Category"
        dataGridView.Columns(2).Name = thirdColumnHeader
        dataGridView.Columns(3).Name = "Rating"

        PostColumnCreation()

        ' Populate the rows.
        Dim row1 As String() = New String() _
            {"Meatloaf", "Main Dish", boringMeatloaf, _
            boringMeatloafRanking}
        Dim row2 As String() = New String() _
            {"Key Lime Pie", "Dessert", _
            "lime juice, evaporated milk", _
            "****"}
        Dim row3 As String() = New String() _
            {"Orange-Salsa Pork Chops", "Main Dish", _
            "pork chops, salsa, orange juice", "****"}
        Dim row4 As String() = New String() _
            {"Black Bean and Rice Salad", "Salad", _
            "black beans, brown rice", _
            "****"}
        Dim row5 As String() = New String() _
            {"Chocolate Cheesecake", "Dessert", "cream cheese", _
            "***"}
        Dim row6 As String() = New String() _
            {"Black Bean Dip", "Appetizer", _
            "black beans, sour cream", _
                "***"}
        Dim rows As Object() = New Object() {row1, row2, _
            row3, row4, row5, row6}

        Dim rowArray As String()
        For Each rowArray In rows
            dataGridView.Rows.Add(rowArray)
        Next

        shortMode = False
        boringRecipe = True
    End Sub

    Private Sub AddButton(ByVal button As Button, _
        ByVal buttonLabel As String)

        FlowLayoutPanel1.Controls.Add(button)
        button.TabIndex = FlowLayoutPanel1.Controls.Count
        button.Text = buttonLabel
        button.AutoSize = True
    End Sub

    Private Sub ResetToDisorder(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button1.Click
        Controls.Remove(dataGridview)
        dataGridView.Dispose()
        InitializeDataGridView(Nothing, Nothing)
    End Sub

    Private Sub ChangeColumn3Header(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button2.Click

        Toggle(shortMode)
        If shortMode Then dataGridView.Columns(2).HeaderText = _
            "S" _
            Else dataGridView.Columns(2).HeaderText = _
                thirdColumnHeader
    End Sub

    Private Shared Sub Toggle(ByRef toggleThis As Boolean)
        toggleThis = Not toggleThis
    End Sub

    Private Sub ChangeMeatloafRecipe(ByVal sender As Object, _
        ByVal e As System.EventArgs) _
        Handles Button3.Click

        Toggle(boringRecipe)
        If boringRecipe Then
            SetMeatloaf(boringMeatloaf, boringMeatloafRanking)
        Else
            Dim greatMeatloafRecipe As String = "1 lb. lean ground beef, " _
                & "1/2 cup bread crumbs, 1/4 cup ketchup," _
                & "1/3 tsp onion powder, " _
                & "1 clove of garlic, 1/2 pack onion soup mix " _
                & " dash of your favorite BBQ Sauce"
            SetMeatloaf(greatMeatloafRecipe, "***")
        End If
    End Sub

    Private Sub SetMeatloaf(ByVal recipe As String, _
        ByVal rating As String)

        dataGridView.Rows(0).Cells(2).Value = recipe
        dataGridView.Rows(0).Cells(3).Value = rating
    End Sub
#End Region

#Region "demonstration code"
    Private Sub PostColumnCreation()
        AddContextLabel()
        AddCriteriaLabel()
        CustomizeCellsInThirdColumn()
        AddContextMenu()
        SetDefaultCellInFirstColumn()
        ToolTips()
    End Sub

    Private criteriaLabel As String = "Column 3 sizing criteria: "
    Private Sub AddCriteriaLabel()
        AddLabelToPanelIfNotAlreadyThere(criteriaLabel, _
            criteriaLabel & _
            dataGridView.Columns(2).AutoSizeMode.ToString() _
            & ".")
    End Sub

    Private Sub AddContextLabel()
        Dim labelName As String = "label"
        AddLabelToPanelIfNotAlreadyThere(labelName, _
            "Use shortcut menu to change cell color.")
    End Sub

    Private Sub AddLabelToPanelIfNotAlreadyThere( _
    ByVal labelName As String, _
    ByVal labelText As String)

        Dim label As Label
        If FlowLayoutPanel1.Controls(labelName) Is Nothing Then
            label = New Label()
            label.AutoSize = True
            label.Name = labelName
            label.BackColor = Color.Bisque
            FlowLayoutPanel1.Controls.Add(label)
        Else
            label = CType(FlowLayoutPanel1.Controls(labelName), Label)
        End If
        label.Text = labelText
    End Sub

    '<snippet120>
    Private Sub CustomizeCellsInThirdColumn()

        Dim thirdColumn As Integer = 2
        Dim column As DataGridViewColumn = _
            dataGridView.Columns(thirdColumn)
        Dim cell As DataGridViewCell = _
            New DataGridViewTextBoxCell()

        cell.Style.BackColor = Color.Wheat
        column.CellTemplate = cell
    End Sub
    '</snippet120>

    '<snippet130>
    WithEvents toolStripItem1 As New ToolStripMenuItem()

    Private Sub AddContextMenu()
        toolStripItem1.Text = "Redden"
        Dim strip As New ContextMenuStrip()
        For Each column As DataGridViewColumn _
            In dataGridView.Columns()

            column.ContextMenuStrip = strip
            column.ContextMenuStrip.Items.Add(toolStripItem1)
        Next
    End Sub
    ' Change the cell's color.
    Private Sub toolStripItem1_Click(ByVal sender As Object, _
        ByVal args As EventArgs) _
        Handles toolStripItem1.Click

        dataGridView.Rows(mouseLocation.RowIndex) _
            .Cells(mouseLocation.ColumnIndex) _
            .Style.BackColor = Color.Red
    End Sub

    Private mouseLocation As DataGridViewCellEventArgs

    ' Deal with hovering over a cell.
    Private Sub dataGridView_CellMouseEnter(ByVal sender As Object, _
        ByVal location As DataGridViewCellEventArgs) _
        Handles DataGridView.CellMouseEnter

        mouseLocation = location
    End Sub
    '</snippet130>

    '<snippet140>
    Private Sub SetDefaultCellInFirstColumn()
        Dim firstColumn As DataGridViewColumn = _
            dataGridView.Columns(0)
        Dim cellStyle As DataGridViewCellStyle = _
            New DataGridViewCellStyle()
        cellStyle.BackColor = Color.Thistle

        firstColumn.DefaultCellStyle = cellStyle
    End Sub
    '</snippet140>

    '<snippet145>
    Private Sub ToolTips()
        Dim firstColumn As DataGridViewColumn = _
            dataGridView.Columns(0)
        Dim thirdColumn As DataGridViewColumn = _
            dataGridView.Columns(2)
        firstColumn.ToolTipText = _
            "This is column uses a default cell."
        thirdColumn.ToolTipText = _
            "This is column uses a template cell." _
            & " Changes to one cell's style changes them all."
    End Sub
    '</snippet145>

    Private Sub AddAdditionalButtons()
        AddButton(Button4, "Set Minimum Width of Column Two")
        AddButton(Button5, "Set Width of Column One")
        AddButton(Button6, "Autosize Third Column")
        AddButton(Button7, "Add Thick Vertical Edge")
        AddButton(Button8, "Style and Number Columns")
        AddButton(Button9, "Change Column Header Text")
        AddButton(Button10, "Swap First and Last Columns")
    End Sub

    Private Sub AdjustDataGridViewSizing()
        dataGridView.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.AutoSize
    End Sub

    '<snippet107>
    'Set the minimum width.
    Private Sub Button4_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button4.Click

        Dim column As DataGridViewColumn = dataGridView.Columns(1)
        column.MinimumWidth = 40
    End Sub
    '</snippet107> 

    '<snippet108>
    ' Set the width.
    Private Sub Button5_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button5.Click

        Dim column As DataGridViewColumn = dataGridView.Columns(0)
        column.Width = 60
    End Sub
    '</snippet108>

    '<snippet109>
    ' AutoSize the third column.
    Private Sub Button6_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button6.Click

        Dim column As DataGridViewColumn = dataGridView.Columns(2)
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub
    '</snippet109>

    '<snippet110>
    ' Set the vertical edge.
    Private Sub Button7_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button7.Click

        Dim thirdColumn As Integer = 2
        Dim column As DataGridViewColumn = _
            dataGridView.Columns(thirdColumn)
        column.DividerWidth = 10

    End Sub
    '</snippet110>

    '<snippet150>
    ' Style and number columns.
    Private Sub Button8_Click(ByVal sender As Object, _
        ByVal args As EventArgs) Handles Button8.Click

        Dim style As DataGridViewCellStyle = _
            New DataGridViewCellStyle()
        style.Alignment = _
            DataGridViewContentAlignment.MiddleCenter
        style.ForeColor = Color.IndianRed
        style.BackColor = Color.Ivory

        For Each column As DataGridViewColumn _
            In dataGridView.Columns

            column.HeaderCell.Value = _
                column.Index.ToString
            column.HeaderCell.Style = style
        Next
    End Sub
    '</snippet150>

    '<snippet160>
    ' Change the text in the column header.
    Private Sub Button9_Click(ByVal sender As Object, _
        ByVal args As EventArgs) Handles Button9.Click

        For Each column As DataGridViewColumn _
            In dataGridView.Columns

            column.HeaderText = String.Concat("Column ", _
                column.Index.ToString)
        Next
    End Sub
    '</snippet160>

    '<snippet170>
    ' Swap the last column with the first.
    Private Sub Button10_Click(ByVal sender As Object, _
        ByVal args As EventArgs) Handles Button10.Click

        Dim columnCollection As DataGridViewColumnCollection = _
            dataGridView.Columns

        Dim firstVisibleColumn As DataGridViewColumn = _
            columnCollection.GetFirstColumn(DataGridViewElementStates.Visible)
        Dim lastVisibleColumn As DataGridViewColumn = _
            columnCollection.GetLastColumn(DataGridViewElementStates.Visible, _
            Nothing)

        Dim firstColumn_sIndex As Integer = firstVisibleColumn.DisplayIndex
        firstVisibleColumn.DisplayIndex = _
            lastVisibleColumn.DisplayIndex
        lastVisibleColumn.DisplayIndex = firstColumn_sIndex
    End Sub
    '</snippet170>

    '<snippet180>
    ' Updated the criteria label.
    Private Sub dataGridView_AutoSizeColumnCriteriaChanged( _
        ByVal sender As Object, _
        ByVal args As DataGridViewAutoSizeColumnModeEventArgs) _
        Handles DataGridView.AutoSizeColumnModeChanged

        args.Column.DataGridView.Parent. _
        Controls("flowlayoutpanel"). _
        Controls(criteriaLabel).Text = _
            criteriaLabel & args.Column.AutoSizeMode.ToString
    End Sub
    '</snippet180>
#End Region

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New DataGridViewColumnDemo())
    End Sub

End Class
'</snippet100>