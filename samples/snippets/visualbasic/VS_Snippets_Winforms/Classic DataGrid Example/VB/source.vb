' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits System.Windows.Forms.Form
   Private components As System.ComponentModel.Container
   Private button1 As Button
   Private button2 As Button
   Private myDataGrid As DataGrid
   Private myDataSet As DataSet
   Private TablesAlreadyAdded As Boolean    
    
   Public Sub New()
      ' Required for Windows Form Designer support.
      InitializeComponent()
      ' Call SetUp to bind the controls.
      SetUp()
   End Sub 
        
  Private Sub InitializeComponent()
      ' Create the form and its controls.
      Me.components = New System.ComponentModel.Container()
      Me.button1 = New System.Windows.Forms.Button()
      Me.button2 = New System.Windows.Forms.Button()
      Me.myDataGrid = New DataGrid()
      
      Me.Text = "DataGrid Control Sample"
      Me.ClientSize = New System.Drawing.Size(450, 330)
        
      button1.Location = New Point(24, 16)
      button1.Size = New System.Drawing.Size(120, 24)
      button1.Text = "Change Appearance"
      AddHandler button1.Click, AddressOf button1_Click
        
      button2.Location = New Point(150, 16)
      button2.Size = New System.Drawing.Size(120, 24)
      button2.Text = "Get Binding Manager"
      AddHandler button2.Click, AddressOf button2_Click
        
      myDataGrid.Location = New Point(24, 50)
      myDataGrid.Size = New Size(300, 200)
      myDataGrid.CaptionText = "Microsoft DataGrid Control"
      AddHandler myDataGrid.MouseUp, AddressOf Grid_MouseUp
        
      Me.Controls.Add(button1)
      Me.Controls.Add(button2)
      Me.Controls.Add(myDataGrid)
   End Sub 
    
   Public Shared Sub Main()
      Application.Run(New Form1())
   End Sub 
        
   Private Sub SetUp()
      ' Create a DataSet with two tables and one relation.
      MakeDataSet()
      ' Bind the DataGrid to the DataSet. The dataMember
      ' specifies that the Customers table should be displayed.
      myDataGrid.SetDataBinding(myDataSet, "Customers")
   End Sub 
        
    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If TablesAlreadyAdded = True Then Exit Sub
        AddCustomDataTableStyle()
    End Sub
   
   Private Sub AddCustomDataTableStyle()
      Dim ts1 As New DataGridTableStyle()
      ts1.MappingName = "Customers"
      ' Set other properties.
      ts1.AlternatingBackColor = Color.LightGray
      ' Add a GridColumnStyle and set its MappingName 
      ' to the name of a DataColumn in the DataTable. 
      ' Set the HeaderText and Width properties. 
        
      Dim boolCol As New DataGridBoolColumn()
      boolCol.MappingName = "Current"
      boolCol.HeaderText = "IsCurrent Customer"
      boolCol.Width = 150
      ts1.GridColumnStyles.Add(boolCol)
        
      ' Add a second column style.
      Dim TextCol As New DataGridTextBoxColumn()
      TextCol.MappingName = "custName"
      TextCol.HeaderText = "Customer Name"
      TextCol.Width = 250
      ts1.GridColumnStyles.Add(TextCol)
        
      ' Create the second table style with columns.
      Dim ts2 As New DataGridTableStyle()
      ts2.MappingName = "Orders"
        
      ' Set other properties.
      ts2.AlternatingBackColor = Color.LightBlue
        
      ' Create new ColumnStyle objects
      Dim cOrderDate As New DataGridTextBoxColumn()
      cOrderDate.MappingName = "OrderDate"
      cOrderDate.HeaderText = "Order Date"
      cOrderDate.Width = 100
      ts2.GridColumnStyles.Add(cOrderDate)

      ' Use a PropertyDescriptor to create a formatted
      ' column. First get the PropertyDescriptorCollection
      ' for the data source and data member. 
      Dim pcol As PropertyDescriptorCollection = _
      Me.BindingContext(myDataSet, "Customers.custToOrders"). _
      GetItemProperties()

      ' Create a formatted column using a PropertyDescriptor.
      ' The formatting character "c" specifies a currency format. */     
        
      Dim csOrderAmount As _
      New DataGridTextBoxColumn(pcol("OrderAmount"), "c", True)
      csOrderAmount.MappingName = "OrderAmount"
      csOrderAmount.HeaderText = "Total"
      csOrderAmount.Width = 100
      ts2.GridColumnStyles.Add(csOrderAmount)
        
      ' Add the DataGridTableStyle instances to 
      ' the GridTableStylesCollection. 
      myDataGrid.TableStyles.Add(ts1)
      myDataGrid.TableStyles.Add(ts2)

     ' Sets the TablesAlreadyAdded to true so this doesn't happen again.
      TablesAlreadyAdded = true
   End Sub 
    
    Private Sub button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim bmGrid As BindingManagerBase
        bmGrid = BindingContext(myDataSet, "Customers")
        MessageBox.Show(("Current BindingManager Position: " & bmGrid.Position))
    End Sub
        
   Private Sub Grid_MouseUp(sender As Object, e As MouseEventArgs)
      ' Create a HitTestInfo object using the HitTest method.
      ' Get the DataGrid by casting sender.
      Dim myGrid As DataGrid = CType(sender, DataGrid)
      Dim myHitInfo As DataGrid.HitTestInfo = myGrid.HitTest(e.X, e.Y)
      Console.WriteLine(myHitInfo)
      Console.WriteLine(myHitInfo.Type)
      Console.WriteLine(myHitInfo.Row)
      Console.WriteLine(myHitInfo.Column)
   End Sub 
        
   ' Create a DataSet with two tables and populate it.
   Private Sub MakeDataSet()
      ' Create a DataSet.
      myDataSet = New DataSet("myDataSet")
       
      ' Create two DataTables.
      Dim tCust As New DataTable("Customers")
      Dim tOrders As New DataTable("Orders")
      
      ' Create two columns, and add them to the first table.
      Dim cCustID As New DataColumn("CustID", GetType(Integer))
      Dim cCustName As New DataColumn("CustName")
      Dim cCurrent As New DataColumn("Current", GetType(Boolean))
      tCust.Columns.Add(cCustID)
      tCust.Columns.Add(cCustName)
      tCust.Columns.Add(cCurrent)
       
      ' Create three columns, and add them to the second table.
      Dim cID As New DataColumn("CustID", GetType(Integer))
      Dim cOrderDate As New DataColumn("orderDate", GetType(DateTime))
      Dim cOrderAmount As New DataColumn("OrderAmount", GetType(Decimal))
      tOrders.Columns.Add(cOrderAmount)
      tOrders.Columns.Add(cID)
      tOrders.Columns.Add(cOrderDate)
       
      ' Add the tables to the DataSet.
      myDataSet.Tables.Add(tCust)
      myDataSet.Tables.Add(tOrders)
        
      ' Create a DataRelation, and add it to the DataSet.
      Dim dr As New DataRelation("custToOrders", cCustID, cID)
      myDataSet.Relations.Add(dr)
        
      ' Populates the tables. For each customer and order, 
      ' creates two DataRow variables. 
      Dim newRow1 As DataRow
      Dim newRow2 As DataRow
        
      ' Create three customers in the Customers Table.
      Dim i As Integer
      For i = 1 To 3
         newRow1 = tCust.NewRow()
         newRow1("custID") = i
         ' Add the row to the Customers table.
         tCust.Rows.Add(newRow1)
      Next i
      ' Give each customer a distinct name.
      tCust.Rows(0)("custName") = "Customer1"
      tCust.Rows(1)("custName") = "Customer2"
      tCust.Rows(2)("custName") = "Customer3"
        
      ' Give the Current column a value.
      tCust.Rows(0)("Current") = True
      tCust.Rows(1)("Current") = True
      tCust.Rows(2)("Current") = False
        
      ' For each customer, create five rows in the Orders table.
      For i = 1 To 3
         Dim j As Integer
         For j = 1 To 5
            newRow2 = tOrders.NewRow()
            newRow2("CustID") = i
            newRow2("orderDate") = New DateTime(2001, i, j * 2)
            newRow2("OrderAmount") = i * 10 + j * 0.1
            ' Add the row to the Orders table.
            tOrders.Rows.Add(newRow2)
         Next j
      Next i
   End Sub 
End Class 
' </Snippet1>
