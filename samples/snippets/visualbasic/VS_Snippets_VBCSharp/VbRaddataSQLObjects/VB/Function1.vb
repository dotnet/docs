'------------------------------------------------------------------------------
'<Snippet4>
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server

Partial Public Class UserDefinedFunctions

    Public Const SALES_TAX As Double = 0.086

    <SqlFunction()> 
    Public Shared Function addTax(ByVal originalAmount As SqlDouble) As SqlDouble

        Dim taxAmount As SqlDouble = originalAmount * SALES_TAX

        Return originalAmount + taxAmount
    End Function
End Class
'</Snippet4>


'------------------------------------------------------------------------------
'<Snippet10>
Partial Public Class UserDefinedFunctions

    <SqlFunction(Name:="sp_scalarFunc")> 
    Public Shared Function SampleScalarFunction(ByVal s As SqlString) As SqlString

        '...
        Return ""
    End Function
End Class
'</Snippet10>


'------------------------------------------------------------------------------
'<Snippet11>
Partial Public Class UserDefinedFunctions

    <SqlFunction(Name:="sp_tableFunc", TableDefinition:="letter nchar(1)")> 
    Public Shared Function SampleTableFunction(ByVal s As SqlString) As IEnumerable

        '...
        Return New Char(2) {"a"c, "b"c, "c"c}
    End Function
End Class
'</Snippet11>
