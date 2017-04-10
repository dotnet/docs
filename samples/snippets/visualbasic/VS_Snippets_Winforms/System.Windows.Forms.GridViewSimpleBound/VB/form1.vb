'<snippet1>
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private WithEvents dataGridView1 As New DataGridView()
    Private bindingSource1 As New BindingSource()

    Public Sub New()

        Me.dataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(Me.dataGridView1)
        InitializeDataGridView()

    End Sub

    '<snippet2>
    Private Sub InitializeDataGridView()
        Try
            ' Set up the DataGridView.
            With Me.dataGridView1
                ' Automatically generate the DataGridView columns.
                .AutoGenerateColumns = True

                ' Set up the data source.
                bindingSource1.DataSource = GetData("Select * From Products")
                .DataSource = bindingSource1

                ' Automatically resize the visible rows.
                .AutoSizeRowsMode = _
                    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders

                ' Set the DataGridView control's border.
                .BorderStyle = BorderStyle.Fixed3D

                ' Put the cells in edit mode when user enters them.
                .EditMode = DataGridViewEditMode.EditOnEnter
            End With
        Catch ex As SqlException
            MessageBox.Show("To run this sample replace " _
                & "connection.ConnectionString with a valid connection string" _
                & "  to a Northwind database accessible to your system.", _
                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            System.Threading.Thread.CurrentThread.Abort()
        End Try
    End Sub
    '</snippet2>

    '<snippet3>
    Private Shared Function GetData(ByVal sqlCommand As String) _
        As DataTable

        Dim connectionString As String = _
            "Integrated Security=SSPI;Persist Security Info=False;" _
            & "Initial Catalog=Northwind;Data Source=localhost"

        Dim northwindConnection As SqlConnection = _
            New SqlConnection(connectionString)

        Dim command As New SqlCommand(sqlCommand, northwindConnection)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter()
        adapter.SelectCommand = command

        Dim table As New DataTable
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter.Fill(table)

        Return table

    End Function
    '</snippet3>

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
'</snippet1>
