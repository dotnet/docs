'<snippet04>
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Module ObjectPoolExample


    Public Class ObjectPool(Of T)
        Private _objects As ConcurrentBag(Of T)
        Private _objectGenerator As Func(Of T)

        Public Sub New(ByVal objectGenerator As Func(Of T))
            If objectGenerator Is Nothing Then Throw New ArgumentNullException("objectGenerator")
            _objects = New ConcurrentBag(Of T)()
            _objectGenerator = objectGenerator
        End Sub

        Public Function GetObject() As T
            Dim item As T
            If _objects.TryTake(item) Then Return item
            Return _objectGenerator()
        End Function

        Public Sub PutObject(ByVal item As T)
            _objects.Add(item)
        End Sub
    End Class


    Sub Main()

        Dim cts As CancellationTokenSource = New CancellationTokenSource()

        ' Create an opportunity for the user to cancel.
        Task.Run(Sub()
                     If Console.ReadKey().KeyChar = "c"c Or Console.ReadKey().KeyChar = "C"c Then
                         cts.Cancel()
                     End If
                 End Sub)
        Dim pool As ObjectPool(Of TestClass) = New ObjectPool(Of TestClass)(Function() New TestClass())

        ' Create a high demand for TestClass objects.
        Parallel.For(0, 1000000, Sub(i, loopState)

                                     Dim mc As TestClass = pool.GetObject()
                                     Console.CursorLeft = 0
                                     ' This is the bottleneck in our application. All threads in this loop
                                     ' must serialize their access to the static Console class.
                                     Console.WriteLine("{0:####.####}", mc.GetValue(i))

                                     pool.PutObject(mc)
                                     If cts.Token.IsCancellationRequested Then
                                         loopState.Stop()

                                     End If
                                 End Sub)

        Console.WriteLine("Press the Enter key to exit.")
        Console.ReadLine()
        cts.Dispose()
    End Sub

    ' A toy class that requires some resources to create.
    ' You can experiment here to measure the performance of the
    ' object pool vs. ordinary instantiation.
    Class TestClass

        Public Nums() As Integer

        Public Function GetValue(ByVal i As Long) As Double
            Return Math.Sqrt(Nums(i))
        End Function

        Public Sub New()

            Nums = New Integer(10000000) {}
            '   ReDim Nums(1000000)
            Dim rand As Random = New Random()
            For i As Integer = 0 To Nums.Length - 1
                Nums(i) = rand.Next()
            Next
        End Sub
    End Class

End Module
'</snippet04>

