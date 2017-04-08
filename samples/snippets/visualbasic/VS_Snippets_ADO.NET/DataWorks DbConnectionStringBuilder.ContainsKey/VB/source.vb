Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common

Module Module1

    ' <Snippet1>
    Sub Main()
        ' The following code example searches for an element in a 
        ' DbConnectionStringBuilder.
        Dim builder As New DbConnectionStringBuilder
        builder.Add("Provider", "Provider=Microsoft.Jet.OLEDB.4.0")
        builder.Add("Data Source", "C:\ThisExcelWorkbook.xls")
        builder.Add("Extended Properties", "Excel 8.0;HDR=Yes;IMEX=1")

        ' Displays the values in the DbConnectionStringBuilder.
        Console.WriteLine("Contents of the DbConnectionStringBuilder:")
        Console.WriteLine(builder.ConnectionString)

        ' Searches for a key.
        If builder.ContainsKey("Data Source") Then
            Console.WriteLine("The collection contains the key ""Data Source"".")
        Else
            Console.WriteLine("The collection does not contain the key ""Data Source"".")
        End If
        Console.ReadLine()
    End Sub
    ' </Snippet1>

End Module
