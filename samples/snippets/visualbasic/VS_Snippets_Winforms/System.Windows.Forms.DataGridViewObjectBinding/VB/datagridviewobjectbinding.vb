'<Snippet00>
Imports System
Imports System.Windows.Forms

Public Class DataGridViewObjectBinding
    Inherits Form

    ' These declarations and the Main() and New() methods 
    ' below can be replaced with designer-generated code. 
    Private WithEvents InvoiceButton As New Button()
    Private WithEvents DataGridView1 As New DataGridView()

    ' Entry point code. 
    <STAThreadAttribute()> _
    Public Shared Sub Main()

        Application.Run(New DataGridViewObjectBinding())

    End Sub

    ' Sets up the form. 
    Public Sub New()

        Me.DataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(Me.DataGridView1)

        Me.InvoiceButton.Text = "invoice the selected customers"
        Me.InvoiceButton.Dock = DockStyle.Top
        Me.Controls.Add(Me.InvoiceButton)
        Me.Text = "DataGridView collection-binding demo"

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        ' Set up a collection of objects for binding.
        Dim customers As New System.Collections.ArrayList()
        customers.Add(New Customer("Harry"))
        customers.Add(New Customer("Sally"))
        customers.Add(New Customer("Roy"))
        customers.Add(New Customer("Pris"))

        ' Initialize and bind the DataGridView.
        Me.DataGridView1.SelectionMode = _
            DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.AutoGenerateColumns = True
        Me.DataGridView1.DataSource = customers

    End Sub

    ' Calls the SendInvoice() method for the Customer 
    ' object bound to each selected row.
    '<Snippet10>
    Private Sub InvoiceButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles InvoiceButton.Click

        For Each row As DataGridViewRow In Me.DataGridView1.SelectedRows

            Dim cust As Customer = TryCast(row.DataBoundItem, Customer)
            If cust IsNot Nothing Then
                cust.SendInvoice()
            End If

        Next

    End Sub
    '</Snippet10>

End Class

Public Class Customer

    Private nameValue As String

    Public Sub New(ByVal name As String)
        nameValue = name
    End Sub

    Public Property Name() As String
        Get
            Return nameValue
        End Get
        Set(ByVal value As String)
            nameValue = value
        End Set
    End Property

    Public Sub SendInvoice()
        MsgBox(nameValue & " has been billed.")
    End Sub

End Class
'</Snippet00>