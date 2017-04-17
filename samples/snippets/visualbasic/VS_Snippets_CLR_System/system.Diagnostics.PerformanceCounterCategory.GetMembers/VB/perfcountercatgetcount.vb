'<snippet3>
Imports System
Imports System.Diagnostics

Module PerfCounterCatGetCountMod

    '<snippet4>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim machineName As String = ""
        Dim instanceName As String = ""
        Dim pcc As PerformanceCounterCategory
        Dim counters() As PerformanceCounter

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            machineName = IIf(args(1) = ".", "", args(1))
            instanceName = args(2)
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        Try
            ' Create the appropriate PerformanceCounterCategory object.
            If machineName.Length > 0 Then
                pcc = New PerformanceCounterCategory(categoryName, machineName)
            Else
                pcc = New PerformanceCounterCategory(categoryName)
            End If

            ' Get the counters for this instance or a single instance 
            ' of the selected category.
            If instanceName.Length > 0 Then
                counters = pcc.GetCounters(instanceName)
            Else
                counters = pcc.GetCounters()
            End If

        Catch ex As Exception
            Console.WriteLine("Unable to get counter information for " & _
                IIf(instanceName.Length > 0, "instance ""{2}"" in ", _
                "single-instance ") & "category ""{0}"" on " & _
                IIf(machineName.Length > 0, "computer ""{1}"":", _
                "this computer:"), _
                categoryName, machineName, instanceName)
            Console.WriteLine(ex.Message)
            Return
        End Try

        ' Display the counter names if GetCounters was successful.
        If Not counters Is Nothing Then
            Console.WriteLine("These counters exist in " & _
                IIf(instanceName.Length > 0, "instance ""{1}"" of", _
                "single instance") & " category {0} on " & _
                IIf(machineName.Length > 0, _
                    "computer ""{2}"":", "this computer:"), _
                categoryName, instanceName, machineName)

            ' Display a numbered list of the counter names.
            Dim objX As Integer
            For objX = 0 To counters.Length - 1
                Console.WriteLine("{0,4} - {1}", objX + 1, _
                    counters(objX).CounterName)
            Next objX
        End If
    End Sub
    '</snippet4>
End Module
'</snippet3>
