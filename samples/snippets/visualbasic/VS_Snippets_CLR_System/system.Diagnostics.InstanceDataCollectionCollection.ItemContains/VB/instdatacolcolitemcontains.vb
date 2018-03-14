'<snippet1>
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports Microsoft.VisualBasic

Module InstDataColColItemContainsMod

    '<snippet2>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim counterName As String = ""

        Dim idColCol As InstanceDataCollectionCollection

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            counterName = args(1)
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        Try
            ' Get the InstanceDataCollectionCollection for this category.
            Dim pcc As New PerformanceCounterCategory(categoryName)
            idColCol = pcc.ReadCategory()
        Catch ex As Exception
            Console.WriteLine( _
                "An error occurred getting the InstanceDataCollection for " & _
                "category ""{0}""." & vbCrLf & ex.Message, categoryName)
            Return
        End Try

        '<snippet3>
        ' Check if this counter name exists using the Contains
        ' method of the InstanceDataCollectionCollection.
        If Not idColCol.Contains(counterName) Then
            '</snippet3>
            Console.WriteLine( _
                "Counter ""{0}"" does not exist in category ""{1}"".", _
                counterName, categoryName)
            Return
        Else
            '<snippet4>
            ' Now get the counter's InstanceDataCollection object using the
            ' indexer (Item property) for the InstanceDataCollectionCollection.
            Dim countData As InstanceDataCollection = idColCol(counterName)
            '</snippet4>

            Dim idColKeys As ICollection = countData.Keys
            Dim idColKeysArray(idColKeys.Count - 1) As String
            idColKeys.CopyTo(idColKeysArray, 0)

            Console.WriteLine("Counter ""{0}"" of category ""{1}"" " & _
                "has {2} instances.", counterName, categoryName, idColKeys.Count)

            ' Display the instance names for this counter.
            Dim index As Integer
            For index = 0 To idColKeysArray.Length - 1
                Console.WriteLine("{0,4} -- {1}", index + 1, idColKeysArray(index))
            Next index
        End If
    End Sub
    '</snippet2>
End Module
'</snippet1>

