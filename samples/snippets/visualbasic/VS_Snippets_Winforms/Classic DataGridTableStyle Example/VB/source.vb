Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel



Public Class Form1
    Inherits Form
    Protected myDataGrid As DataGrid
    Protected myDataSet As DataSet
    
    ' <Snippet1>
    Private Sub AddCustomDataTableStyle()
        ' Create a new DataGridTableStyle and set
        ' its MappingName to the TableName of a DataTable. 
        Dim ts1 As New DataGridTableStyle()
        ts1.MappingName = "Customers"
        
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

        ' Change the colors.
        ts2.ForeColor = Color.Yellow
        ts2.AlternatingBackColor = Color.Blue
        ts2.BackColor = Color.Blue
        
        ' Create new DataGridColumnStyle objects.
        Dim cOrderDate As New DataGridTextBoxColumn()
        cOrderDate.MappingName = "OrderDate"
        cOrderDate.HeaderText = "Order Date"
        cOrderDate.Width = 100
        ts2.GridColumnStyles.Add(cOrderDate)
        
        Dim pcol As PropertyDescriptorCollection = Me.BindingContext(myDataSet, "Customers.custToOrders").GetItemProperties()
        
        Dim csOrderAmount As New DataGridTextBoxColumn(pcol("OrderAmount"), "c", True)
        csOrderAmount.MappingName = "OrderAmount"
        csOrderAmount.HeaderText = "Total"
        csOrderAmount.Width = 100
        ts2.GridColumnStyles.Add(csOrderAmount)

        ' Add the DataGridTableStyle objects to the collection.
        myDataGrid.TableStyles.Add(ts1)
        myDataGrid.TableStyles.Add(ts2)
    End Sub 'AddCustomDataTableStyle
    ' </Snippet1>
End Class 'Form1 

