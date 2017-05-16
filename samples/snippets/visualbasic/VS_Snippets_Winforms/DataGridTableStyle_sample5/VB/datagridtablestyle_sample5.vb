' System.Windows.Forms.DataGridTableStyle.AlternatingBackColor;
' System.Windows.Forms.DataGridTableStyle.GridLineColor;
' System.Windows.Forms.DataGridTableStyle.GridLineColorChanged;
'
' The following example demonstrates properties 'GridLineColor',
' 'AlternatingBackColor'  and event 'GridLineColorChanged' of
' 'DataGridTableStyle' class.
' It creates a Windows form, a DataSet containing two DataTable
' objects,and a DataRelation that relates the two tables. A button on
' the form changes the appearance of the grid by setting the
' GridLineColor and AlternatingBackColor.
'

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Namespace SampleDataGridTableStyle

   Public Class DataGridTableStyle_Sample
      Inherits System.Windows.Forms.Form
      Private myDataGrid As System.Windows.Forms.DataGrid
      Private myDataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
      Private myDataSet As DataSet
      Private WithEvents btnApplyStyles As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing


      Public Sub New()
         InitializeComponent()
         ' Call SetUp to bind the controls.
         SetUp()
      End Sub 'New

      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose

      Private Sub InitializeComponent() '
         Me.btnApplyStyles = New System.Windows.Forms.Button()
         Me.myDataGrid = New System.Windows.Forms.DataGrid()
         CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         ' btnApplyStyles
         '
         Me.btnApplyStyles.Font = New System.Drawing.Font("Arial", 8.25F, _
                     System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
         Me.btnApplyStyles.Location = New System.Drawing.Point(88, 208)
         Me.btnApplyStyles.Name = "btnApplyStyles"
         Me.btnApplyStyles.Size = New System.Drawing.Size(144, 40)
         Me.btnApplyStyles.TabIndex = 1
         Me.btnApplyStyles.Text = "Apply Custom  Styles"
         '
         ' myDataGrid
         '
         Me.myDataGrid.AlternatingBackColor = System.Drawing.SystemColors.Info
         Me.myDataGrid.BackColor = System.Drawing.Color.Silver
         Me.myDataGrid.CaptionText = "Microsoft DataGrid Control"
         Me.myDataGrid.DataMember = ""
         Me.myDataGrid.LinkColor = System.Drawing.Color.Gray
         Me.myDataGrid.Location = New System.Drawing.Point(48, 32)
         Me.myDataGrid.Name = "myDataGrid"
         Me.myDataGrid.Size = New System.Drawing.Size(312, 128)
         Me.myDataGrid.TabIndex = 0
         '
         ' DataGridTableStyle_Sample
         '
         Me.ClientSize = New System.Drawing.Size(384, 301)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnApplyStyles, Me.myDataGrid})
         Me.Name = "DataGridTableStyle_Sample"
         Me.Text = "DataGridTableStyle_Sample"
         CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent

      <STAThread()> Shared Sub Main()      '
         Application.Run(New DataGridTableStyle_Sample())
      End Sub 'Main

      Private Sub SetUp()
         ' Create a DataSet with two tables and one relation.
         MakeDataSet()
         ' Bind the DataGrid to the DataSet.
         ' The dataMember specifies that the Customers table should be displayed.
         myDataGrid.SetDataBinding(myDataSet, "Customers")
      End Sub 'SetUp

' <Snippet1>
' <Snippet2>
' <Snippet3>
      Private Sub AddCustomDataTableStyle()
         myDataGridTableStyle1 = New DataGridTableStyle()

         ' EventHandlers
         AddHandler myDataGridTableStyle1.GridLineColorChanged, AddressOf GridLineColorChanged_Handler
         myDataGridTableStyle1.MappingName = "Customers"

         ' Set other properties.
         myDataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gold
         myDataGridTableStyle1.BackColor = System.Drawing.Color.White
         myDataGridTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.Solid
         myDataGridTableStyle1.GridLineColor = Color.Red

         ' Set the HeaderText and Width properties.
         Dim myBoolCol = New DataGridBoolColumn()
         myBoolCol.MappingName = "Current"
         myBoolCol.HeaderText = "IsCurrent Customer"
         myBoolCol.Width = 150
         myDataGridTableStyle1.GridColumnStyles.Add(myBoolCol)

         ' Add a second column style.
         Dim myTextCol = New DataGridTextBoxColumn()
         myTextCol.MappingName = "custName"
         myTextCol.HeaderText = "Customer Name"
         myTextCol.Width = 250
         myDataGridTableStyle1.GridColumnStyles.Add(myTextCol)

         ' Create new ColumnStyle objects
         Dim cOrderDate = New DataGridTextBoxColumn()
         cOrderDate.MappingName = "OrderDate"
         cOrderDate.HeaderText = "Order Date"
         cOrderDate.Width = 100

         ' Use a PropertyDescriptor to create a formatted column.
         Dim myPropertyDescriptorCollection As PropertyDescriptorCollection = _
                        BindingContext(myDataSet, "Customers.custToOrders").GetItemProperties()

         ' Create a formatted column using a PropertyDescriptor.
         Dim csOrderAmount = New DataGridTextBoxColumn(myPropertyDescriptorCollection( _
                                                      "OrderAmount"), "c", True)
         csOrderAmount.MappingName = "OrderAmount"
         csOrderAmount.HeaderText = "Total"
         csOrderAmount.Width = 100

         ' Add the DataGridTableStyle instances to the GridTableStylesCollection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1)
      End Sub 'AddCustomDataTableStyle

      Private Sub GridLineColorChanged_Handler(ByVal sender As Object, ByVal e As EventArgs)
         MessageBox.Show("GridLineColor Changed", "DataGridTableStyle")
      End Sub 'GridLineColorChanged_Handler
' </Snippet3>
' </Snippet2>
' </Snippet1>

      ' Create a DataSet with two tables and populate it.
      Private Sub MakeDataSet()
         ' Create a DataSet.
         myDataSet = New DataSet("myDataSet")

         ' Create Customer DataTables.
         Dim tCust As New DataTable("Customers")

         ' Create two columns, and add them to the first table.
         Dim cCustID As New DataColumn("CustID", GetType(Integer))
         Dim cCustName As New DataColumn("CustName")
         Dim cCurrent As New DataColumn("Current", GetType(Boolean))
         tCust.Columns.Add(cCustID)
         tCust.Columns.Add(cCustName)
         tCust.Columns.Add(cCurrent)

         ' Create Customer order table.
         Dim tOrders As New DataTable("Orders")

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

         ' Populate the tables.
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
         tCust.Rows(0)("custName") = "Alpha"
         tCust.Rows(1)("custName") = "Beta"
         tCust.Rows(2)("custName") = "Gamma"

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
      End Sub 'MakeDataSet

      Private Sub btnApplyStyles_Click(ByVal sender As Object, _
                              ByVal e As EventArgs) Handles btnApplyStyles.Click
         AddCustomDataTableStyle()
         btnApplyStyles.Enabled = False
      End Sub 'btnApplyStyles_Click
   End Class 'DataGridTableStyle_Sample
End Namespace 'SampleDataGridTableStyle




