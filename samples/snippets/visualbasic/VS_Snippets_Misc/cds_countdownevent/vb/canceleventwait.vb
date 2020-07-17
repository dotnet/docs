'<snippet02>
Option Strict On
Option Explicit On

Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading
Imports System.Threading.Tasks

Module CancelEventWait

    Class Data
        Public Num As Integer
        Public Sub New(ByVal i As Integer)
            Num = i
        End Sub
        Public Sub New()

        End Sub
    End Class

    Class DataWithToken
        Public Token As CancellationToken
        Public _data As Data
        Public Sub New(ByVal d As Data, ByVal ct As CancellationToken)
            Me._data = d
            Me.Token = ct
        End Sub
    End Class

    Class Program
        Shared Function GetData() As IEnumerable(Of Data)
            Dim nums = New List(Of Data)
            For i As Integer = 1 To 5
                nums.Add(New Data(i))
            Next
            Return nums
        End Function

        Shared Sub ProcessData(ByVal obj As Object)
            Dim dataItem As DataWithToken = CType(obj, DataWithToken)
            If dataItem.Token.IsCancellationRequested = True Then
                Console.WriteLine("Canceled before starting {0}", dataItem._data.Num)
                Exit Sub
            End If

            ' Increase this value to slow down the program.
            For i As Integer = 0 To 10000

                If dataItem.Token.IsCancellationRequested = True Then
                    Console.WriteLine("Cancelling while executing {0}", dataItem._data.Num)
                    Exit Sub
                End If
                Thread.SpinWait(100000)
            Next
            Console.WriteLine("Processed {0}", dataItem._data.Num)


        End Sub

        Shared Sub Main()
            DoEventWithCancel()
            Console.WriteLine("Press the enter key to exit.")
            Console.ReadLine()
        End Sub

        Shared Sub DoEventWithCancel()
            Dim source As IEnumerable(Of Data) = GetData()
            Dim cts As CancellationTokenSource = New CancellationTokenSource()

            ' Enable cancellation request from a simple UI thread.
            Task.Factory.StartNew(Sub()
                                      If Console.ReadKey().KeyChar = "c"c Then
                                          cts.Cancel()
                                      End If
                                  End Sub)

            ' Must have a count of at least 1 or else it is signaled.
            Dim e As CountdownEvent = New CountdownEvent(1)

            For Each element As Data In source
                Dim item As DataWithToken = New DataWithToken(element, cts.Token)

                ' Dynamically increment signal count.
                e.AddCount()

                ThreadPool.QueueUserWorkItem(Sub(state)
                                                 ProcessData(state)
                                                 If cts.Token.IsCancellationRequested = False Then
                                                     e.Signal()
                                                 End If
                                             End Sub,
                                            item)
            Next
            ' Decrement the signal count by the one we added
            ' in the constructor.
            e.Signal()
            ' The first element could be run on this thread.
            ' ProcessData(source(0))

            ' Join with work or catch cancellation exception
            Try
                e.Wait(cts.Token)
            Catch ex As OperationCanceledException
                If ex.CancellationToken = cts.Token Then
                    Console.WriteLine("User canceled.")
                Else : Throw ' we don't know who canceled us.

                End If
            Finally
                e.Dispose()
                cts.Dispose()
            End Try
        End Sub
    End Class
End Module
'</snippet02>
