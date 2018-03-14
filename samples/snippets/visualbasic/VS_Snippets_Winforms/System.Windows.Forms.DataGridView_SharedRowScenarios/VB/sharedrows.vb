'<snippet0>
Imports System.Windows.Forms
Imports System
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Data

Class SharedRows
    Inherits Form

    Private WithEvents dataGridView1 As New DataGridView()
    Private counterLabel As New Label()
    Private description As Label = New Label
    Private leftToRight As New FlowLayoutPanel()
    Private topToBottom As New FlowLayoutPanel()

    Public Sub New()
        AutoSize = True
        Controls.Add(topToBottom)
    End Sub

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New SharedRows())
    End Sub

    Private Sub SharedRows_Load(ByVal ignored As Object, ByVal e As EventArgs) Handles Me.Load

        counterLabel.Text = "Unshared Rows: "
        counterLabel.AutoSize = True
        count.AutoSize = True

        description.MaximumSize = New Size(600, 300)
        description.AutoSize = True
        description.Text = _
            "Try out the contextual menu, and hovering over the cells in the 'ReportsTo' column. " & _
            "Notice what happens when trying to lookup a picture cell. " & _
            "Row unsharing is minimized through the use of events."

        leftToRight.FlowDirection = FlowDirection.LeftToRight
        leftToRight.Controls.AddRange(New Control() {dataGridView1, counterLabel, count})
        leftToRight.AutoSize = True

        topToBottom.FlowDirection = FlowDirection.TopDown
        topToBottom.AutoSize = True
        topToBottom.Controls.AddRange(New Control() {leftToRight, description})

        dataGridView1.MaximumSize = New Size(500, 300)
        dataGridView1.AutoSize = True
        dataGridView1.MultiSelect = False
        dataGridView1.ReadOnly = True
        dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
        dataGridView1.AllowUserToAddRows = False
        dataGridView1.AllowUserToDeleteRows = False
        dataGridView1.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.DataSource = Populate("Select * from employees", True)
    End Sub

    '<snippet20>
    '<snippet22>
    '<snippet24>
    Private WithEvents wholeTable As New ToolStripMenuItem()
    Private WithEvents lookUp As New ToolStripMenuItem()
    Private strip As ContextMenuStrip
    Private cellErrorText As String

    Private Sub dataGridView1_CellContextMenuStripNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewCellContextMenuStripNeededEventArgs) _
        Handles dataGridView1.CellContextMenuStripNeeded

        cellErrorText = String.Empty

        If strip Is Nothing Then
            strip = New ContextMenuStrip()
            lookUp.Text = "Look Up"
            wholeTable.Text = "See Whole Table"
            strip.Items.Add(lookUp)
            strip.Items.Add(wholeTable)
        End If
        e.ContextMenuStrip = strip
    End Sub

    Private Sub wholeTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles wholeTable.Click
        dataGridView1.DataSource = Populate("Select * from employees", True)
    End Sub

    Private theCellImHoveringOver As DataGridViewCellEventArgs

    Private Sub dataGridView1_CellMouseEnter(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellMouseEnter

        theCellImHoveringOver = e
    End Sub

    Private cellErrorLocation As DataGridViewCellEventArgs

    Private Sub lookUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lookUp.Click
        Try
            dataGridView1.DataSource = Populate("Select * from employees where " & _
                dataGridView1.Columns(theCellImHoveringOver.ColumnIndex).Name & " = '" & _
                dataGridView1.Rows(theCellImHoveringOver.RowIndex).Cells(theCellImHoveringOver.ColumnIndex).Value.ToString() & _
                "'", True)
        Catch ex As SqlException
            cellErrorText = "Can't look this cell up"
            cellErrorLocation = theCellImHoveringOver
        End Try
    End Sub

    Private Sub dataGridView1_CellErrorTextNeeded(ByVal sender As Object, _
                ByVal e As DataGridViewCellErrorTextNeededEventArgs) _
                Handles dataGridView1.CellErrorTextNeeded
        If (Not cellErrorLocation Is Nothing) Then
            If e.ColumnIndex = cellErrorLocation.ColumnIndex AndAlso _
                e.RowIndex = cellErrorLocation.RowIndex Then
                e.ErrorText = cellErrorText
            End If
        End If
    End Sub

    '<snippet30>
    Private Function Populate(ByVal query As String, ByVal resetUnsharedCounter As Boolean) As DataTable

        If resetUnsharedCounter Then
            ResetCounter()
        End If

        ' Alter the data source as necessary
        Dim adapter As New SqlDataAdapter(query, _
            New SqlConnection("Integrated Security=SSPI;Persist Security Info=False;" & _
            "Initial Catalog=Northwind;Data Source=localhost"))

        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter.Fill(table)
        Return table
    End Function

    Private count As New Label()
    Private unsharedRowCounter As Integer

    Private Sub ResetCounter()
        unsharedRowCounter = 0
        count.Text = unsharedRowCounter.ToString()
    End Sub
    '</snippet24>
    '</snippet22>
    '</snippet20>

    Private Sub DataGridView1_CellToolTipTextNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewCellToolTipTextNeededEventArgs) _
        Handles dataGridView1.CellToolTipTextNeeded

        If theCellImHoveringOver.ColumnIndex = dataGridView1.Columns("ReportsTo").Index AndAlso _
                theCellImHoveringOver.RowIndex > -1 Then

            Dim reportsTo As String = dataGridView1.Rows(theCellImHoveringOver.RowIndex). _
                Cells(theCellImHoveringOver.ColumnIndex).Value.ToString()
            If String.IsNullOrEmpty(reportsTo) Then
                e.ToolTipText = "The buck stops here!"
            Else
                Dim table As DataTable = Populate( _
                    "select firstname, lastname from employees where employeeid = '" & _
                    dataGridView1.Rows(theCellImHoveringOver.RowIndex). _
                    Cells(theCellImHoveringOver.ColumnIndex).Value.ToString() & _
                    "'", False)

                e.ToolTipText = "Reports to " & table.Rows(0).Item(0).ToString() & " " & table.Rows(0).Item(1).ToString()
            End If
        End If
    End Sub
    '</snippet30>

    Private Sub dataGridView1_RowUnshared(ByVal sender As Object, ByVal row As DataGridViewRowEventArgs) Handles dataGridView1.RowUnshared
        unsharedRowCounter += 1
        count.Text = unsharedRowCounter.ToString()
    End Sub

End Class
'</snippet0>
