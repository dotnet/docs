'<snippet01>
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Module RangePartitionerDemo

    Sub Main()
        Dim sw As Stopwatch = Nothing

        Dim sum As Long = 0
        Dim SUMTOP As Long = 10000000

        ' Try sequential for
        sw = Stopwatch.StartNew()
        For i As Long = 0 To SUMTOP - 1
            sum += i
        Next
        sw.Stop()
        Console.WriteLine("sequential for result = {0}, time = {1} ms", sum, sw.ElapsedMilliseconds)

        ' Try parallel for with locals
        sum = 0
        sw = Stopwatch.StartNew()
        Parallel.For(0L, SUMTOP, Function() 0L, Function(item, state, prevLocal) prevLocal + item, Function(local) Interlocked.Add(sum, local))
        sw.Stop()
        Console.WriteLine("parallel for w/locals result = {0}, time = {1} ms", sum, sw.ElapsedMilliseconds)

        ' Try range partitioner
        sum = 0
        sw = Stopwatch.StartNew()
        Parallel.ForEach(Partitioner.Create(0L, SUMTOP),
                         Sub(range)
                             Dim local As Long = 0
                             For i As Long = range.Item1 To range.Item2 - 1
                                 local += i
                             Next
                             Interlocked.Add(sum, local)
                         End Sub)
        sw.Stop()
        Console.WriteLine("range partitioner result = {0}, time = {1} ms", sum, sw.ElapsedMilliseconds)
    End Sub

End Module
'</snippet01>