
#Region "Using directives"

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms


#End Region


Class Form1
    Inherits Form
    
    
    
    Private BindingSource1 As BindingSource
    Private dataGridView1 As DataGridView
    Private WithEvents button1 As Button
    Private label1 As Label
    Private label2 As Label
    
    
    Private components As IContainer
    
    
    Public Sub New() 
        InitializeComponent()
          
    End Sub
    
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub
    
    
    Private Sub InitializeComponent() 
        Me.components = New System.ComponentModel.Container()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.button1 = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' dataGridView1
        ' 
        Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dataGridView1.Location = New System.Drawing.Point(0, 100)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(292, 166)
        Me.dataGridView1.TabIndex = 0
        ' 
        ' button1
        ' 
        Me.button1.Location = New System.Drawing.Point(12, 39)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 1
        Me.button1.Text = "button1"
        ' 
        ' label1
        ' 
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(112, 48)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(35, 14)
        Me.label1.TabIndex = 3
        Me.label1.Text = "label1"
        ' 
        ' label2
        ' 
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(112, 67)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(35, 14)
        Me.label2.TabIndex = 4
        Me.label2.Text = "label2"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(label2)
        Me.Controls.Add(label1)
        Me.Controls.Add(button1)
        Me.Controls.Add(dataGridView1)
        Me.Name = "Form1"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    
    End Sub 'InitializeComponent
     
    
    
    Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        InitializeSortedFilteredBindingSource()
    
    End Sub 'Form1_Load
    
    ' The following code example demonstrates BindingSource.Filter and
    ' BindingSource.Sort members.  
    ' To run this example paste the code into a form that contains a 
    ' BindingSource named BindingSource1 and a DataGridView named
    ' dataGridView1.  Handle the form's load event and call 
    ' InitializeSortedFilteredBindingSource in the load event-handling 
    ' method.

    ' If you are using VB, you may need to add a reference to the System.Data.dll.
    '<snippet1>
    Private Sub InitializeSortedFilteredBindingSource()

        ' Create the connection string, data adapter and data table.
        Dim connectionString As New SqlConnection("Initial Catalog=Northwind;" & _
            "Data Source=localhost;Integrated Security=SSPI;")
        Dim customersTableAdapter As New SqlDataAdapter("Select * from Customers", _
            connectionString)
        Dim customerTable As New DataTable()

        ' Fill the the adapter with the contents of the customer table.
        customersTableAdapter.Fill(customerTable)

        ' Set data source for BindingSource1.
        BindingSource1.DataSource = customerTable

        ' Filter the items to show contacts who are owners.
        ' <snippet11>
        BindingSource1.Filter = "ContactTitle='Owner'"
        ' </snippet11>
        ' Sort the items on the company name in descending order.
        ' <snippet12>
        BindingSource1.Sort = "Country DESC, Address ASC"
        ' </snippet12>

        ' Set the data source for dataGridView1 to BindingSource1.
        dataGridView1.DataSource = BindingSource1

       
    End Sub
    
    '</snippet1>

    ' The following code example demonstrates BindingSource.Items,
    ' BindingSource.List, BindingSource.RemoveAt, BindingSource.Count
    ' BindingSourceItemCollection.Count.
    ' To run this example paste the code into a form that contains a 
    ' BindingSource named BindingSource1, two labels named label1 and label2
    ' and a button named button1. Associate the button1_Click
    ' method with the click event for button1. 
    '<snippet2>    
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        ' Create the connection string, data adapter and data table.
        Dim connectionString As New SqlConnection("Initial Catalog=Northwind;" & _
            "Data Source=localhost;Integrated Security=SSPI;")
        Dim customersTableAdapter As New SqlDataAdapter("Select * from Customers", _
            connectionString)
        Dim customerTable As New DataTable()

        ' Fill the the adapter with the contents of the customer table.
        customersTableAdapter.Fill(customerTable)

        ' Set data source for BindingSource1.
        BindingSource1.DataSource = customerTable

        ' Set the label text to the number of items in the collection before
        ' an item is removed.
        label1.Text = "Starting count: " + BindingSource1.Count.ToString()

        ' Access the List property and remove an item.
        BindingSource1.List.RemoveAt(4)

        ' Remove an item directly from the BindingSource. 
        ' This is equivalent to the previous line of code.
        BindingSource1.RemoveAt(4)

        ' Show the new count.
        label2.Text = "Count after removal: " + BindingSource1.Count.ToString()

    End Sub
End Class
'</snippet2>

