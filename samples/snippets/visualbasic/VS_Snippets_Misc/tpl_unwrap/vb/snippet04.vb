'<snippet04>
'How to: Unwrap a Task
Imports System.Threading
Imports System.Threading.Tasks
Module UnwrapATask2

    Sub Main()
        ' An arbitrary threshold value.
        Dim threshold As Byte = &H40

        ' myData is a Task(Of Byte())

        Dim myData As Task(Of Byte()) = Task.Factory.StartNew(Function()
                                                                  Return GetData()
                                                              End Function)
        ' We want to return a task so that we can
        ' continue from it later in the program.
        ' Without Unwrap: stepTwo is a Task(Of Task(Of Byte))
        ' With Unwrap: stepTwo is a Task(Of Byte)

        Dim stepTwo = myData.ContinueWith(Function(antecedent)
                                              Return Task.Factory.StartNew(Function()
                                                                               Return Compute(antecedent.Result)
                                                                           End Function)
                                          End Function).Unwrap()

        Dim lastStep = stepTwo.ContinueWith(Function(antecedent)
                                                Console.WriteLine("Result = {0}", antecedent.Result)
                                                If antecedent.Result >= threshold Then
                                                    Return Task.Factory.StartNew(Sub()
                                                                                     Console.WriteLine("Program complete. Final = &H{1:x} threshold = &H{1:x}",
                                                                                                       stepTwo.Result, threshold)
                                                                                 End Sub)
                                                Else
                                                    Return DoSomeOtherAsynchronousWork(stepTwo.Result, threshold)
                                                End If
                                            End Function)
        Try
            lastStep.Wait()
        Catch ae As AggregateException
            For Each ex As Exception In ae.InnerExceptions
                Console.WriteLine(ex.Message & ex.StackTrace & ex.GetBaseException.ToString())
            Next
        End Try

        Console.WriteLine("Press any key")
        Console.ReadKey()
    End Sub

#Region "Dummy_Methods"
    Function GetData() As Byte()
        Dim rand As Random = New Random()
        Dim bytes(64) As Byte
        rand.NextBytes(bytes)
        Return bytes
    End Function

    Function DoSomeOtherAsynchronousWork(ByVal i As Integer, ByVal b2 As Byte) As Task
        Return Task.Factory.StartNew(Sub()
                                         Thread.SpinWait(500000)
                                         Console.WriteLine("Doing more work. Value was <= threshold.")
                                     End Sub)
    End Function

    Function Compute(ByVal d As Byte()) As Byte
        Dim final As Byte = 0
        For Each item As Byte In d
            final = final Xor item
            Console.WriteLine("{0:x}", final)
        Next
        Console.WriteLine("Done computing")
        Return final
    End Function
#End Region
End Module
'</snippet04>

