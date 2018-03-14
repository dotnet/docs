'<snippet1>
Imports System
Imports System.Diagnostics

Module PerfCounterCatGetCatMod

    '<snippet2>
    Sub Main(ByVal args() As String)
        Dim machineName As String = ""
        Dim categories() As PerformanceCounterCategory

        ' Copy the machine name argument into the local variable.
        Try
            machineName = IIf(args(0) = ".", "", args(0))
        Catch ex As Exception
        End Try

        ' Generate a list of categories registered on the specified computer.
        Try
            If machineName.Length > 0 Then
                categories = _
                    PerformanceCounterCategory.GetCategories(machineName)
            Else
                categories = PerformanceCounterCategory.GetCategories()
            End If
        Catch ex As Exception
            Console.WriteLine("Unable to get categories on " & _
                IIf(machineName.Length > 0, "computer ""{0}"":", _
                "this computer:"), machineName)
            Console.WriteLine(ex.Message)
            Return
        End Try

        Console.WriteLine("These categories are registered on " & _
            IIf(machineName.Length > 0, _
                "computer ""{0}"":", "this computer:"), machineName)

        ' Create and sort an array of category names.
        Dim categoryNames(categories.Length - 1) As String
        Dim objX As Integer
        For objX = 0 To categories.Length - 1
            Console.WriteLine("{0}, {1}", objX, categories(objX).CategoryName)
            categoryNames(objX) = categories(objX).CategoryName
        Next objX
        Array.Sort(categoryNames)

        For objX = 0 To categories.Length - 1
            Console.WriteLine("{0,4} - {1}", objX + 1, categoryNames(objX))
        Next objX
    End Sub
    '</snippet2>
End Module
'</snippet1>
