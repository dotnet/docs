'<snippet5>
Imports System
Imports System.Diagnostics

Module PerfCounterCatGetInstMod

    '<snippet6>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim machineName As String = ""
        Dim pcc As PerformanceCounterCategory
        Dim instances() As String

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            machineName = IIf(args(1) = ".", "", args(1))
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

            ' Get the instances associated with this category.
            instances = pcc.GetInstanceNames()

        Catch ex As Exception
            Console.WriteLine("Unable to get instance information for " & _
                 "category ""{0}"" on " & IIf(machineName.Length > 0, _
                 "computer ""{1}"":", "this computer:"), _
                 categoryName, machineName)
            Console.WriteLine(ex.Message)
            Return
        End Try

        'If an empty array is returned, the category has a single instance.
        If instances.Length = 0 Then
            Console.WriteLine( _
                "Category ""{0}"" on " & IIf(machineName.Length > 0, _
                "computer ""{1}""", "this computer") & _
                " is single-instance.", pcc.CategoryName, pcc.MachineName)
        Else
            ' Otherwise, display the instances.
            Console.WriteLine( _
                "These instances exist in category ""{0}"" on " & _
                IIf(machineName.Length > 0, _
                    "computer ""{1}"".", "this computer:"), _
                pcc.CategoryName, pcc.MachineName)

            Array.Sort(instances)
            Dim objX As Integer
            For objX = 0 To instances.Length - 1
                Console.WriteLine("{0,4} - {1}", objX + 1, instances(objX))
            Next objX
        End If
    End Sub
    '</snippet6>
End Module
'</snippet5>
