'<snippet05>
'How to: Write a Parallel.For Loop That Has Thread-Local Variables

Imports System.Threading
Imports System.Threading.Tasks

Module ForWithThreadLocal

    Sub Main()
        Dim nums As Integer() = Enumerable.Range(0, 1000000).ToArray()
        Dim total As Long = 0

        ' Use type parameter to make subtotal a Long type. Function will overflow otherwise.
        Parallel.For(Of Long)(0, nums.Length, Function() 0, Function(j, [loop], subtotal)
                                                                subtotal += nums(j)
                                                                Return subtotal
                                                            End Function, Function(subtotal) Interlocked.Add(total, subtotal))

        Console.WriteLine("The total is {0:N0}", total)
        Console.WriteLine("Press any key to exit")
        Console.ReadKey()
    End Sub

End Module
'</snippet05>
