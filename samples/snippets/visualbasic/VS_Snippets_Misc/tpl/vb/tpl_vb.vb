
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks




Class Program

    Shared Sub Main(ByVal args() As String)

        '  WaitOnTasks()
        ' HandleExceptions()


        Console.ReadKey()
    End Sub



End Class



Class IntroCancellation

    Shared Function GetFileData() As Byte()
        Dim b(10) As Byte
        Return b
    End Function
    Shared Function Analyze(ByVal input As Byte()) As Double()
        Dim d(10) As Double
        Return d
    End Function

    Shared Function Summarize(ByVal d As Double()) As String

        Return "looks good"
    End Function

    Shared Sub MethodA()

    End Sub
    Shared Sub MethodB()

    End Sub
    Shared Sub MethodC()

    End Sub
    Shared Sub DoSomeWork(ByVal i As Integer)
    End Sub


    Shared Sub Process(ByVal i As Integer)

    End Sub

    Shared Sub DoSomeWork()

    End Sub
    Shared Sub DoSomeOtherWork()

    End Sub

    Shared Function DoComputation1() As Object
        DoComputation1 = New Object()
    End Function

    Shared Function DoComputation2() As Double
        Return 1.0
    End Function

    Shared Function DoComputation3() As Double
        Return 1.0
    End Function


    Shared sourceCollection() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}

    Shared Sub Test()

        Dim startIndex = 0
        Dim endIndex = 10

        '<snippet18>
        Parallel.For(startIndex, endIndex, Sub(currentIndex) DoSomeWork(currentIndex))

        '</snippet18>

        '<snippet19>
        Parallel.Invoke(
            Sub() MethodA(),
            Sub() MethodB(),
            Sub() MethodC())
        '</snippet19>

        '<snippet20>
        ' Sequential version        
        For Each item In sourceCollection
            Process(item)
        Next

        ' Parallel equivalent
        Parallel.ForEach(sourceCollection, Sub(item) Process(item))
        '</snippet20>

        '<snippet21>
        Parallel.Invoke(Sub() DoSomeWork(), Sub() DoSomeOtherWork())
        '</snippet21>

        '<snippet22>
        Dim taskArray(3) As Task(Of Double)

        taskArray(0) = Task(Of Double).Factory.StartNew(Function() DoComputation1())
        taskArray(1) = Task(Of Double).Factory.StartNew(Function() DoComputation2())
        taskArray(2) = Task(Of Double).Factory.StartNew(Function() DoComputation3())


        Dim results(taskArray.Length - 1) As Double
        For i As Integer = 0 To taskArray.Length - 1
            results(i) = taskArray(i).Result
        Next
        '</snippet22>

        '<snippet23>
        Dim getData = New Task(Of Byte())(Function() GetFileData())
        Dim analyzeData As Task(Of Double()) = getData.ContinueWith(Function(x) Analyze(x.Result))
        Dim reportData As Task(Of String) = analyzeData.ContinueWith(Function(y) Summarize(y.Result))

        getData.Start()

        System.IO.File.WriteAllText("C:\reportFolder\report.txt", reportData.Result)
        '</snippet23>


        '<snippet24>

        Dim myTasks(3) As Task

        Task.Factory.StartNew(Sub() MethodA())
        Task.Factory.StartNew(Sub() MethodB())
        Task.Factory.StartNew(Sub() MethodC())


        Task.WaitAll(myTasks)

    End Sub
    '</snippet24>

End Class



