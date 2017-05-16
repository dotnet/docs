imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
Public Function MakeDataTable() As DataTable
    
    Dim myTable As DataTable 
    Dim myNewRow As DataRow 
    ' Create a new DataTable.
    myTable = New DataTable("My Table")
 
    ' Create DataColumn objects of data types.
    Dim colString As DataColumn = New DataColumn("StringCol")
    colString.DataType = System.Type.GetType("System.String")
    myTable.Columns.Add(colString) 
 
    Dim colInt32 As DataColumn = New DataColumn("Int32Col")
    colInt32.DataType = System.Type.GetType("System.Int32")
    myTable.Columns.Add(colInt32)
 
    Dim colBoolean As DataColumn = New DataColumn("BooleanCol")
    colBoolean.DataType = System.Type.GetType("System.Boolean")
    myTable.Columns.Add(colBoolean)
 
    Dim colTimeSpan As DataColumn = New DataColumn("TimeSpanCol")
    colTimeSpan.DataType = System.Type.GetType("System.TimeSpan")
    myTable.Columns.Add(colTimeSpan)
 
    Dim colDateTime As DataColumn = New DataColumn("DateTimeCol")
    colDateTime.DataType = System.Type.GetType("System.DateTime")
    myTable.Columns.Add(colDateTime)
 
    Dim colDecimal As DataColumn = New DataColumn("DecimalCol")
    colDecimal.DataType = System.Type.GetType("System.Decimal")
    myTable.Columns.Add(colDecimal)
 
    ' Populate one row with values.
    myNewRow = myTable.NewRow()
 
    myNewRow("StringCol") = "Item Name"
    myNewRow("Int32Col") = 2147483647
    myNewRow("BooleanCol") = True
    myNewRow("TimeSpanCol") = New TimeSpan(10,22,10,15,100)
    myNewRow("DateTimeCol") = System.DateTime.Today
    myNewRow("DecimalCol") = 64.0021
    myNewRow("ByteArrayCol") = New [Byte]() {1, 5, 120}
    myTable.Rows.Add(myNewRow)
    MakeDataTable = myTable  
 End Function
       ' </Snippet1>

End Class
