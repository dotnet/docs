Imports System.Threading

Module Module1

    Sub Main()

    End Sub

    Function Compute(ByVal i As Integer) As IEnumerable(Of Integer)
        Dim Bogus(42) As Integer
        Return Bogus
    End Function
    Private Sub Test3()

        '<snippet11>
        'Initializing a value with a big computation, computed in parallel
        Dim _data As Lazy(Of Integer) = New Lazy(Of Integer)(Function()
                                                                 Dim result =
                                                                     ParallelEnumerable.Range(0, 1000).
                                                                     Aggregate(Function(x, y)
                                                                                   Return x + y
                                                                               End Function)
                                                                 Return result
                                                             End Function)

        '  ...
        ' use the data
        If (_data.Value > 100) Then

            Console.WriteLine("Good data")
        End If
        '</snippet11>
    End Sub

    Sub Test(ByVal i As Integer)

        '<snippet13>
        'Initializing a value per thread, per instance
        Dim _scratchArrays =
            New ThreadLocal(Of Integer()())(Function() InitializeArrays())

        ' use the thread-local data
        Dim tempArr As Integer() = _scratchArrays.Value(i)
        ' ...
    End Sub

    Function InitializeArrays() As Integer()()
        Dim result(10)() As Integer
        ' Initialize the arrays on the current thread.
        ' ... 

        Return result
    End Function
    '</snippet13>
End Module
