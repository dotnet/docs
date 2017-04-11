' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

' This form demonstrates using a BindingSource to bind
' a list to a DataGridView control. The list does not
' raise change notifications. However the DemoCustomer type 
' in the list does.

Public Class Form1
    Inherits System.Windows.Forms.Form
    ' This button causes the value of a list element to be changed.
    Private changeItemBtn As New Button()

    ' This DataGridView control displays the contents of the list.
    Private customersDataGridView As New DataGridView()

    ' This BindingSource binds the list to the DataGridView control.
    Private customersBindingSource As New BindingSource()

    Public Sub New()
        InitializeComponent()

        ' Set up the "Change Item" button.
        Me.changeItemBtn.Text = "Change Item"
        Me.changeItemBtn.Dock = DockStyle.Bottom
        AddHandler Me.changeItemBtn.Click, AddressOf changeItemBtn_Click
        Me.Controls.Add(Me.changeItemBtn)

        ' Set up the DataGridView.
        customersDataGridView.Dock = DockStyle.Top
        Me.Controls.Add(customersDataGridView)

        Me.Size = New Size(400, 200)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        ' Create and populate the list of DemoCustomer objects
        ' which will supply data to the DataGridView.
        Dim customerList As New BindingList(Of DemoCustomer)

        customerList.Add(DemoCustomer.CreateNewCustomer())
        customerList.Add(DemoCustomer.CreateNewCustomer())
        customerList.Add(DemoCustomer.CreateNewCustomer())

        ' Bind the list to the BindingSource.
        Me.customersBindingSource.DataSource = customerList

        ' Attach the BindingSource to the DataGridView.
        Me.customersDataGridView.DataSource = Me.customersBindingSource
    End Sub

    ' This event handler changes the value of the CompanyName
    ' property for the first item in the list.
    Private Sub changeItemBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get a reference to the list from the BindingSource.
        Dim customerList As BindingList(Of DemoCustomer) = _
            CType(customersBindingSource.DataSource, BindingList(Of DemoCustomer))

        ' Change the value of the CompanyName property for the 
        ' first item in the list.
        customerList(0).CustomerName = "Tailspin Toys"
        customerList(0).PhoneNumber = "(708)555-0150"
    End Sub
End Class

' This class implements a simple customer type 
' that implements the IPropertyChange interface.

Public Class DemoCustomer
    Implements INotifyPropertyChanged

    ' These fields hold the values for the public properties.
    Private idValue As Guid = Guid.NewGuid()
    Private customerNameValue As String = String.Empty
    Private phoneNumberValue As String = String.Empty

    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    ' This method is called by the Set accessor of each property.
    ' The CallerMemberName attribute that is applied to the optional propertyName
    ' parameter causes the property name of the caller to be substituted as an argument.
    Private Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    ' The constructor is private to enforce the factory pattern.
    Private Sub New()
        customerNameValue = "Customer"
        phoneNumberValue = "(312)555-0100"
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


    Public Property CustomerName() As String
        Get
            Return Me.customerNameValue
        End Get

        Set(ByVal value As String)
            If Not (value = customerNameValue) Then
                Me.customerNameValue = value
                NotifyPropertyChanged()
            End If
        End Set
    End Property


    Public Property PhoneNumber() As String
        Get
            Return Me.phoneNumberValue
        End Get

        Set(ByVal value As String)
            If Not (value = phoneNumberValue) Then
                Me.phoneNumberValue = value
                NotifyPropertyChanged()
            End If
        End Set
    End Property
End Class
' </snippet1>