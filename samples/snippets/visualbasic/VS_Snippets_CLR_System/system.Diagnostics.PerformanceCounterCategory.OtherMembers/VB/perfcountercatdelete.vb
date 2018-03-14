'<snippet5>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module PerfCounterCatDeleteMod

    '<snippet6>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""

        ' Copy the supplied argument into the local variable.
        Try
            categoryName = args(0)
        Catch ex As Exception
            Console.WriteLine("Missing argument identifying category to be deleted.")
        End Try

        ' Delete the specified category.
        Try
            If (PerformanceCounterCategory.Exists(categoryName)) Then
                PerformanceCounterCategory.Delete(categoryName)
                Console.WriteLine( _
                    "Category ""{0}"" deleted from this computer.", categoryName)
            Else
                Console.WriteLine("Category name not found")
            End If

        Catch ex As Exception
            Console.WriteLine("Unable to delete " & _
                "category ""{0}"" from this computer:" & vbCrLf & _
                ex.Message, categoryName)
        End Try
    End Sub
    '</snippet6>
End Module
'</snippet5>
