'<snippet3>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module PerfCounterCatCtorMod

    '<snippet4>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim machineName As String = ""
        Dim pcc As PerformanceCounterCategory

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            machineName = IIf(args(1) = ".", "", args(1))
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        ' Create a PerformanceCounterCategory object using 
        ' the appropriate constructor.
        If categoryName.Length = 0 Then
            pcc = New PerformanceCounterCategory
        ElseIf machineName.Length = 0 Then
            pcc = New PerformanceCounterCategory(categoryName)
        Else
            pcc = New PerformanceCounterCategory(categoryName, machineName)
        End If

        ' Display the properties of the PerformanceCounterCategory object.
        Try
            Console.WriteLine("  Category:  {0}", pcc.CategoryName)
            Console.WriteLine("  Computer:  {0}", pcc.MachineName)
            Console.WriteLine("  Help text: {0}", pcc.CategoryHelp)
        Catch ex As Exception
            Console.WriteLine("Error getting the properties of the " & _
                "PerformanceCounterCategory object:")
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    '</snippet4>
End Module
'</snippet3>
