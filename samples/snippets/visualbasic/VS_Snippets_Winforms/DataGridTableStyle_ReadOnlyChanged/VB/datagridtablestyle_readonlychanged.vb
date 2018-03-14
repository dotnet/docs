' System.Windows.Forms.DataGridTableStyle.ReadOnlyChanged

' The following example demonstrates the 'ReadOnlyChanged' event of 
' 'DataGridTableStyle' class. It adds a DataGrid and checkbox to a Form. 
' When the Check box is checked, the 'ReadOnly' property of 
' 'DataGridTableStyle' is changed. 

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private myDataSet1 As DataSet
   Private myCheckBox1 As CheckBox
   Private myDataGrid1 As DataGrid
   Private myDataGridTableStyle As DataGridTableStyle

   Public Sub New()
      InitializeComponent()
      MakeDataSet()
      AddTableStyle()
   End Sub 'New
   
   
   Private Sub InitializeComponent()
      myDataGrid1 = New DataGrid()
      myCheckBox1 = New CheckBox()
      SuspendLayout()
      myDataGrid1.DataMember = ""
      myDataGrid1.Location = New Point(72, 64)
      myDataGrid1.Name = "myDataGrid1"
      myDataGrid1.Size = New Size(208, 128)
      myDataGrid1.TabIndex = 0
      myCheckBox1.Location = New Point(304, 112)
      myCheckBox1.Name = "myCheckBox1"
      myCheckBox1.TabIndex = 1
      myCheckBox1.Text = "Read Only"
      AddHandler myCheckBox1.CheckedChanged, AddressOf myCheckBox1_CheckedChanged
      ClientSize = New Size(472, 273)
      Controls.AddRange(New Control() {myCheckBox1, myDataGrid1})
      Name = "Form1"
      Text = "Test 'ReadOnleChanged' Event of 'DataGridTableStyle' class"
      ResumeLayout(False)
   End Sub 'InitializeComponent
   
   
   Public Shared Sub Main()
      Application.Run(New Form1())
   End Sub 'Main
   
   
   ' Create a DataSet with a table and populate it.
   Private Sub MakeDataSet()
      myDataSet1 = New DataSet("myDataSet")
      
      Dim customerTable As New DataTable("Customers")
      
      ' Create two columns, and add them to the first table.
      Dim myColumn As New DataColumn("CustID", GetType(Integer))
      Dim myColumn1 As New DataColumn("CustName")
      customerTable.Columns.Add(myColumn)
      customerTable.Columns.Add(myColumn1)
      
      ' Add the tables to the DataSet.
      myDataSet1.Tables.Add(customerTable)
      
      ' Create three customers in the Customers Table.
      Dim newRow1 As DataRow
      Dim i As Integer
      For i = 1 To 3
         newRow1 = customerTable.NewRow()
         newRow1("custID") = i
         ' Add the row to the Customers table.
         customerTable.Rows.Add(newRow1)
      Next i
      ' Give each customer a distinct name.
      customerTable.Rows(0)("CustName") = "Alpha"
      customerTable.Rows(1)("CustName") = "Beta"
      customerTable.Rows(2)("CustName") = "Omega"
      
      ' Add Unique Key constraint to the CustID column.
      Dim idKeyRestraint As New UniqueConstraint(myColumn)
      customerTable.Constraints.Add(idKeyRestraint)
      myDataSet1.EnforceConstraints = True
   End Sub 'MakeDataSet
   
' <Snippet1>
   Protected Sub AddTableStyle()
      ' Create a new DataGridTableStyle.
      myDataGridTableStyle = New DataGridTableStyle()
      myDataGridTableStyle.MappingName = myDataSet1.Tables(0).TableName
      myDataGrid1.DataSource = myDataSet1.Tables(0)
      AddHandler myDataGridTableStyle.ReadOnlyChanged, AddressOf MyReadOnlyChangedEventHandler
      myDataGrid1.TableStyles.Add(myDataGridTableStyle)
   End Sub 'AddTableStyle
   
   ' Handle the 'ReadOnlyChanged' event.
   Private Sub MyReadOnlyChangedEventHandler(sender As Object, e As EventArgs)
      MessageBox.Show("ReadOnly property is changed")
   End Sub 'MyReadOnlyChangedEventHandler

   ' Handle the check box's CheckedChanged event
   Private Sub myCheckBox1_CheckedChanged(sender As Object, e As EventArgs)
      If myDataGridTableStyle.ReadOnly Then
         myDataGridTableStyle.ReadOnly = False
      Else
         myDataGridTableStyle.ReadOnly = True
      End If
   End Sub 'myCheckBox1_CheckedChanged
' </Snippet1>
End Class 'Form1