Imports System
Imports System.Collections
Imports System.Drawing
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Windows.Forms


public class DataGridTableStuff
   Inherits System.Windows.Forms.Form

private myDataGrid as DataGrid 
private myDataSet as DataSet 

Shared Sub Main()

End Sub



private Sub SetUp()

   myDataSet = new DataSet("myDataSet")
   myDataGrid = new DataGrid()
End Sub  

'<snippet1>
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
     
   ' Create new ColumnStyle objects.
   Dim cOrderDate As New DataGridTextBoxColumn()
   cOrderDate.MappingName = "OrderDate"
   cOrderDate.HeaderText = "Order Date"
   cOrderDate.Width = 100
   ts2.GridColumnStyles.Add(cOrderDate)

   ' Use a PropertyDescriptor to create a formatted
   ' column. First get the PropertyDescriptorCollection
   ' for the data source and data member. 
   Dim pcol As System.ComponentModel.PropertyDescriptorCollection = _
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
End Sub 'AddCustomDataTableStyle
  '</snippet1>

  '<snippet2>
   Private Sub GetGridTableByIndex()
      Dim myGridStyle As DataGridTableStyle = _
      myDataGrid.TableStyles(0)
      Console.WriteLine(myGridStyle.MappingName)
   End Sub
   '</snippet2>

  '<snippet3>
   private Sub GetGridTableByName()
      Dim myGridStyle As DataGridTableStyle = _
      myDataGrid.TableStyles("customers")
      Console.WriteLine(myGridStyle.MappingName)
   End Sub
   '</snippet3>

   '<snippet4>
   Private Sub AddDataGridTableStyle()
      ' Create a new DataGridTableStyle and set MappingName.
      Dim myGridStyle As DataGridTableStyle = _
      new DataGridTableStyle()
      myGridStyle.MappingName = "Customers"

      ' Add two DataGridColumnStyle objects.
      Dim colStyle1 As DataGridColumnStyle = _
      new DataGridTextBoxColumn()
      colStyle1.MappingName = "firstName"
      
      Dim colStyle2 As DataGridColumnStyle = _
      new DataGridBoolColumn()
      colStyle2.MappingName = "Current"

      ' Add column styles to table style.
      myGridStyle.GridColumnStyles.Add(colStyle1)
      myGridStyle.GridColumnStyles.Add(colStyle2)   

      ' Add the grid style to the GridStylesCollection.
      myDataGrid.TableStyles.Add(myGridStyle)
   End Sub
   '</snippet4>


   '<snippet5>
   private Sub AddArray()
      ' Get three CurrencyManager objects used to construct 
      ' DataGridTableSTyle objects.
      Dim customersManager As CurrencyManager = _
      CType(me.BindingContext(myDataSet, "Customers"), CurrencyManager)

      Dim regionsManager As CurrencyManager = _
      CType(me.BindingContext(myDataSet, "Customers"), CurrencyManager)

      Dim productsManager As CurrencyManager = _
      CType(me.BindingContext(myDataSet, "Customers"), CurrencyManager)


      Dim gridCustomers As DataGridTableStyle = _
      new DataGridTableStyle(customersManager)
      Dim gridRegions As DataGridTableStyle  = _
      new DataGridTableStyle(regionsManager)
      Dim gridProducts As DataGridTableStyle = _
      new DataGridTableStyle(productsManager)

      ' Create a DataGridTableStyle array.
      Dim myGrids() As DataGridTableStyle = {gridCustomers, gridRegions, gridProducts}

      ' Use AddRange to add to the collection.
      myDataGrid.TableStyles.AddRange(myGrids)

   End Sub
   '</snippet5>

   '<snippet6>
   private Sub TestContains()
      Dim isContained As Boolean
      isContained = myDataGrid.TableStyles.Contains("Customers")
      Console.WriteLine(isContained)
   End Sub
   '</snippet6>

End Class


