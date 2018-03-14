'<snippet5>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module PerfCounterCatExistsMod

    '<snippet6>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim machineName As String = ""
        Dim objectExists As Boolean = False

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            machineName = IIf(args(1) = ".", "", args(1))
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        ' Check if the specified category exists.
        Try
            If machineName.Length = 0 Then
                objectExists = PerformanceCounterCategory.Exists(categoryName)
            Else
                objectExists = PerformanceCounterCategory.Exists( _
                    categoryName, machineName)
            End If

        Catch ex As Exception
            Console.WriteLine("Unable to check for existence of " & _
                "category ""{0}"" on " & IIf(machineName.Length > 0, _
                "computer ""{1}"":", "this computer:") & vbCrLf & _
                ex.Message, categoryName, machineName)
            Return
        End Try

        ' Tell the user whether the category exists.
        Console.WriteLine("Category ""{0}"" " & _
            IIf(objectExists, "exists", "does not exist") & _
            " on " & IIf(machineName.Length > 0, _
            "computer ""{1}"".", "this computer."), _
            categoryName, machineName)
    End Sub
    '</snippet6>
End Module
'</snippet5>