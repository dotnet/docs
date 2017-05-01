' System.Windows.Forms.DataGridTableStyle.ResetLinkColor

'  The following program demonstrates the 'ResetLinkColor'
'  of 'System.Windows.Forms.DataGridTableStyle' class.
'  It creates a windows form, a 'DataSet' containing two 'DataTable' 
'  objects, and a 'DataRelation' that relates the two tables. To 
'  display the data, a 'DataGrid' control is then bound to the 
'  'DataSet' through the 'SetDataBinding' method.
'  DataGridTableStyle is attached to one of 'DataTable'.
'  Buttons are provided on form to demonstrate setting link color
'  and 'ResetLinkColor' method.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace DataGridSample
   ' <summary>
   ' Summary description for DatGridClass.
   ' </summary>
   Public Class DatGridClass
      Inherits System.Windows.Forms.Form
      Private myDataSet As DataSet
      Private myDataGrid As System.Windows.Forms.DataGrid
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private withEvents btnResetLinkColor As System.Windows.Forms.Button
      Private withEvents btnSetLinkColor As System.Windows.Forms.Button
      ' <summary>
      ' Required designer variable.
      ' </summary>
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         ' Setup GridControl data.
         SetUp()
      End Sub 'New
      
      
      ' <summary>
      ' Clean up any resources being used.
      ' </summary>
      Protected Overrides Overloads Sub Dispose(disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose

      ' <summary>

      ' </summary>
      Private Sub InitializeComponent()
         Me.btnSetLinkColor = New System.Windows.Forms.Button()
         Me.myDataGrid = New System.Windows.Forms.DataGrid()
         Me.btnResetLinkColor = New System.Windows.Forms.Button()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' btnSetLinkColor
         ' 
         Me.btnSetLinkColor.Location = New System.Drawing.Point(16, 16)
         Me.btnSetLinkColor.Name = "btnSetLinkColor"
         Me.btnSetLinkColor.Size = New System.Drawing.Size(104, 32)
         Me.btnSetLinkColor.TabIndex = 4
         Me.btnSetLinkColor.Text = "Set Link Color"
         ' 
         ' myDataGrid
         ' 
         Me.myDataGrid.DataMember = ""
         Me.myDataGrid.ForeColor = System.Drawing.Color.Blue
         Me.myDataGrid.Location = New System.Drawing.Point(12, 32)
         Me.myDataGrid.Name = "myDataGrid"
         Me.myDataGrid.ReadOnly = True
         Me.myDataGrid.Size = New System.Drawing.Size(272, 192)
         Me.myDataGrid.TabIndex = 6
         ' 
         ' btnResetLinkColor
         ' 
         Me.btnResetLinkColor.Location = New System.Drawing.Point(16, 48)
         Me.btnResetLinkColor.Name = "btnResetLinkColor"
         Me.btnResetLinkColor.Size = New System.Drawing.Size(104, 32)
         Me.btnResetLinkColor.TabIndex = 1
         Me.btnResetLinkColor.Text = "Reset Link Color"
         ' 
         ' groupBox3
         ' 
         Me.groupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSetLinkColor, Me.btnResetLinkColor})
         Me.groupBox3.Location = New System.Drawing.Point(80, 232)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(136, 88)
         Me.groupBox3.TabIndex = 7
         Me.groupBox3.TabStop = False
         ' 
         ' DatGridClass
         ' 
         Me.ClientSize = New System.Drawing.Size(312, 341)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox3, Me.myDataGrid})
         Me.Name = "DatGridClass"
         Me.Text = "Sample Program"
         CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
         Me.groupBox3.ResumeLayout(False)
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent 

      Private myDataGridTableStyle As New DataGridTableStyle()
      
      '/ <summary>
      '/ The main entry point for the application.
      '/ </summary>
      <STAThread()>  Shared Sub Main()
         Application.Run(New DatGridClass())
      End Sub 'Main
      
      Private Sub SetUp()
         ' Create a 'DataSet' with two tables and one relation.
         MakeDataSet()
         ' Bind the 'DataGrid' to the 'DataSet'. 
         myDataGrid.SetDataBinding(myDataSet, "Customers")
      End Sub 'SetUp
      
      ' Create a 'DataSet' with two tables and populate it.
      Private Sub MakeDataSet()
         ' Create a 'DataSet'.
         myDataSet = New DataSet("myDataSet")
         ' Create two 'DataTables'.
         Dim tCust As New DataTable("Customers")
         Dim tOrders As New DataTable("Orders")
         
         ' Create two columns, and add them to the first table.
         Dim cCustID As New DataColumn("CustID", GetType(Integer))
         Dim cCustName As New DataColumn("CustName")
         Dim cCurrent As New DataColumn("Current", GetType(Boolean))
         tCust.Columns.Add(cCustID)
         tCust.Columns.Add(cCustName)
         tCust.Columns.Add(cCurrent)
         
         ' Map 'myDataGridTableStyle' to 'Customers' table.
         myDataGridTableStyle.MappingName = "Customers"
         ' Add the DataGridTableStyle objects to the collection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle)
         
         ' Create three columns and add them to the second table.
         Dim cID As New DataColumn("CustID", GetType(Integer))
         Dim cOrderDate As New DataColumn("OrderDate", GetType(DateTime))
         Dim cOrderAmount As New DataColumn("OrderAmount", GetType(String))
         tOrders.Columns.Add(cID)
         tOrders.Columns.Add(cOrderAmount)
         tOrders.Columns.Add(cOrderDate)
         
         ' Add the tables to the 'DataSet'.
         myDataSet.Tables.Add(tCust)
         myDataSet.Tables.Add(tOrders)
         
         ' Create a 'DataRelation' and add it to the 'DataSet'.
         Dim dr As New DataRelation("custToOrders", cCustID, cID)
         myDataSet.Relations.Add(dr)
         
         ' Populate the tables. 
         ' Create two 'DataRow' variables for customer and order.
         Dim newRow1 As DataRow
         Dim newRow2 As DataRow
         
         ' Create three customers in the 'Customers Table'.
         Dim i As Integer
         For i = 1 To 3
            newRow1 = tCust.NewRow()
            newRow1("custID") = i
            ' Add the row to the 'Customers Table'.
            tCust.Rows.Add(newRow1)
         Next i
         ' Give each customer a distinct name.
         tCust.Rows(0)("custName") = "Customer1"
         tCust.Rows(1)("custName") = "Customer2"
         tCust.Rows(2)("custName") = "Customer3"
         
         ' Give the current column a value.
         tCust.Rows(0)("Current") = True
         tCust.Rows(1)("Current") = True
         tCust.Rows(2)("Current") = False
         
         ' For each customer, create five rows in the orders table.
         Dim myNumber As Double = 0
         Dim myString As String

         For i = 1 To 3
            Dim j As Integer
            For j = 1 To 5
               newRow2 = tOrders.NewRow()
               newRow2("CustID") = i
               newRow2("orderDate") = New DateTime(2001, i, j * 2)
               myNumber = i * 10 + j * 0.1
               myString = "$ "
               myString += myNumber.ToString()
               newRow2("OrderAmount") = myString
               ' Add the row to the orders table.
               tOrders.Rows.Add(newRow2)
            Next j
         Next i
      End Sub 'MakeDataSet
      
      Private Sub btnResetLinkColor_Click(sender As Object, e As EventArgs) Handles btnResetLinkColor.Click
