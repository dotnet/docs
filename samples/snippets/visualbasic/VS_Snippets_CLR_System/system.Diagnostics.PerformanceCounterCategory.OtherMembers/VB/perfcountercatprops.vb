'<snippet7>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module PerfCounterCatPropsMod

    '<snippet8>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim machineName As String = ""
        Dim pcc As New PerformanceCounterCategory

        ' Prompt for fields and set the corresponding properties.
        While categoryName.Length = 0
            Console.Write("Please enter a non-blank category name: ")
            categoryName = Console.ReadLine().Trim
            If categoryName.Length > 0 Then
                pcc.CategoryName = categoryName
            End If
        End While
        While machineName.Length = 0
            Console.Write( _
                "Enter a non-blank computer name ['.' for local]: ")
            machineName = Console.ReadLine().Trim
            If machineName.Length > 0 Then
                pcc.MachineName = machineName
            End If
        End While

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
    '</snippet8>
End Module
'</snippet7>
