'<snippet3>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module PerfCounterCatObjCountExistsMod

    '<snippet4>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim counterName As String = ""
        Dim machineName As String = ""
        Dim objectExists As Boolean = False
        Dim pcc As PerformanceCounterCategory

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            counterName = args(1)
            machineName = IIf(args(2) = ".", "", args(2))
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        Try
            If machineName.Length = 0 Then
                pcc = New PerformanceCounterCategory(categoryName)
            Else
                pcc = New PerformanceCounterCategory(categoryName, machineName)
            End If

            ' Check whether the specified counter exists.
            ' Use the per-instance overload of CounterExists.
            objectExists = pcc.CounterExists(counterName)

        Catch ex As Exception
            Console.WriteLine("Unable to check for the existence of " & _
                "counter ""{0}"" in category ""{1}"" on " & _
                IIf(machineName.Length > 0, _
                "computer ""{2}"".", "this computer.") & vbCrLf & _
                ex.Message, counterName, categoryName, machineName)
            Return
        End Try

        ' Tell the user whether the counter exists.
        Console.WriteLine("Counter ""{0}"" " & _
            IIf(objectExists, "exists", "does not exist") & _
            " in category ""{1}"" on " & _
            IIf(machineName.Length > 0, _
                "computer ""{2}"".", "this computer."), _
            counterName, pcc.CategoryName, pcc.MachineName)
    End Sub
    '</snippet4>
End Module
'</snippet3>