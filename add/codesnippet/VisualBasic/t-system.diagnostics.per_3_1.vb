Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module PerfCounterCatCreateExistMod

    Sub Main(ByVal args() As String)
        Dim categoryName As String = ""
        Dim counterName As String = ""
        Dim instanceName As String = ""
        Dim machineName As String = ""
        Dim categoryHelp As String = ""
        Dim counterHelp As String = ""
        Dim objectExists As Boolean = False
        Dim pcc As PerformanceCounterCategory
        Dim createCategory As Boolean = False

        ' Copy the supplied arguments into the local variables.
        Try
            categoryName = args(0)
            counterName = args(1)
            instanceName = args(2)
            machineName = IIf(args(3) = ".", "", args(3))
            categoryHelp = args(4)
            counterHelp = args(5)
        Catch ex As Exception
            ' Ignore the exception from non-supplied arguments.
        End Try

        ' Verify that the category name is not blank.
        If categoryName.Length = 0 Then
            Console.WriteLine("Category name cannot be blank.")
            Return
        End If

        ' Check whether the specified category exists.
        If machineName.Length = 0 Then
            objectExists = _
                PerformanceCounterCategory.Exists(categoryName)

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

        ' Tell the user whether the specified category exists.
        Console.WriteLine("Category ""{0}"" " & _
            IIf(objectExists, "exists on ", "does not exist on ") & _
            IIf(machineName.Length > 0, _
                "computer ""{1}"".", "this computer."), _
            categoryName, machineName)

        ' If no counter name is given, the program cannot continue.
        If counterName.Length = 0 Then
            Return
        End If

        ' A category can only be created on the local computer.
        If Not objectExists Then
            If machineName.Length > 0 Then
                Return
            Else
                createCategory = True
            End If
        Else
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
                        PerformanceCounterCategory.Delete(categoryName)
                        createCategory = True
                    Else
                        Return
                    End If
                End If
            End If
        End If

        ' Create the category if it was deleted or it never existed.
        If createCategory Then
            pcc = PerformanceCounterCategory.Create( _
                categoryName, categoryHelp, counterName, counterHelp)

            Console.WriteLine( _
                "Category ""{0}"" with counter ""{1}"" created.", _
                pcc.CategoryName, counterName)

        ElseIf instanceName.Length > 0 Then

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
        End If
    End Sub
End Module