 ' <snippet1>
' <snippet2>
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

' </snippet2>
' <snippet3>
' This form demonstrates using the ItemChangedEventMode property
' of the BindingSource component to control which ListChanged
' events are raised when BindingSource component's underlying 
' list is changed.

Public Class Form1
    Inherits System.Windows.Forms.Form
    ' <snippet5>

    ' This is the BindingSource that will provide data for
    ' the DataGridView control.
    Private WithEvents customersBindingSource As New BindingSource()
    
    ' This is the DataGridView control that will display our data.
    Private customersDataGridView As New DataGridView()
    
    ' This panel holds the RadioButton controls.
    Private buttonPanel As New Panel()
    
    ' this StatusBar control will display the ListChanged events.
    Private status As New StatusBar()
    
    ' </snippet5>
    ' <snippet6>
    Public Sub New() 
        ' Set up the form.
        Me.Size = New Size(800, 800)
        AddHandler Me.Load, AddressOf Form1_Load
        
        ' Set up the DataGridView control.
        Me.customersDataGridView.AllowUserToAddRows = True
        Me.customersDataGridView.Dock = DockStyle.Fill
        Me.Controls.Add(customersDataGridView)
        
        ' Add the StatusBar control to the form.
        Me.Controls.Add(status)
        
        ' Allow the user to add new items.
        Me.customersBindingSource.AllowNew = True
        
        ' Attach the BindingSource to the DataGridView.
        Me.customersDataGridView.DataSource = Me.customersBindingSource
    
    End Sub
    ' </snippet6>

    ' <snippet7>
    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        ' Create and populate the list of DemoCustomer objects
        ' which will supply data to the DataGridView.
        Dim customerList As New List(Of DemoCustomer)

        customerList.Add(DemoCustomer.CreateNewCustomer())
        customerList.Add(DemoCustomer.CreateNewCustomer())
        customerList.Add(DemoCustomer.CreateNewCustomer())

        ' Bind the list to the BindingSource.
        Me.customersBindingSource.DataSource = customerList

    End Sub
    
    ' </snippet7>
    ' <snippet8>
    ' This event handler provides custom item-creation behavior.
    Private Sub customersBindingSource_AddingNew(ByVal sender As Object, _
        ByVal e As AddingNewEventArgs) Handles customersBindingSource.AddingNew
        e.NewObject = DemoCustomer.CreateNewCustomer()

    End Sub 
    
    ' </snippet8>
    ' <snippet9>
    ' This event handler detects changes in the BindingSource 
    ' list or changes to items within the list.
    Private Sub customersBindingSource_ListChanged(ByVal sender As Object, _
        ByVal e As ListChangedEventArgs) Handles customersBindingSource.ListChanged

        status.Text = e.ListChangedType.ToString()
    End Sub
    ' </snippet9>
    
    
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub
End Class
' </snippet3>
' <snippet4>

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
' </snippet4>
' </snippet1>