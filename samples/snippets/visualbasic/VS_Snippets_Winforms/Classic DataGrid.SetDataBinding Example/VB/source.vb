Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub BindControls()
        ' Create a DataSet named SuppliersProducts.
        Dim SuppliersProducts As New DataSet("SuppliersProducts")
        ' Adds two DataTable objects, Suppliers and Products.
        SuppliersProducts.Tables.Add(New DataTable("Suppliers"))
        SuppliersProducts.Tables.Add(New DataTable("Products"))
        ' Insert code to add DataColumn objects.
        ' Insert code to fill tables with columns and data.
        ' Binds the DataGrid to the DataSet, displaying the Suppliers table.
        dataGrid1.SetDataBinding(SuppliersProducts, "Suppliers")
    End Sub 'BindControls
    ' </Snippet1>
End Class 'Form1 

