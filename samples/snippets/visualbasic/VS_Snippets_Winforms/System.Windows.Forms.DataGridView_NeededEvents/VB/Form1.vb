'<snippet00>
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Class Form1
    Inherits Form

    Private WithEvents dataGridView1 As New DataGridView()
    Private WithEvents employeeMenuStrip As New ContextMenuStrip()
    Private WithEvents managerMenuStrip As New ContextMenuStrip()
    Private WithEvents toolStripMenuItem1 As New ToolStripMenuItem()
    Private WithEvents toolStripMenuItem2 As New ToolStripMenuItem()
    Private WithEvents toolStripMenuItem3 As New ToolStripMenuItem()

    Private contextMenuRowIndex As Integer

    Public Sub New()
        Me.Size = New Size(700, 300)
        Me.Controls.Add(dataGridView1)

        toolStripMenuItem1.Text = "View Employee Sales Report"
        toolStripMenuItem2.Text = "View Team Sales Report"
        toolStripMenuItem3.Text = "View Company Sales Team Ranking Report"

        With employeeMenuStrip
            .Items.Add(toolStripMenuItem1)
        End With
        With managerMenuStrip
            .Items.Add(toolStripMenuItem2)
            .Items.Add(toolStripMenuItem3)
        End With

        PopulateDataGridView()
    End Sub

    ' Establish the main entry point for the application.
    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private Sub PopulateDataGridView()

        With dataGridView1
            .Dock = DockStyle.Fill
            .AllowUserToAddRows = False
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToDeleteRows = False
        End With

        Dim query As String
        query = "SELECT e1.*, e2.FirstName + ' ' + e2.LastName AS Manager "
        query &= "FROM employees AS e1 LEFT JOIN employees AS e2 "
        query &= "ON e1.ReportsTo = e2.EmployeeID"

        ' Connect to the database
        Dim sqlConnection1 As New SqlConnection( _
            "Integrated Security=SSPI;Persist Security Info=False;" & _
            "Initial Catalog=Northwind;Data Source=localhost")
        Dim sqlDataAdapter1 As New SqlDataAdapter(query, _
            sqlConnection1)

        Dim dataTable1 As New System.Data.DataTable()
        dataTable1.Locale = System.Globalization.CultureInfo.InvariantCulture
        sqlDataAdapter1.Fill(dataTable1)

        dataGridView1.DataSource = dataTable1
    End Sub

    '<snippet05>
    Private Sub dataGridView1_DataBindingComplete(ByVal sender As Object, _
    ByVal e As DataGridViewBindingCompleteEventArgs) _
    Handles dataGridView1.DataBindingComplete

        ' Hide some of the columns.
        With dataGridView1
            .Columns("EmployeeID").Visible = False
            .Columns("Address").Visible = False
            .Columns("TitleOfCourtesy").Visible = False
            .Columns("BirthDate").Visible = False
            .Columns("HireDate").Visible = False
            .Columns("PostalCode").Visible = False
            .Columns("Photo").Visible = False
            .Columns("Notes").Visible = False
            .Columns("ReportsTo").Visible = False
            .Columns("PhotoPath").Visible = False
        End With

        ' Disable sorting for the DataGridView.
        Dim i As DataGridViewColumn
        For Each i In dataGridView1.Columns
            i.SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        dataGridView1.AutoResizeColumns()

    End Sub
    '</snippet05>

    '<snippet10>
    Public Sub dataGridView1_RowContextMenuStripNeeded( _
        ByVal sender As Object, _
        ByVal e As DataGridViewRowContextMenuStripNeededEventArgs) _
        Handles dataGridView1.RowContextMenuStripNeeded

        Dim dataGridViewRow1 As DataGridViewRow = _
        dataGridView1.Rows(e.RowIndex)

        toolStripMenuItem1.Enabled = True

        ' Show the appropriate ContextMenuStrip based on the employees title.
        If dataGridViewRow1.Cells("Title").Value.ToString() = _
            "Sales Manager" OrElse _
            dataGridViewRow1.Cells("Title").Value.ToString() = _
            "Vice President, Sales" Then

            e.ContextMenuStrip = managerMenuStrip
        Else
            e.ContextMenuStrip = employeeMenuStrip
        End If

        contextMenuRowIndex = e.RowIndex
    End Sub
    '</snippet10>

    '<snippet20>
    Public Sub dataGridView1_CellToolTipTextNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewCellToolTipTextNeededEventArgs) _
        Handles dataGridView1.CellToolTipTextNeeded

        Dim newLine As String = Environment.NewLine
        If e.RowIndex > -1 Then
            Dim dataGridViewRow1 As DataGridViewRow = _
            dataGridView1.Rows(e.RowIndex)

            ' Add the employee's ID to the ToolTipText.
            e.ToolTipText = String.Format("EmployeeID {0}: {1}", _
                dataGridViewRow1.Cells("EmployeeID").Value.ToString(), _
                newLine)

            ' Add the employee's name to the ToolTipText.
            e.ToolTipText += String.Format("{0} {1} {2} {3}", _
                dataGridViewRow1.Cells("TitleOfCourtesy").Value.ToString(), _
                dataGridViewRow1.Cells("FirstName").Value.ToString(), _
                dataGridViewRow1.Cells("LastName").Value.ToString(), _
                newLine)

            ' Add the employee's title to the ToolTipText.
            e.ToolTipText += String.Format("{0}{1}{2}", _
                dataGridViewRow1.Cells("Title").Value.ToString(), _
                newLine, newLine)

            ' Add the employee's contact information to the ToolTipText.
            e.ToolTipText += String.Format("{0}{1}{2}, ", _
                dataGridViewRow1.Cells("Address").Value.ToString(), newLine, _
                dataGridViewRow1.Cells("City").Value.ToString())
            If Not String.IsNullOrEmpty( _
                dataGridViewRow1.Cells("Region").Value.ToString())

                e.ToolTipText += String.Format("{0}, ", _
                   dataGridViewRow1.Cells("Region").Value.ToString())
            End If
            e.ToolTipText += String.Format("{0}, {1}{2}{3} EXT:{4}{5}{6}", _
                dataGridViewRow1.Cells("Country").Value.ToString(), _
                dataGridViewRow1.Cells("PostalCode").Value.ToString(), _
                newLine, _
                dataGridViewRow1.Cells("HomePhone").Value.ToString(), _
                dataGridViewRow1.Cells("Extension").Value.ToString(), _
                newLine, newLine)

            ' Add employee information to the ToolTipText.
            Dim HireDate As DateTime = _
                CType(dataGridViewRow1.Cells("HireDate").Value, DateTime)
            e.ToolTipText += _
                String.Format("Employee since: {0}/{1}/{2}{3}Manager: {4}", _
                    HireDate.Month.ToString(), HireDate.Day.ToString(), _
                    HireDate.Year.ToString(), newLine, _
                    dataGridViewRow1.Cells("Manager").Value.ToString())
        End If
    End Sub
    '</snippet20>

    Public Sub toolStripMenuItem1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles toolStripMenuItem1.Click

        Dim dataGridViewRow1 As DataGridViewRow = _
            dataGridView1.Rows(contextMenuRowIndex)

        MessageBox.Show(String.Format( _
            "Sales Report for {0} {1}:{2}{3}Reporting Not Implemented", _
            dataGridViewRow1.Cells("FirstName").Value.ToString(), _
            dataGridViewRow1.Cells("LastName").Value.ToString(), _
            Environment.NewLine, Environment.NewLine))
    End Sub

    Public Sub toolStripMenuItem2_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles toolStripMenuItem2.Click

        Dim dataGridViewRow1 As DataGridViewRow = _
            dataGridView1.Rows(contextMenuRowIndex)

        MessageBox.Show(String.Format( _
            "Sales Report for {0} {1}:{2}{3}Reporting Not Implemented", _
            dataGridViewRow1.Cells("FirstName").Value.ToString(), _
            dataGridViewRow1.Cells("LastName").Value.ToString(), _
            Environment.NewLine, Environment.NewLine))
    End Sub

    Public Sub toolStripMenuItem3_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles toolStripMenuItem3.Click

        Dim dataGridViewRow1 As DataGridViewRow = _
            dataGridView1.Rows(contextMenuRowIndex)

        MessageBox.Show(String.Format( _
          "Company Sales Ranking Report:{0}{1}Reporting not implemented.", _
            Environment.NewLine, Environment.NewLine))
    End Sub
End Class
'</snippet00>
