' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet6>
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim task1 = Task(Of Integer).Run(Function()
                                             Console.WriteLine("Executing task {0}",
                                                               Task.CurrentId)
                                             Return 54
                                         End Function)
        Dim continuation = task1.ContinueWith(Sub(antecedent)
                                                  Console.WriteLine("Executing continuation task {0}",
                                                                    Task.CurrentId)
                                                  Console.WriteLine("Value from antecedent: {0}",
                                                                    antecedent.Result)
                                                  Throw New InvalidOperationException()
                                              End Sub)

        Try
            task1.Wait()
            continuation.Wait()
        Catch ae As AggregateException
            For Each ex In ae.InnerExceptions
                Console.WriteLine(ex.Message)
            Next
        End Try
    End Sub
End Module
' The example displays the following output:
'       Executing task 1
'       Executing continuation task 2
'       Value from antecedent: 54
'       Operation is not valid due to the current state of the object.
' </Snippet6>
