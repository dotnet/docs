' System.Windows.Forms.DataGridTableStyle.SelectionForeColor
' System.Windows.Forms.DataGridTableStyle.ResetSelectionForeColor

' The following program demonstrates the use of 'SelectionForeColor' 
' property  and 'ResetSelectionForeColor' method of 
' 'System.Windows.Forms.DataGridTableStyle'. 
' It creates a windows form, a 'DataSet' containing one 'DataTable' 
' object. A 'DataGridTableStyle' is attached to 'DataTable'.
' To display the data, a 'DataGrid' control is then bound to the 
' 'DataSet' through the 'SetDataBinding' method. 
' Two button are provided on form to show 'SelectionForeColor' and
' 'ResetSelectionForeColor'.


Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace MyDataGridNamespace
   Public Class MyForm
      Inherits System.Windows.Forms.Form
      Private components As System.ComponentModel.Container = Nothing
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      
      Protected Overrides Overloads Sub Dispose(disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose

      Private Sub InitializeComponent()
         Me.myDataGrid = New System.Windows.Forms.DataGrid()
         Me.button1 = New System.Windows.Forms.Button()
         Me.button2 = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' myDataGrid
         ' 
         Me.myDataGrid.DataMember = ""
         Me.myDataGrid.Location = New System.Drawing.Point(32, 16)
         Me.myDataGrid.Name = "dataGrid1"
         Me.myDataGrid.Size = New System.Drawing.Size(232, 144)
         Me.myDataGrid.TabIndex = 0
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(16, 16)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(144, 24)
         Me.button1.TabIndex = 0
         Me.button1.Text = "SetSelectionForeColor"
         ' 
         ' button2
         ' 
         Me.button2.Location = New System.Drawing.Point(16, 40)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(144, 24)
         Me.button2.TabIndex = 1
         Me.button2.Text = "ResetSelectionForeColor"
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2, Me.button1})
         Me.groupBox1.Location = New System.Drawing.Point(64, 168)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(176, 80)
         Me.groupBox1.TabIndex = 1
         Me.groupBox1.TabStop = False
         ' 
         ' MyForm
         ' 
         Me.ClientSize = New System.Drawing.Size(320, 266)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox1, Me.myDataGrid})
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
         Me.Name = "MyForm"
         Me.Text = "MyForm"
         CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
         Me.groupBox1.ResumeLayout(False)
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent 

      Private customersStyle As New DataGridTableStyle()
      Private groupBox1 As System.Windows.Forms.GroupBox '
      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents button2 As System.Windows.Forms.Button
      Private myDataGrid As System.Windows.Forms.DataGrid
      
      <STAThread()>  Shared Sub Main()
         Application.Run(New MyForm())
      End Sub 'Main
      
      
      Private Sub MyFormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
         myDataGrid.SetDataBinding(MakeDataSet(), "Customers")
         ' Add data grid control to form.
         Controls.Add(myDataGrid)
      End Sub 'MyFormLoad
      
      Private Function MakeDataSet() As DataSet
         ' Create a DataSet.
         Dim myDataSet As New DataSet("myDataSet")
         
         ' Create two DataTables.
         Dim tCustomers As New DataTable("Customers")
         ' Map 'CustomersStyle' to 'Customers' table.
         customersStyle.MappingName = "Customers"
         ' Add the DataGridTableStyle objects to the collection.
         myDataGrid.TableStyles.Add(customersStyle)
         
         
         ' Create two columns and add them to the first table.
         Dim cCustID As New DataColumn("CustID", GetType(Integer))
         Dim cCustName As New DataColumn("CustName")
         Dim cCurrent As New DataColumn("Current", GetType(Boolean))
         tCustomers.Columns.Add(cCustID)
         tCustomers.Columns.Add(cCustName)
         tCustomers.Columns.Add(cCurrent)
         
         
         ' Create three columns, and add them to the second table.
         Dim cID As New DataColumn("CustID", GetType(Integer))
         Dim cOrderDate As New DataColumn("orderDate", GetType(DateTime))
         Dim cOrderAmount As New DataColumn("OrderAmount", GetType(Decimal))
         
         ' Add the tables to the DataSet.
         myDataSet.Tables.Add(tCustomers)
         
         ' Populate the tables. 
         ' Create two DataRow variables for each customer and order.
         Dim newRow1 As DataRow
         
         ' Create three customers in the Customers Table.
         Dim i As Integer
         For i = 1 To 3
            newRow1 = tCustomers.NewRow()
            newRow1("custID") = i
            ' Add the row to the Customers table.
            tCustomers.Rows.Add(newRow1)
         Next i
         ' Give each customer a distinct name.
         tCustomers.Rows(0)("custName") = "Customer 1"
         tCustomers.Rows(1)("custName") = "Customer 2"
         tCustomers.Rows(2)("custName") = "Customer 3"
         
         ' Give the Current column a value.
         tCustomers.Rows(0)("Current") = True
         tCustomers.Rows(1)("Current") = True
         tCustomers.Rows(2)("Current") = False
         Return myDataSet
      End Function 'MakeDataSet
      
      
      Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
' <Snippet1>
         ' Creates a common color dialog box.
         Dim myColorDialog As New ColorDialog()
         myColorDialog.AllowFullOpen = False
         ' Allow the user to get help. 
         myColorDialog.ShowHelp = True
         ' Set the initial color select to the current color.
         myColorDialog.Color = customersStyle.SelectionForeColor
         ' Show color dialog box.
         myColorDialog.ShowDialog()
         ' Set selection fore color to selected color.
         customersStyle.SelectionForeColor = myColorDialog.Color
' </Snippet1>
      End Sub 'button1_Click

      Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
' <Snippet2>
         ' String variable used to show message.   
         Dim myString As String = "Fore color changed from: "
         ' Store current foreground color of selected cells.
         Dim myCurrentColor As Color = customersStyle.SelectionForeColor
         myString += myCurrentColor.ToString()
         ' Reset selection fore color to default.
         customersStyle.ResetSelectionForeColor()
         myString += "  to "
         myString += customersStyle.SelectionForeColor.ToString()
         ' Show information about changes in color setting.  
         MessageBox.Show(myString, "Selection fore color information")
' </Snippet2>
      End Sub 'button2_Click 
   End Class 'MyForm
End Namespace 'MyDataGridNamespace