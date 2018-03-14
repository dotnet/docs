'<snippet1>
'<snippet2>
' This is a throwaway snippet. However, do not delete it.
' It raises the snippet count so no real snippets are lost.
' Thank you.
'</snippet2>
'</snippet1>

'<snippet27>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module PerfCounterCatCreateExistMod

    '<snippet28>
    '<snippet4>
    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        '</snippet4>
        Dim counterName As String = ""
        '</snippet28>
        '<snippet6>
        Dim instanceName As String = ""
        '<snippet5>
        Dim machineName As String = ""
        '</snippet5>
        '</snippet6>
        '<snippet3>
        Dim categoryHelp As String = ""
        Dim counterHelp As String = ""
        '</snippet3>
        '<snippet7>
        '<snippet8>
        Dim objectExists As Boolean = False
        '</snippet8>
        Dim pcc As PerformanceCounterCategory
        '</snippet7>
        Dim createCategory As Boolean = False
        '<snippet9>
        '<Snippet10>

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            '</Snippet10>
            counterName = args(1)
            '</snippet9>
            '<Snippet11>
            instanceName = args(2)
            '<Snippet12>
            machineName = IIf(args(3) = ".", "", args(3))
            '</Snippet12>
            '</Snippet11>
            '<Snippet13>
            categoryHelp = args(4)
            counterHelp = args(5)
            '<Snippet14>
            '<Snippet15>
            '<Snippet16>
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        ' Verify that the category name is not blank.
        If categoryName.Length = 0 Then
            Console.WriteLine("Category name cannot be blank.")
            Return
        End If

        '</Snippet13>
        ' Check whether the specified category exists.
        '</Snippet16>
        If machineName.Length = 0 Then
            '<Snippet17>
            objectExists = _
                PerformanceCounterCategory.Exists(categoryName)

            '</Snippet17>
        Else
            ' Handle the exception that is thrown if the computer 
            ' cannot be found.
            Try
                objectExists = PerformanceCounterCategory.Exists( _
                    categoryName, machineName)
            Catch ex As Exception
                Console.WriteLine("Error checking for existence of " & _
                    "category ""{0}"" on computer ""{1}"":" & vbCrLf & _
                    ex.Message, categoryName, machineName)
                Return
            End Try
        End If

        '</Snippet15>
        ' Tell the user whether the specified category exists.
        Console.WriteLine("Category ""{0}"" " & _
            IIf(objectExists, "exists on ", "does not exist on ") & _
            IIf(machineName.Length > 0, _
                "computer ""{1}"".", "this computer."), _
            categoryName, machineName)
        '</Snippet14>

        ' If no counter name is given, the program cannot continue.
        If counterName.Length = 0 Then
            Return
        End If

        ' A category can only be created on the local computer.
        '<Snippet18>
        If Not objectExists Then
            '</Snippet18>
            If machineName.Length > 0 Then
                '<Snippet19>
                Return
                '</Snippet19>
            Else
                createCategory = True
            End If
            '<Snippet20>
            '<Snippet21>
        Else
            '</Snippet21>
            ' Check whether the specified counter exists.
            If machineName.Length = 0 Then
                objectExists = PerformanceCounterCategory.CounterExists( _
                    counterName, categoryName)
            Else
                objectExists = PerformanceCounterCategory.CounterExists( _
                    counterName, categoryName, machineName)
            End If

            ' Tell the user whether the counter exists.
            Console.WriteLine("Counter ""{0}"" " & _
                IIf(objectExists, "exists", "does not exist") & _
                " in category ""{1}"" on " & _
                IIf(machineName.Length > 0, _
                    "computer ""{2}"".", "this computer."), _
                counterName, categoryName, machineName)
            '</Snippet20>

            ' If the counter does not exist, consider creating it.
            If Not objectExists Then

                ' If this is a remote computer, 
                ' exit because the category cannot be created.
                If machineName.Length > 0 Then
                    Return
                Else
                    ' Ask whether the user wants to recreate the category.
                    Console.Write("Do you want to delete and recreate " & _
                        "category ""{0}"" with your new counter? [Y/N]: ", _
                        categoryName)
                    Dim userReply As String = Console.ReadLine()

                    ' If yes, delete the category so it can be recreated later.
                    If userReply.Trim.ToUpper.Chars(0) = "Y" Then
                        '<Snippet22>
                        PerformanceCounterCategory.Delete(categoryName)
                        '</Snippet22>
                        createCategory = True
                    Else
                        Return
                    End If
                End If
            End If
        End If

        ' Create the category if it was deleted or it never existed.
        If createCategory Then
            '<Snippet23>
            pcc = PerformanceCounterCategory.Create( _
                categoryName, categoryHelp, counterName, counterHelp)

            Console.WriteLine( _
                "Category ""{0}"" with counter ""{1}"" created.", _
                pcc.CategoryName, counterName)
            '</Snippet23>

        ElseIf instanceName.Length > 0 Then

            '<Snippet24>
            ' If an instance name was given, check whether it exists.
            If machineName.Length = 0 Then
                objectExists = PerformanceCounterCategory.InstanceExists( _
                    instanceName, categoryName)
            Else
                objectExists = PerformanceCounterCategory.InstanceExists( _
                    instanceName, categoryName, machineName)
            End If

            ' Tell the user whether the instance exists.
            Console.WriteLine("Instance ""{0}"" " & _
                IIf(objectExists, "exists", "does not exist") & _
                " in category ""{1}"" on " & _
                IIf(machineName.Length > 0, _
                    "computer ""{2}"".", "this computer."), _
                instanceName, categoryName, machineName)
            '<Snippet25>
        End If
        '<Snippet26>
    End Sub
    '</Snippet26>
    '</Snippet25>
    '</Snippet24>
End Module
'</snippet27>
