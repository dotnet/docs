
'<snippet01>
Imports System.Threading.Tasks
Imports System.Collections.Concurrent

Module PartitionDemo

    Sub Main()
        ' Source must be array or IList.
        Dim source = Enumerable.Range(0, 100000).ToArray()

        ' Partition the entire source array. 
        ' Let the partitioner size the ranges.
        Dim rangePartitioner = Partitioner.Create(0, source.Length)

        Dim results(source.Length - 1) As Double

        ' Loop over the partitions in parallel. The Sub is invoked
        ' once per partition.
        Parallel.ForEach(rangePartitioner, Sub(range, loopState)

                                               ' Loop over each range element without a delegate invocation.
                                               For i As Integer = range.Item1 To range.Item2 - 1
                                                   results(i) = source(i) * Math.PI
                                               Next
                                           End Sub)
        Console.WriteLine("Operation complete. Print results? y/n")
        Dim input As Char = Console.ReadKey().KeyChar
        If input = "y"c Or input = "Y"c Then
            For Each d As Double In results
                Console.Write("{0} ", d)
            Next
        End If

    End Sub
End Module
'</snippet01>
