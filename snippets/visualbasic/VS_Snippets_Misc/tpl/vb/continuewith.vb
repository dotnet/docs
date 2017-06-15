'<snippet06>
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Module ContinueWith

    Sub Main()
        DoSimpleContinuation()

        Console.WriteLine("Press any key to exit")
        Console.ReadKey()
    End Sub


    Sub DoSimpleContinuation()
        Dim path As String = "C:\users\public\TPLTestFolder\"
        Try
            Dim firstTask = New Task(Sub() CopyDataIntoTempFolder(path))
            Dim secondTask = firstTask.ContinueWith(Sub(t) CreateSummaryFile(path))
            firstTask.Start()
        Catch e As AggregateException
            Console.WriteLine(e.Message)
        End Try
    End Sub

    ' A toy function to simulate a workload
    Sub CopyDataIntoTempFolder(ByVal path__1 As String)
        System.IO.Directory.CreateDirectory(path__1)
        Dim rand As New Random()
        For x As Integer = 0 To 49
            Dim bytes As Byte() = New Byte(999) {}
            rand.NextBytes(bytes)
            Dim filename As String = Path.GetRandomFileName()
            Dim filepath As String = Path.Combine(path__1, filename)
            System.IO.File.WriteAllBytes(filepath, bytes)
        Next
    End Sub

    Sub CreateSummaryFile(ByVal path__1 As String)
        Dim files As String() = System.IO.Directory.GetFiles(path__1)
        Parallel.ForEach(files, Sub(file)
                                    Thread.SpinWait(5000)
                                End Sub)

        System.IO.File.WriteAllText(Path.Combine(path__1, "__SummaryFile.txt"), "did my work")
        Console.WriteLine("Done with task2")
    End Sub
   
    Sub DoSimpleContinuationWithState()
        Dim nums As Integer() = {19, 17, 21, 4, 13, 8, _
        12, 7, 3, 5}
        Dim f0 = New Task(Of Double)(Function() nums.Average())
        Dim f1 = f0.ContinueWith(Function(t) GetStandardDeviation(nums, t.Result))

        f0.Start()
        Console.WriteLine("the standard deviation is {0}", f1)
    End Sub

    Function GetStandardDeviation(ByVal values As Integer(), ByVal mean As Double) As Double
        Dim d As Double = 0.0R
        For Each n In values
            d += Math.Pow(mean - n, 2)
        Next
        Return Math.Sqrt(d / (values.Length - 1))
    End Function
End Module
'</snippet06>
