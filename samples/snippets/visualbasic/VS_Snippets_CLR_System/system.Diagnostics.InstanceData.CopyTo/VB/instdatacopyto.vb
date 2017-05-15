'<snippet1>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module InstDataCopyToMod

    '<snippet7>
    Private categoryName As String
    '</snippet7>

    Sub Main()
        Dim catNumStr As String
        Dim categoryNum As Integer

        Dim categories() As PerformanceCounterCategory = _
            PerformanceCounterCategory.GetCategories()

        ' Create and sort an array of category names.
        Dim categoryNames(categories.Length - 1) As String
        Dim catX As Integer
        For catX = 0 To categories.Length - 1
            categoryNames(catX) = categories(catX).CategoryName
        Next
        Array.Sort(categoryNames)

        Console.WriteLine( _
            "These categories are registered on this computer:")

        For catX = 0 To categories.Length - 1
            Console.WriteLine("{0,4} - {1}", catX + 1, _
                categoryNames(catX))
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
            categoryName = categoryNames((categoryNum - 1))

        Catch ex As Exception
            Console.WriteLine("""{0}"" is not a valid category number." & _
                vbCrLf & "{1}", catNumStr, ex.Message)
            Return
        End Try
        '<snippet5>
        '<snippet6>

        ' Process the InstanceDataCollectionCollection for this category.
        Dim pcc As New PerformanceCounterCategory(categoryName)
        Dim idColCol As InstanceDataCollectionCollection = pcc.ReadCategory()
        Dim idColArray(idColCol.Count - 1) As InstanceDataCollection

        Console.WriteLine("InstanceDataCollectionCollection for ""{0}"" " & _
            "has {1} elements.", categoryName, idColCol.Count)
        '</snippet6>

        ' Copy and process the InstanceDataCollection array.
        idColCol.CopyTo(idColArray, 0)

        Dim idCol As InstanceDataCollection
        For Each idCol In idColArray
            ProcessInstanceDataCollection(idCol)
        Next idCol
        '</snippet5>
    End Sub

    '<snippet4>
    ' Display the contents of an InstanceDataCollection.
    Sub ProcessInstanceDataCollection(ByVal idCol As InstanceDataCollection)

        Dim instDataArray(idCol.Count - 1) As InstanceData

        Console.WriteLine("  InstanceDataCollection for ""{0}"" " & _
            "has {1} elements.", idCol.CounterName, idCol.Count)

        ' Copy and process the InstanceData array.
        idCol.CopyTo(instDataArray, 0)

        Dim idX As Integer
        For idX = 0 To instDataArray.Length - 1
            ProcessInstanceDataObject(instDataArray(idX).InstanceName, _
                instDataArray(idX).Sample)
        Next idX
    End Sub
    '</snippet4>

    '<snippet3>
    '<snippet2>
    ' Display the contents of an InstanceData object.
    Sub ProcessInstanceDataObject(ByVal name As String, _
                                  ByVal CSRef As CounterSample)

        Dim instData As New InstanceData(name, CSRef)
        Console.WriteLine("    Data from InstanceData object:" & vbCrLf & _
            "      InstanceName: {0,-31} RawValue: {1}", _
            instData.InstanceName, instData.RawValue)
        '</snippet2>

        Dim sample As CounterSample = instData.Sample
        Console.WriteLine("    Data from CounterSample object:" & vbCrLf & _
            "      CounterType: {0,-32} SystemFrequency: {1}" & vbCrLf & _
            "      BaseValue: {2,-34} RawValue: {3}" & vbCrLf & _
            "      CounterFrequency: {4,-27} CounterTimeStamp: {5}" & vbCrLf & _
            "      TimeStamp: {6,-34} TimeStamp100nSec: {7}", _
            sample.CounterType, sample.SystemFrequency, sample.BaseValue, _
            sample.RawValue, sample.CounterFrequency, sample.CounterTimeStamp, _
            sample.TimeStamp, sample.TimeStamp100nSec)
        '<snippet8>
    End Sub
    '</snippet8>
    '</snippet3>
End Module
'</snippet1>
