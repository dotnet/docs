Imports System.Collections
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Xml.Linq
Imports System.Numerics



Class Program

    Shared Sub Main()

        'Consumer.Main2()


        Console.Write("Press any key.")
        Console.ReadKey()
    End Sub





    Shared Sub TestDefaultRangePartitioner()



        Console.WriteLine("Operation completed.")
        Console.ReadKey()
    End Sub

    'dummy
    Shared Sub ProcessData(ByVal d As Double)
    End Sub

    Shared Sub ParallelLoopsWithPartitioner()

        '<snippet02>
        ' Static number of partitions requires indexable source.
        Dim nums = Enumerable.Range(0, 100000000).ToArray()

        ' Create a load-balancing partitioner. Or specify false For  Shared partitioning.
        Dim customPartitioner = Partitioner.Create(nums, True)

        ' The partitioner is the query's data source.
        Dim q = From x In customPartitioner.AsParallel()
                Select x * Math.PI

        q.ForAll(Sub(x) ProcessData(x))

        '</snippet02>

        Dim sw = Stopwatch.StartNew()

        ' Must be load balanced partitioner 
        ' For  this simple data source.
        '   Partitioner(Of Integer) p = Partitioner.Create(nums, True)

        Parallel.ForEach(customPartitioner, Sub(x)
                                                Dim d = CDbl(x) * Math.PI
                                            End Sub)

        Console.WriteLine("elapsed For  Parallel.For: 0}", sw.ElapsedMilliseconds)

        sw = Stopwatch.StartNew()
        customPartitioner = Partitioner.Create(nums, True)
        Dim q7 = From x In customPartitioner.AsParallel()
                 Select x ' *Math.PI

        q7.ForAll(Sub(x)

                      Dim d = CDbl(x) * Math.PI
                  End Sub)
        Console.WriteLine("elapsed For  PLINQ with load-balancing: 0}", sw.ElapsedMilliseconds)

        '  Console.WriteLine("Clearing memory cache")

        'For  i as Integer = 0 to arr.Length  - 1
        '    arr(i) = Math.PI

        sw = Stopwatch.StartNew()
        customPartitioner = Partitioner.Create(nums, False)
        Dim q2 = From x In customPartitioner.AsParallel()
                 Select x ' *Math.PI

        q2.ForAll(Sub(x)

                      Dim d = CDbl(x) * Math.PI
                  End Sub)

        Console.WriteLine("elapsed For  PLINQ without load-balancing: 0}", sw.ElapsedMilliseconds)

    End Sub

    'Shared Sub TestLoadBalancingCreateMethods()

    '    Dim source As ILookup(Of TKey, TElement) = Enumerable.Range(0, 10000).ToLookup(Sub(i) i.ToString())
    '    Dim partitioner2 = Partitioner.Create(source)

    '    '   Dim p0 = Partitioner.Create(
    '    Parallel.ForEach(partitioner2, Sub(item)

    '                                       Console.WriteLine(item.Key)
    '                                       For Each v In item

    '                                           Console.WriteLine("    0:##.###}", CDbl(v * 0.075213))
    '                                       Next
    '                                   End Sub)
    'End Sub
End Class




'Class PartTest2

'    Shared cts = New CancellationTokenSource()
'    Shared sb = New StringBuilder()
'    Shared Sub Main()

'        'Math.
'        Dim sourceArray As Integer() = Enumerable.Range(1, 12680).ToArray()
'        '  int partitionCount = 4

'        Task.Factory.StartNew(Sub()
'                                  If (Console.ReadKey().KeyChar = "c"c) Then
'                                      cts.Cancel()
'                                  End If
'                              End Sub)

'        Dim mp = New MyPartitioner(sourceArray, 0.5)

'        Dim p = New PartTest2()
'        Dim q = From item In mp.AsParallel()
'                Let result = p.FakeFibonacci(item)
'        Order By item
'                    Select New With {.Num = item, .Result = result, .MyThread = Thread.CurrentThread.ManagedThreadId}

'        Console.WriteLine("Beginning custom partitioning")

'        For Each v In q

'            Dim s = String.Format("Val=0}:Fib=1}:Thread=2} ", v.Num, v.Result, v.MyThread)
'            sb.AppendLine(s)
'            '  Console.WriteLine(s)
'        Next

'        'Thread.SpinWait(500000000)

'        'Dim q2 = From item In sourceArray.AsParallel()
'        '        let result = p.Fibonacci(item)
'        '        orderby item
'        '        Select new  Num = item, Result = result, MyThread = Thread.CurrentThread.ManagedThreadId }

'        'Console.WriteLine("Beginning default partitioning.")
'        'sb.AppendLine("Beginning default partitioning.")

'        'For Each (v In q2)
'        '
'        '       String s = String.Format("Val=0}:Fib=1}:Thread=2} ", v.Num, v.Result, v.MyThread)
'        '      sb.AppendLine(s)
'        '    '  Console.WriteLine(s)
'        '}

'        '   System.IO.File.WriteAllText(@"..\..\logfile1.txt", sb.ToString())
'        '  Console.WriteLine("Press any key")
'        '   Console.ReadKey()

'    End Sub


'    Function FakeFibonacci(ByVal i As Integer) As BigInteger

'        '  For  (int j = 0 j < i j++)
'        '  Thread.SpinWait(i * 1000)
'        Return 1
'    End Function

'    Function Fibonacci(ByVal x As Integer) As BigInteger

'        Dim loopCounter = 0
'        Dim fib1 As BigInteger = 0
'        Dim fib2 As BigInteger = 1
'        Dim tempTerm As BigInteger
'        Do While (loopCounter <= x)

'            If (loopCounter > 1) Then

'                tempTerm = fib1 + fib2
'                fib1 = fib2
'                fib2 = tempTerm
'            End If
'            loopCounter = loopCounter + 1

'        Loop


'        Return fib2
'    End Function
'End Class




Namespace myPrivateNamespace

    Partial Class Dummy

        ' used For  code snippet in conceptual overview topic

        '<snippet03>
        ' When loadBalance is false - uses Shared partitioning
        ' When loadBalance is True - uses load-balanced partitioning
        ' Public Shared OrderablePartitioner(Of TSource) Create(Of TSource)(source As IList(Of TSource), loadBalance As Boolean)
        ' Public Shared OrderablePartitioner(Of TSource) Create(Of TSource)(source As IList(Of TSource), loadBalance As Boolean)

        ' Always uses load-balanced partitioning
        ' Public Shared OrderablePartitioner(Of TSource) Create(Of TSource)(source As IEnumerator(Of TSource))
        '</snippet03>

    End Class
End Namespace



