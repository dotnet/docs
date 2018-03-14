'<snippet1>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module InstDataColItemContainsMod

    '<snippet2>
    Sub Main(ByVal args() As String)
        ' These values can be used as arguments.
        Dim categoryName As String = "Process"
        Dim counterName As String = "Private Bytes"
        Dim instanceName As String = "Explorer"

        Dim idCol As InstanceDataCollection
        Const SINGLE_INSTANCE_NAME As String = _
            "systemdiagnosticsperfcounterlibsingleinstance"

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            counterName = args(1)
            instanceName = args(2)
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        Try
            ' Get the InstanceDataCollectionCollection for this category.
            Dim pcc As New PerformanceCounterCategory(categoryName)
            Dim idColCol As InstanceDataCollectionCollection = _
                pcc.ReadCategory()

            ' Get the InstanceDataCollection for this counter.
            idCol = idColCol(counterName)
            If idCol Is Nothing Then
                Throw New Exception("Counter does not exist.")
            End If
        Catch ex As Exception
            Console.WriteLine( _
                "An error occurred getting the InstanceDataCollection for " & _
                "category ""{0}"", counter ""{1}""." & vbCrLf & ex.Message, _
                categoryName, counterName)
            Return
        End Try

        ' If the instance name is empty, use the single-instance name.
        If instanceName.Length = 0 Then
            instanceName = SINGLE_INSTANCE_NAME
        End If

        '<snippet3>
        ' Check if this instance name exists using the Contains
        ' method of the InstanceDataCollection.
        If Not idCol.Contains(instanceName) Then
            '</snippet3>
            Console.WriteLine( _
                "Instance ""{0}"" does not exist in counter ""{1}"", " & _
                "category ""{2}"".", instanceName, counterName, categoryName)
            Return
        Else
            '<snippet4>
            ' The instance name exists, now get its InstanceData object
            ' using the indexer (Item property) for the InstanceDataCollection.
            Dim instData As InstanceData = idCol(instanceName)
            '</snippet4>

            Console.WriteLine("CategoryName: {0}", categoryName)
            Console.WriteLine("CounterName:  {0}", counterName)
            Console.WriteLine("InstanceName: {0}", instData.InstanceName)
            Console.WriteLine("RawValue:     {0}", instData.RawValue)
        End If
    End Sub
    '</snippet2>
End Module
'</snippet1>
