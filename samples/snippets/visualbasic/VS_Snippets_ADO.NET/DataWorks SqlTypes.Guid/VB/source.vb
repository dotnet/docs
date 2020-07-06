Option Explicit On
Option Strict On

Imports System.Data
Imports System.Collections
Imports System.Data.SqlTypes

Module Module1
    Sub Main()
        WorkWithGuids()
        Console.ReadLine()

    End Sub
    ' <Snippet1>
    Private Sub WorkWithGuids()

        ' Create an ArrayList and fill it with Guid values.
        Dim guidList As New ArrayList()
        guidList.Add(New Guid("3AAAAAAA-BBBB-CCCC-DDDD-2EEEEEEEEEEE"))
        guidList.Add(New Guid("2AAAAAAA-BBBB-CCCC-DDDD-1EEEEEEEEEEE"))
        guidList.Add(New Guid("1AAAAAAA-BBBB-CCCC-DDDD-3EEEEEEEEEEE"))

        ' Display the unsorted Guid values.
        Console.WriteLine("Unsorted Guids:")
        For Each guidValue As Guid In guidList
            Console.WriteLine("{0}", guidValue)
        Next
        Console.WriteLine()

        ' Sort the Guids.
        guidList.Sort()

        ' Display the sorted Guid values.

        Console.WriteLine("Sorted Guids:")
        For Each guidSorted As Guid In guidList
            Console.WriteLine("{0}", guidSorted)
        Next
        Console.WriteLine()

        ' Create an ArrayList of SqlGuids.
        Dim sqlGuidList As New ArrayList()
        sqlGuidList.Add(New SqlGuid("3AAAAAAA-BBBB-CCCC-DDDD-2EEEEEEEEEEE"))
        sqlGuidList.Add(New SqlGuid("2AAAAAAA-BBBB-CCCC-DDDD-1EEEEEEEEEEE"))
        sqlGuidList.Add(New SqlGuid("1AAAAAAA-BBBB-CCCC-DDDD-3EEEEEEEEEEE"))

        ' Sort the SqlGuids. The unsorted SqlGuids are in the same order
        ' as the unsorted Guid values.
        sqlGuidList.Sort()

        ' Display the sorted SqlGuids. The sorted SqlGuid values are 
        ' ordered differently than the Guid values.
        Console.WriteLine("Sorted SqlGuids:")
        For Each sqlGuidValue As SqlGuid In sqlGuidList
            Console.WriteLine("{0}", sqlGuidValue)
        Next
    End Sub
    ' </Snippet1>
End Module

