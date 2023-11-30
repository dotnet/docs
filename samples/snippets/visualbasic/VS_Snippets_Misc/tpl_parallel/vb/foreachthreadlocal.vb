'<snippet04>
' How to: Write a Parallel.ForEach Loop That Has Thread-Local Variables

Imports System.Threading
Imports System.Threading.Tasks

Module ForEachThreadLocal
    Sub Main()

        Dim nums() As Integer = Enumerable.Range(0, 1000000).ToArray()
        Dim total As Long = 0

        ' First type parameter is the type of the source elements
        ' Second type parameter is the type of the thread-local variable (partition subtotal)
        Parallel.ForEach(Of Integer, Long)(nums, Function() 0,
                                           Function(elem, loopState, subtotal)
                                               subtotal += elem
                                               Return subtotal
                                           End Function,
                                            Sub(finalResult)
                                                Interlocked.Add(total, finalResult)
                                            End Sub)

        Console.WriteLine("The result of Parallel.ForEach is {0:N0}", total)
    End Sub
End Module
' The example displays the following output:
'       The result of Parallel.ForEach is 499,999,500,000
'</snippet04>
