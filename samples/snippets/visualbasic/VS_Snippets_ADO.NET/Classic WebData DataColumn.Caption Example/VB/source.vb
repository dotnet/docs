imports System
imports System.Data


Public Class sample


' <Snippet1>
Private Sub CreateDataTable()
    Dim table As DataTable
    Dim column As DataColumn 

    table = new DataTable("Customers")

    'CustomerID column
    column = table.Columns.Add( _
        "CustomerID", System.Type.GetType("System.Int32"))
    column.Unique = True
	
    'CustomerName column
    column = table.Columns.Add( _
        "CustomerName", System.Type.GetType("System.String"))
    column.Caption = "Name"

    'CreditLimit
    column = table.Columns.Add( _
        "CreditLimit", System.Type.GetType("System.Double"))
    column.DefaultValue = 0
    column.Caption = "Limit"

    table.Rows.Add(new object() {1, "Jonathan", 23.44})
    table.Rows.Add(new object() {2, "Bill", 56.87})
End Sub
' </Snippet1>

End Class