' <Snippet1>
         ' String variable used to show message.   
         Dim myString As String = "Link color changed from: "
         ' Store current foreground color of selected cells.
         Dim myCurrentColor As Color = myDataGridTableStyle.LinkColor
         myString += myCurrentColor.ToString()
         ' Reset link color to default.
         myDataGridTableStyle.ResetLinkColor()
         myString += "  to "
         myString += myDataGridTableStyle.LinkColor.ToString()
         ' Show information about changes in color setting.  
         MessageBox.Show(myString, "Link line color information")
' </Snippet1>
      End Sub 'btnResetLinkColor_Click

      Private Sub btnSetLinkColor_Click(sender As Object, e As EventArgs) Handles btnSetLinkColor.Click
         ' Creates a common color dialog box.
         Dim myColorDialog As New ColorDialog()
         myColorDialog.AllowFullOpen = False
         ' Allow the user to get help. 
         myColorDialog.ShowHelp = True
         ' Set the initial color select to the current color.
         myColorDialog.Color = myDataGridTableStyle.LinkColor
         ' Show color dialog box.
         myColorDialog.ShowDialog()
         ' Set link color to selected color.
         myDataGridTableStyle.LinkColor = myColorDialog.Color
      End Sub 'btnSetLinkColor_Click
   End Class 'DatGridClass
End Namespace 'DataGridSample