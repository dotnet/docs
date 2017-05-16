'<snippet1>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module PerfCounterCatCreateMod

    '<snippet2>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim counterName As String = ""
        Dim categoryHelp As String = ""
        Dim counterHelp As String = ""
        Dim pcc As PerformanceCounterCategory

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            counterName = args(1)
            categoryHelp = args(2)
            counterHelp = args(3)
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        Console.WriteLine("Category name: ""{0}""", categoryName)
        Console.WriteLine("Category help: ""{0}""", categoryHelp)
        Console.WriteLine("Counter name:  ""{0}""", counterName)
        Console.WriteLine("Counter help:  ""{0}""", counterHelp)

        ' Use the Create overload that creates a single counter.
        Try
            pcc = PerformanceCounterCategory.Create( _
                categoryName, categoryHelp, counterName, counterHelp)
            Console.WriteLine("Category ""{0}"" created.", pcc.CategoryName)

        Catch ex As Exception
            Console.WriteLine( _
                "Unable to create the above category and counter:" & _
                vbCrLf & ex.Message)
        End Try
    End Sub
    '</snippet2>
End Module
'</snippet1>
