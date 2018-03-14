Imports System.Data
Imports System.Data.SqlClient
'Imports System.Data.OleDb
'Imports System.Configuration
'Imports System.Data.Common

Class Program

    Shared Sub Main()

    End Sub

    ' <Snippet1>
    Private Sub TestGetValues(ByVal reader As DataTableReader)

        ' Given a DataTableReader, use the GetValues
        ' method to retrieve a full row of data.

        ' Test the GetValues method, passing in an array large
        ' enough for all the columns.
        Dim values(reader.FieldCount - 1) As Object
        Dim fieldCount As Integer = reader.GetValues(values)
        Console.WriteLine("reader.GetValues retrieved {0} columns.", _
             fieldCount)
        For i As Integer = 0 To fieldCount - 1
            Console.WriteLine(values(i))
        Next

        Console.WriteLine()

        ' Now repeat, using an array that may contain a different 
        ' number of columns than the original data. This should work correctly,
        ' whether the size of the array is larger or smaller than 
        ' the number of columns.

        ' Attempt to retrieve three columns of data.
        ReDim values(2)
        fieldCount = reader.GetValues(values)
        Console.WriteLine("reader.GetValues retrieved {0} columns.", _
             fieldCount)
        For i As Integer = 0 To fieldCount - 1
            Console.WriteLine(values(i))
        Next
    End Sub
    ' </Snippet1>

    ' <Snippet2>
    Private Sub TestGetValues(ByVal reader As SqlDataReader)

        ' Given a SqlDataReader, use the GetValues
        ' method to retrieve a full row of data.

        ' Test the GetValues method, passing in an array large
        ' enough for all the columns.
        Dim values(reader.FieldCount - 1) As Object
        Dim fieldCount As Integer = reader.GetValues(values)
        Console.WriteLine("reader.GetValues retrieved {0} columns.", _
             fieldCount)
        For i As Integer = 0 To fieldCount - 1
            Console.WriteLine(values(i))
        Next

        Console.WriteLine()

        ' Now repeat, using an array that may contain a different 
        ' number of columns than the original data. This should work correctly,
        ' whether the size of the array is larger or smaller than 
        ' the number of columns.

        ' Attempt to retrieve three columns of data.
        ReDim values(2)
        fieldCount = reader.GetValues(values)
        Console.WriteLine("reader.GetValues retrieved {0} columns.", _
        fieldCount)
        For i As Integer = 0 To fieldCount - 1
            Console.WriteLine(values(i))
        Next
    End Sub
    ' </Snippet2>
End Class

