 '<snippet4>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms

'<snippet1>
' This form demonstrates using a BindingSource to bind
' a list to a simple user control. The list does not
' raise change notifications, however the DemoCustomer type 
' in the list does. In addition, an event is raised when the DataSource
' property of the user control changes.

Public Class Form1
    Inherits System.Windows.Forms.Form
    ' This button causes the value of a list element to be changed.
    Private WithEvents changeItemBtn As New Button()
    
    ' This is the DataGridView control that displays the contents 
    ' of the list.
    Private WithEvents customerControl1 As New CustomerControl()

    ' This is the BindingSource used to bind the list to the 
    ' DataGridView control.
    Private customersBindingSource As New BindingSource()
    
    
    Public Sub New() 
        ' Set up the "Change Item" button.
        Me.changeItemBtn.Text = "Change Item"
        Me.changeItemBtn.Dock = DockStyle.Bottom
        Me.Controls.Add(Me.changeItemBtn)
        
        ' Set up the DataGridView.
        customerControl1.Dock = DockStyle.Top
        Me.Controls.Add(customerControl1)
        Me.Size = New Size(800, 200)

    End Sub 'New
     
    Private Sub customerControl1_DataSourceChanged(ByVal sender As [Object], ByVal e As EventArgs) 
        MessageBox.Show("Data Source has changed")
    
    End Sub 'customerControl1_DataSourceChanged
    
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Me.Load
        ' Create and populate the list of DemoCustomer objects
        ' which will supply data to the control.
        Dim customerList As New List(Of DemoCustomer)

        customerList.Add(DemoCustomer.CreateNewCustomer())
        customerList.Add(DemoCustomer.CreateNewCustomer())
        customerList.Add(DemoCustomer.CreateNewCustomer())

        ' Bind the list to the BindingSource.
        Me.customersBindingSource.DataSource = customerList
        customerControl1.DataSource = customersBindingSource

    End Sub 'Form1_Load
    
    
    ' This event handler changes the value of the CompanyName
    ' property for the first item in the list.
    Private Sub changeItemBtn_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles changeItemBtn.Click

        ' Get a reference to the list from the BindingSource.
        Dim customerList As List(Of DemoCustomer) = _
            CType(customersBindingSource.DataSource, List(Of DemoCustomer))

        ' Change the value of the CompanyName property for the 
        ' first item in the list.
        customerList(0).CompanyName = "Tailspin Toys"

    End Sub

    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
End Class 'Form1

'</snippet1>
'<snippet3>
' This class implements a simple user control 
' that demonstrates how to apply the propertyNameChanged pattern.
<ComplexBindingProperties("DataSource", "DataMember")>  _
Public Class CustomerControl
    Inherits UserControl
    Private dataGridView1 As DataGridView
    Private label1 As Label
    Private lastUpdate As DateTime = DateTime.Now
    
    Public DataSourceChanged As EventHandler
    
    
    Public Property DataSource() As Object 
        Get
            Return Me.dataGridView1.DataSource
        End Get
        Set
            If DataSource IsNot Value Then
                Me.dataGridView1.DataSource = Value
                OnDataSourceChanged()
            End If
        End Set
    End Property
    
    
    Public Property DataMember() As String 
        Get
            Return Me.dataGridView1.DataMember
        End Get 
        Set
            Me.dataGridView1.DataMember = value
        End Set 
    End Property
    
    
    Private Sub OnDataSourceChanged() 
        If (DataSourceChanged IsNot Nothing) Then
            DataSourceChanged(Me, New EventArgs())
        End If
    
    End Sub

    
    Public Sub New() 
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dataGridView1.ColumnHeadersHeightSizeMode = _
           System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dataGridView1.Location = New System.Drawing.Point(19, 55)
        Me.dataGridView1.Size = New System.Drawing.Size(350, 150)
        Me.dataGridView1.TabIndex = 1
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(19, 23)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(76, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Customer List:"
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.dataGridView1)
        Me.Size = New System.Drawing.Size(350, 216)
    End Sub
End Class
'</snippet3>
'<snippet2>
' This class implements a simple customer type 
' that implements the IPropertyChange interface.

Public Class DemoCustomer
    Implements INotifyPropertyChanged

    ' These fields hold the values for the public properties.
    Private idValue As Guid = Guid.NewGuid()
    Private customerName As String = String.Empty
    Private companyNameValue As String = String.Empty
    Private phoneNumberValue As String = String.Empty
    
    Public Event PropertyChanged As PropertyChangedEventHandler _
      Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub
    
    
    ' The constructor is private to enforce the factory pattern.
    Private Sub New() 
        customerName = "no data"
        companyNameValue = "no data"
        phoneNumberValue = "no data"
    
    End Sub 'New
    
    
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
        Set
            If value <> Me.companyNameValue Then
                Me.companyNameValue = value
                NotifyPropertyChanged("CompanyName")
            End If
        End Set
    End Property
    
    Public Property PhoneNumber() As String 
        Get
            Return Me.phoneNumberValue
        End Get 
        Set
            If value <> Me.phoneNumberValue Then
                Me.phoneNumberValue = value
                NotifyPropertyChanged("PhoneNumber")
            End If
        End Set
    End Property
End Class
'</snippet2>
'</snippet4>