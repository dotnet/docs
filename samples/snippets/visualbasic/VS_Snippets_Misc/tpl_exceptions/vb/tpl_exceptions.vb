Option Strict On
Option Explicit On
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Concurrent

Module Module1

    Class MyCustomException
        Inherits Exception
        Public Sub New(ByVal s As String)
            MyBase.New(s)
        End Sub


    End Class
    Class Program

        Public Shared Sub Main()
            '  ThrowDemo()
            DetachedTasks()
            Console.ReadKey()
        End Sub
        Shared Sub ThrowDemo()
            '<snippet1>
            Dim task1 = Task.Factory.StartNew(Sub()
                                                  Throw New MyCustomException("I'm bad, but not too bad!")
                                              End Sub)

            Try
                task1.Wait()
            Catch ae As AggregateException
                ' Assume we know what's going on with this particular exception.
                ' Rethrow anything else. AggregateException.Handle provides
                ' another way to express this. See later example.
                '<snippet5>
                For Each ex In ae.InnerExceptions
                    If TypeOf (ex) Is MyCustomException Then
                        Console.WriteLine(ex.Message)
                    Else
                        Throw
                    End If
                Next
                '</snippet5>

            End Try
            '</snippet1>

        End Sub

        Shared Sub Children()
            '<snippet2>
            ' task1 will throw an AE inside an AE inside an AE
            Dim task1 = Task.Factory.StartNew(Sub()
                                                  Dim child1 = Task.Factory.StartNew(Sub()
                                                                                         Dim child2 = Task.Factory.StartNew(Sub()
                                                                                                                                Throw New MyCustomException("Attached child2 faulted.")
                                                                                                                            End Sub,
                                                                                                                            TaskCreationOptions.AttachedToParent)
                                                                                     End Sub,
                                                                                     TaskCreationOptions.AttachedToParent)
                                                  ' Uncomment this line to see the exception rethrown.
                                                  ' throw new MyCustomException("Attached child1 faulted.")
                                              End Sub)
            Try
                task1.Wait()
            Catch ae As AggregateException
                For Each ex In ae.Flatten().InnerExceptions
                    If TypeOf (ex) Is MyCustomException Then
                        Console.WriteLine(ex.Message)
                    Else
                        Throw
                    End If
                Next
                'or like this:
                '  ae.Flatten().Handle(Function(e)
                '                               Return TypeOf (e) Is MyCustomException
                '                   End Function)
            End Try
            '</snippet2>
            Console.ReadKey()
        End Sub

        Shared Sub DetachedTasks()
            '<snippet3>
            Dim task1 = Task.Factory.StartNew(Sub()
                                                  Dim nestedTask1 = Task.Factory.StartNew(Sub()
                                                                                              Throw New MyCustomException("Nested task faulted.")
                                                                                          End Sub)
                                                  ' Here the exception will be escalated back to joining thread.
                                                  ' We could use try/catch here to prevent that.
                                                  nestedTask1.Wait()
                                              End Sub)
            Try
                task1.Wait()
            Catch ae As AggregateException
                For Each ex In ae.Flatten().InnerExceptions
                    If TypeOf (ex) Is MyCustomException Then
                        ' Recover from the exception. Here we just
                        ' print the message for demonstration purposes.
                        Console.WriteLine(ex.Message)
                    End If
                Next
            End Try
            '</snippet3>
            Console.ReadKey()
        End Sub

        Shared Sub CancelDemo()
            '<snippet4>
            Dim someCondition As Boolean = True
            Dim tokenSource = New CancellationTokenSource()
            Dim token = tokenSource.Token

            Dim task1 = Task.Factory.StartNew(Sub()
                                                  Dim ct As CancellationToken = token
                                                  While someCondition = True
                                                      ' Do some work...
                                                      Thread.SpinWait(500000)
                                                      ct.ThrowIfCancellationRequested()
                                                  End While
                                              End Sub,
                                              token)
            '</snippet4>
            tokenSource.Dispose()
        End Sub

        Shared Sub Handle(ByVal ae As AggregateException)
            '<snippet6>
            ae.Handle(Function(ex)
                          Return TypeOf (ex) Is MyCustomException
                      End Function)
            '</snippet6>
        End Sub

        Shared Sub ExceptionProperty()
            '<snippet7>
            Dim task1 = Task.Factory.StartNew(Sub()
                                                  Throw New MyCustomException("task1 faulted.")
                                              End Sub).ContinueWith(Sub(t)
                                                                        Console.WriteLine("I have observed a {0}", _
                                                                                          t.Exception.InnerException.GetType().Name)
                                                                    End Sub,
                                                                    TaskContinuationOptions.OnlyOnFaulted)
            '</snippet7>
        End Sub

    End Class

End Module

