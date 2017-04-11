imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
Private Sub AddDataColumn(ByVal table As DataTable)
    Dim column As DataColumn 
    Dim decimalType As System.Type
 
    decimalType = System.Type.GetType("System.Decimal")
    column = New DataColumn("Tax", decimalType, "UnitPrice * .0862")

    ' Set various properties.
    With column
       .AutoIncrement = False
       .ReadOnly = True
    End With

    ' Add to Columns collection.
    table.Columns.Add(column)
 End Sub
    ' </Snippet1>

End Class
