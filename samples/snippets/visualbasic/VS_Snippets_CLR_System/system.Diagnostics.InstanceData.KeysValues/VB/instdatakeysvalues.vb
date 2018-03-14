'<snippet1>
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports Microsoft.VisualBasic

Module InstDataKeysValuesMod

    '<snippet5>
    Private categoryName As String
    '</snippet5>

    Sub Main()
        Dim catNumStr As String
        Dim categoryNum As Integer

        Dim categories As PerformanceCounterCategory() = _
            PerformanceCounterCategory.GetCategories()

        Console.WriteLine( _
            "These categories are registered on this computer:")

        Dim catX As Integer
        For catX = 0 To categories.Length - 1
            Console.WriteLine("{0,4} - {1}", catX + 1, _
                categories(catX).CategoryName)
        Next catX

        ' Ask the user to choose a category.
        Console.Write( _
            "Enter the category number from the above list: ")
        catNumStr = Console.ReadLine()

        ' Validate the entered category number.
        Try
            categoryNum = Integer.Parse(catNumStr)
            If categoryNum < 1 Or categoryNum > categories.Length Then
                Throw New Exception( _
                    String.Format("The category number must be in the " & _
                        "range 1..{0}.", categories.Length))
            End If
            categoryName = categories((categoryNum - 1)).CategoryName

        Catch ex As Exception
            Console.WriteLine("""{0}"" is not a valid category number." & _
                vbCrLf & "{1}", catNumStr, ex.Message)
            Return
        End Try
        '<snippet4>

        ' Process the InstanceDataCollectionCollection for this category.
        Dim pcc As New PerformanceCounterCategory(categoryName)
        Dim idColCol As InstanceDataCollectionCollection = pcc.ReadCategory()

        Dim idColColKeys As ICollection = idColCol.Keys
        Dim idCCKeysArray(idColColKeys.Count - 1) As String
        idColColKeys.CopyTo(idCCKeysArray, 0)

        Dim idColColValues As ICollection = idColCol.Values
        Dim idCCValuesArray(idColColValues.Count - 1) As InstanceDataCollection
        idColColValues.CopyTo(idCCValuesArray, 0)

        Console.WriteLine("InstanceDataCollectionCollection for ""{0}"" " & _
            "has {1} elements.", categoryName, idColCol.Count)

        ' Display the InstanceDataCollectionCollection Keys and Values.
        ' The Keys and Values collections have the same number of elements.
        Dim index As Integer
        For index = 0 To idCCKeysArray.Length - 1
            Console.WriteLine("  Next InstanceDataCollectionCollection " & _
                "Key is ""{0}""", idCCKeysArray(index))
            ProcessInstanceDataCollection(idCCValuesArray(index))
        Next index
        '</snippet4>
    End Sub

    '<snippet3>
    '<snippet2>
    ' Display the contents of an InstanceDataCollection.
    Sub ProcessInstanceDataCollection(ByVal idCol As InstanceDataCollection)
        '</snippet2>

        Dim idColKeys As ICollection = idCol.Keys
        Dim idColKeysArray(idColKeys.Count - 1) As String
        idColKeys.CopyTo(idColKeysArray, 0)

        Dim idColValues As ICollection = idCol.Values
        Dim idColValuesArray(idColValues.Count - 1) As InstanceData
        idColValues.CopyTo(idColValuesArray, 0)
        '<snippet6>

        Console.WriteLine("  InstanceDataCollection for ""{0}"" " & _
            "has {1} elements.", idCol.CounterName, idCol.Count)
        '</snippet6>

        ' Display the InstanceDataCollection Keys and Values.
        ' The Keys and Values collections have the same number of elements.
        Dim index As Integer
        For index = 0 To idColKeysArray.Length - 1
            Console.WriteLine("    Next InstanceDataCollection " & _
                "Key is ""{0}""", idColKeysArray(index))
            ProcessInstanceDataObject(idColValuesArray(index))
        Next index
        '<snippet7>
    End Sub
    '</snippet7>
    '</snippet3>

    ' Display the contents of an InstanceData object.
    Sub ProcessInstanceDataObject(ByVal instData As InstanceData)
        Dim sample As CounterSample = instData.Sample

        Console.WriteLine("    From InstanceData:" & vbCrLf & "      " & _
            "InstanceName: {0,-31} RawValue: {1}", _
            instData.InstanceName, instData.Sample.RawValue)
        Console.WriteLine("    From CounterSample:" & vbCrLf & "      " & _
            "CounterType: {0,-32} SystemFrequency: {1}" & vbCrLf & _
            "      BaseValue: {2,-34} RawValue: {3}" & vbCrLf & _
            "      CounterFrequency: {4,-27} CounterTimeStamp: {5}" & vbCrLf & _
            "      TimeStamp: {6,-34} TimeStamp100nSec: {7}", _
            sample.CounterType, sample.SystemFrequency, sample.BaseValue, _
            sample.RawValue, sample.CounterFrequency, sample.CounterTimeStamp, _
            sample.TimeStamp, sample.TimeStamp100nSec)
    End Sub
End Module
'</snippet1>
