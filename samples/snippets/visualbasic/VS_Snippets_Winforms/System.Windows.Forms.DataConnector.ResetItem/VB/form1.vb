' <snippet1>
' <snippet2>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
' </snippet2>

' <snippet3>
' This form demonstrates using a BindingSource to bind
' a list to a DataGridView control. The list does not
' raise change notifications, so the ResetItem method 
' on the BindingSource is used.
Public Class Form1
    Inherits System.Windows.Forms.Form

    ' <snippet4>
    ' This button causes the value of a list element to be changed.
    Private WithEvents changeItemBtn As New Button()

    ' This is the DataGridView control that displays the contents 
    ' of the list.
    Private customersDataGridView As New DataGridView()

    ' This is the BindingSource used to bind the list to the 
    ' DataGridView control.
    Private WithEvents customersBindingSource As New BindingSource()
    ' </snippet4>

    ' <snippet5>
    Public Sub New()
        ' Set up the "Change Item" button.
        Me.changeItemBtn.Text = "Change Item"
        Me.changeItemBtn.Dock = DockStyle.Bottom
        Me.Controls.Add(Me.changeItemBtn)

        ' Set up the DataGridView.
        customersDataGridView.Dock = DockStyle.Top
        Me.Controls.Add(customersDataGridView)
        Me.Size = New Size(800, 200)
    End Sub
    ' </snippet5>

    ' <snippet6>
    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Me.Load
        ' Create and populate the list of DemoCustomer objects
        ' which will supply data to the DataGridView.
        Dim customerList As List(Of DemoCustomer) = _
        New List(Of DemoCustomer)
        customerList.Add(DemoCustomer.CreateNewCustomer())
        customerList.Add(DemoCustomer.CreateNewCustomer())
        customerList.Add(DemoCustomer.CreateNewCustomer())

        ' Bind the list to the BindingSource.
        Me.customersBindingSource.DataSource = customerList

        ' Attach the BindingSource to the DataGridView.
        Me.customersDataGridView.DataSource = Me.customersBindingSource
    End Sub
    ' </snippet6>

    ' <snippet7>
    ' This event handler changes the value of the CompanyName
    ' property for the first item in the list.
    Private Sub changeItemBtn_Click(ByVal sender As Object, ByVal e As EventArgs) _
       Handles changeItemBtn.Click

        ' Get a reference to the list from the BindingSource.
        Dim customerList As List(Of DemoCustomer) = _
        CType(Me.customersBindingSource.DataSource, List(Of DemoCustomer))

        ' Change the value of the CompanyName property for the 
        ' first item in the list.
        customerList(0).CompanyName = "Tailspin Toys"

        ' Call ResetItem to alert the BindingSource that the 
        ' list has changed.
        Me.customersBindingSource.ResetItem(0)

    End Sub
    ' </snippet7>

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet3>

' <snippet9>
' This class implements a simple customer type.
Public Class DemoCustomer

    ' These fields hold the values for the public properties.
    Private idValue As Guid = Guid.NewGuid()
    Private customerName As String = String.Empty
    Private companyNameValue As String = String.Empty
    Private phoneNumberValue As String = String.Empty

    ' The constructor is private to enforce the factory pattern.
    Private Sub New()
        customerName = "no data"
        companyNameValue = "no data"
        phoneNumberValue = "no data"
    End Sub

    ' This is the public factory method.
    Public Shared Function CreateNewCustomer() As DemoCustomer
        Return New DemoCustomer()
    End Function

    ' This property represents an ID, suitable
    ' for use as a primary key in a database.
    Public ReadOnly Property ID() As Guid
        Get
            Return Me.idValue
        End Get
    End Property

    Public Property CompanyName() As String
        Get
            Return Me.companyNameValue
        End Get

        Set(ByVal value As String)
            Me.companyNameValue = Value
        End Set
    End Property


    Public Property PhoneNumber() As String
        Get
            Return Me.phoneNumberValue
        End Get

        Set(ByVal value As String)
            Me.phoneNumberValue = Value
        End Set
    End Property
End Class
' </snippet9>
' </snippet1>
