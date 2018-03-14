Imports System.Threading
Imports System.Threading.Tasks
Imports System.Linq
Imports System.IO
Imports System.Windows.Forms
Module Module1

    Dim WithEvents Button1 As Button
    Dim WithEvents Button2 As Button
    Sub Main()
        '<snippet01>
        Dim mres = New ManualResetEventSlim()
        Enumerable.Range(0, Environment.ProcessorCount * 100) _
        .AsParallel() _
        .ForAll(Sub(j)

                    If j = Environment.ProcessorCount Then
                        Console.WriteLine("Set on {0} with value of {1}",
                                          Thread.CurrentThread.ManagedThreadId, j)
                        mres.Set()
                    Else
                        Console.WriteLine("Waiting on {0} with value of {1}",
                                          Thread.CurrentThread.ManagedThreadId, j)
                        mres.Wait()
                    End If
                End Sub) ' deadlocks
        '</snippet01>


    End Sub



    '<snippet02>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim iterations As Integer = 20
        Parallel.For(0, iterations, Sub(x)
                                        Button1.Invoke(Sub()
                                                           DisplayProgress(x)
                                                       End Sub)
                                    End Sub)
    End Sub
    '</snippet02>

    Sub DisplayProgress(ByVal i As Integer)

    End Sub

    '<snippet03>
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim iterations As Integer = 20
        Task.Factory.StartNew(Sub() Parallel.For(0, iterations, Sub(x)
                                                                    Button1.Invoke(Sub()
                                                                                       DisplayProgress(x)
                                                                                   End Sub)
                                                                End Sub))
    End Sub
    '</snippet03>

    Sub Urg()

        Dim filepath As String = "C\"
        '<snippet04>
        Dim fs As FileStream = File.OpenWrite(filepath)
        Dim bytes() As Byte
        ReDim bytes(1000000)
        ' ...init byte array
        Parallel.For(0, bytes.Length, Sub(n) fs.WriteByte(bytes(n)))
        '</snippet04>
    End Sub

End Module
