' The purpose of this snippet is to demonstrate how to use all the primary virtual-mode events. 
' Additionally, this example implements row-level commit-scope. To experiment with this feature,
' make some edits in multiple cells within a single row, then click ESC once to revert the edit
' for a single cell, and twice to revert the edit for the entire row. You can commit all edits 
' for a row without changing focus by pressing CTRL-ENTER. 

'<Snippet000>
'<Snippet001>
Imports System
Imports System.Windows.Forms

'<Snippet100>
Public Class Form1
    Inherits Form

    Private WithEvents dataGridView1 As New DataGridView()

    ' Declare an ArrayList to serve as the data store. 
    Private customers As New System.Collections.ArrayList()

    ' Declare a Customer object to store data for a row being edited.
    Private customerInEdit As Customer

    ' Declare a variable to store the index of a row being edited. 
    ' A value of -1 indicates that there is no row currently in edit. 
    Private rowInEdit As Integer = -1

    ' Declare a variable to indicate the commit scope. 
    ' Set this value to false to use cell-level commit scope. 
    Private rowScopeCommit As Boolean = True

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Public Sub New()
        ' Initialize the form.
        Me.dataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(Me.dataGridView1)
        Me.Text = "DataGridView virtual-mode demo (row-level commit scope)"
    End Sub
    '</Snippet001>

    '<Snippet110>
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        ' Enable virtual mode.
        Me.dataGridView1.VirtualMode = True

        ' Add columns to the DataGridView.
        Dim companyNameColumn As New DataGridViewTextBoxColumn()
        With companyNameColumn
            .HeaderText = "Company Name"
            .Name = "Company Name"
        End With
        Dim contactNameColumn As New DataGridViewTextBoxColumn()
        With contactNameColumn
            .HeaderText = "Contact Name"
            .Name = "Contact Name"
        End With
        Me.dataGridView1.Columns.Add(companyNameColumn)
        Me.dataGridView1.Columns.Add(contactNameColumn)
        Me.dataGridView1.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells

        ' Add some sample entries to the data store. 
        Me.customers.Add(New Customer("Bon app'", "Laurence Lebihan"))
        Me.customers.Add(New Customer("Bottom-Dollar Markets", _
            "Elizabeth Lincoln"))
        Me.customers.Add(New Customer("B's Beverages", "Victoria Ashworth"))

        ' Set the row count, including the row for new records.
        Me.dataGridView1.RowCount = 4

    End Sub
    '</Snippet110>

    '<Snippet120>
    Private Sub dataGridView1_CellValueNeeded(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValueNeeded

        ' If this is the row for new records, no values are needed.
        If e.RowIndex = Me.dataGridView1.RowCount - 1 Then
            Return
        End If

        Dim customerTmp As Customer = Nothing

        ' Store a reference to the Customer object for the row being painted.
        If e.RowIndex = rowInEdit Then
            customerTmp = Me.customerInEdit
        Else
            customerTmp = CType(Me.customers(e.RowIndex), Customer)
        End If

        ' Set the cell value to paint using the Customer object retrieved.
        Select Case Me.dataGridView1.Columns(e.ColumnIndex).Name
            Case "Company Name"
                e.Value = customerTmp.CompanyName

            Case "Contact Name"
                e.Value = customerTmp.ContactName
        End Select

    End Sub
    '</Snippet120>

    '<Snippet130>
    Private Sub dataGridView1_CellValuePushed(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValuePushed

        Dim customerTmp As Customer = Nothing

        ' Store a reference to the Customer object for the row being edited.
        If e.RowIndex < Me.customers.Count Then

            ' If the user is editing a new row, create a new Customer object.
            If Me.customerInEdit Is Nothing Then
                Me.customerInEdit = New Customer( _
                    CType(Me.customers(e.RowIndex), Customer).CompanyName, _
                    CType(Me.customers(e.RowIndex), Customer).ContactName)
            End If
            customerTmp = Me.customerInEdit
            Me.rowInEdit = e.RowIndex

        Else
            customerTmp = Me.customerInEdit
        End If

        ' Set the appropriate Customer property to the cell value entered.
        Dim newValue As String = TryCast(e.Value, String)
        Select Case Me.dataGridView1.Columns(e.ColumnIndex).Name
            Case "Company Name"
                customerTmp.CompanyName = newValue
            Case "Contact Name"
                customerTmp.ContactName = newValue
        End Select

    End Sub
    '</Snippet130>

    '<Snippet140>
    Private Sub dataGridView1_NewRowNeeded(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) _
        Handles dataGridView1.NewRowNeeded

        ' Create a new Customer object when the user edits
        ' the row for new records.
        Me.customerInEdit = New Customer()
        Me.rowInEdit = Me.dataGridView1.Rows.Count - 1

    End Sub
    '</Snippet140>

    '<Snippet150>
    Private Sub dataGridView1_RowValidated(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dataGridView1.RowValidated

        ' Save row changes if any were made and release the edited 
        ' Customer object if there is one.
        If e.RowIndex >= Me.customers.Count AndAlso _
            e.RowIndex <> Me.dataGridView1.Rows.Count - 1 Then

            ' Add the new Customer object to the data store.
            Me.customers.Add(Me.customerInEdit)
            Me.customerInEdit = Nothing
            Me.rowInEdit = -1

        ElseIf (Me.customerInEdit IsNot Nothing) AndAlso _
            e.RowIndex < Me.customers.Count Then

            ' Save the modified Customer object in the data store.
            Me.customers(e.RowIndex) = Me.customerInEdit
            Me.customerInEdit = Nothing
            Me.rowInEdit = -1

        ElseIf Me.dataGridView1.ContainsFocus Then

            Me.customerInEdit = Nothing
            Me.rowInEdit = -1

        End If

    End Sub
    '</Snippet150>

    '<Snippet160>
    Private Sub dataGridView1_RowDirtyStateNeeded(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.QuestionEventArgs) _
        Handles dataGridView1.RowDirtyStateNeeded

        If Not rowScopeCommit Then

            ' In cell-level commit scope, indicate whether the value
            ' of the current cell has been modified.
            e.Response = Me.dataGridView1.IsCurrentCellDirty

        End If

    End Sub
    '</Snippet160>

    '<Snippet170>
    Private Sub dataGridView1_CancelRowEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.QuestionEventArgs) _
        Handles dataGridView1.CancelRowEdit

        If Me.rowInEdit = Me.dataGridView1.Rows.Count - 2 AndAlso _
            Me.rowInEdit = Me.customers.Count Then

            ' If the user has canceled the edit of a newly created row, 
            ' replace the corresponding Customer object with a new, empty one.
            Me.customerInEdit = New Customer()

        Else

            ' If the user has canceled the edit of an existing row, 
            ' release the corresponding Customer object.
            Me.customerInEdit = Nothing
            Me.rowInEdit = -1

        End If

    End Sub
    '</Snippet170>

    '<Snippet180>
    Private Sub dataGridView1_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles dataGridView1.UserDeletingRow

        If e.Row.Index < Me.customers.Count Then

            ' If the user has deleted an existing row, remove the 
            ' corresponding Customer object from the data store.
            Me.customers.RemoveAt(e.Row.Index)

        End If

        If e.Row.Index = Me.rowInEdit Then

            ' If the user has deleted a newly created row, release
            ' the corresponding Customer object. 
            Me.rowInEdit = -1
            Me.customerInEdit = Nothing

        End If

    End Sub
    '</Snippet180>
    '<Snippet002>

End Class
'</Snippet100>
'</Snippet002>

'<Snippet200>
Public Class Customer

    Private companyNameValue As String
    Private contactNameValue As String

    Public Sub New()
        ' Leave fields empty.
    End Sub

    Public Sub New(ByVal companyName As String, ByVal contactName As String)
        companyNameValue = companyName
        contactNameValue = contactName
    End Sub

    Public Property CompanyName() As String
        Get
            Return companyNameValue
        End Get
        Set(ByVal value As String)
            companyNameValue = value
        End Set
    End Property

    Public Property ContactName() As String
        Get
            Return contactNameValue
        End Get
        Set(ByVal value As String)
            contactNameValue = value
        End Set
    End Property

End Class
'</Snippet200>
'</Snippet000>