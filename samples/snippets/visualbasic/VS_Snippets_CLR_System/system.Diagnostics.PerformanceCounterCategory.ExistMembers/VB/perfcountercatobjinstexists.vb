'<snippet1>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module PerfCounterCatObjInstExistsMod

    '<snippet2>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim instanceName As String = ""
        Dim machineName As String = ""
        Dim objectExists As Boolean = False
        Dim pcc As PerformanceCounterCategory
        Const SINGLE_INSTANCE_NAME As String = _
            "systemdiagnosticsperfcounterlibsingleinstance"

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            instanceName = args(1)
            machineName = IIf(args(2) = ".", "", args(2))
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        ' Use the given instance name or use the default single-instance name.
        If instanceName.Length = 0 Then
            instanceName = SINGLE_INSTANCE_NAME
        End If

        Try
            If machineName.Length = 0 Then
                pcc = New PerformanceCounterCategory(categoryName)
            Else
                pcc = New PerformanceCounterCategory(categoryName, machineName)
            End If

            ' Check whether the instance exists.
            ' Use the per-instance overload of InstanceExists.
            objectExists = pcc.InstanceExists(instanceName)

        Catch ex As Exception
            Console.WriteLine("Unable to check for the existence of " & _
                "instance ""{0}"" in category ""{1}"" on " & _
                IIf(machineName.Length > 0, _
                "computer ""{2}"":", "this computer:") & vbCrLf & _
                ex.Message, instanceName, categoryName, machineName)
            Return
        End Try

        ' Tell the user whether the instance exists.
        Console.WriteLine("Instance ""{0}"" " & _
            IIf(objectExists, "exists", "does not exist") & _
            " in category ""{1}"" on " & _
            IIf(machineName.Length > 0, _
                "computer ""{2}"".", "this computer."), _
            instanceName, pcc.CategoryName, pcc.MachineName)
    End Sub
    '</snippet2>
End Module
'</snippet1>