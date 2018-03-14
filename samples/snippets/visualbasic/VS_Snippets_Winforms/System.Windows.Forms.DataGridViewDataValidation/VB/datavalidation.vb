'<Snippet00>
'<Snippet01>
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private WithEvents dataGridView1 As New DataGridView()
    Private bindingSource1 As New BindingSource()

    Public Sub New()

        ' Initialize the form.
        Me.dataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(dataGridView1)
        Me.Text = "DataGridView validation demo (disallows empty CompanyName)"

    End Sub
    '</Snippet01>

    '<Snippet10>
    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        ' Initialize the BindingSource and bind the DataGridView to it.
        bindingSource1.DataSource = GetData("select * from Customers")
        Me.dataGridView1.DataSource = bindingSource1
        Me.dataGridView1.AutoResizeColumns( _
            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)

    End Sub
    '</Snippet10>

    '<Snippet20>
    Private Sub dataGridView1_CellValidating(ByVal sender As Object, _
        ByVal e As DataGridViewCellValidatingEventArgs) _
        Handles dataGridView1.CellValidating

        Dim headerText As String = _
            dataGridView1.Columns(e.ColumnIndex).HeaderText

        ' Abort validation if cell is not in the CompanyName column.
        If Not headerText.Equals("CompanyName") Then Return

        ' Confirm that the cell is not empty.
        If (String.IsNullOrEmpty(e.FormattedValue.ToString())) Then
            dataGridView1.Rows(e.RowIndex).ErrorText = _
                "Company Name must not be empty"
            e.Cancel = True
        End If
    End Sub

    '<Snippet25>
    Private Sub dataGridView1_CellEndEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dataGridView1.CellEndEdit

        ' Clear the row error in case the user presses ESC.   
        dataGridView1.Rows(e.RowIndex).ErrorText = String.Empty

    End Sub
    '</Snippet25>
    '</Snippet20>

    '<Snippet30>
    Private Shared Function GetData(ByVal selectCommand As String) As DataTable

        Dim connectionString As String = _
            "Integrated Security=SSPI;Persist Security Info=False;" + _
            "Initial Catalog=Northwind;Data Source=localhost;Packet Size=4096"

        ' Connect to the database and fill a data table.
        Dim adapter As New SqlDataAdapter(selectCommand, connectionString)
        Dim data As New DataTable()
        data.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter.Fill(data)

        Return data

    End Function
    '</Snippet30>

    '<Snippet02>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

End Class
'</Snippet02>
'</Snippet00>