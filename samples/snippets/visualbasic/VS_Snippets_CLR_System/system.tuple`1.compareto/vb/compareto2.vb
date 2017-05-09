' <Snippet2>
Imports System.Collections.Generic

Public Class DescendingComparer(Of T) : Implements IComparer(Of T)
    Public Function Compare(ByVal x As T, ByVal y As T) As Integer Implements IComparer(Of T).Compare
        Return -1 * Comparer(Of T).Default.Compare(x, y)
    End Function
End Class

Module Example
    Sub Main()
        Dim values() = { Tuple.Create(13.54),
                         Tuple.Create(Double.NaN),
                         Tuple.Create(-189.42993),
                         Tuple.Create(Double.PositiveInfinity),
                         Tuple.Create(Double.Epsilon),
                         Tuple.Create(1.934E-17),
                         Tuple.Create(Double.NegativeInfinity),
                         Tuple.Create(-0.000000000003588),
                         Nothing}

        Console.WriteLine("The values in unsorted order:")
        For Each value As Tuple(Of Double) In values
            If value IsNot Nothing Then
                Console.WriteLine("   {0}", value.Item1)
            Else
                Console.WriteLine("   <null>")
            End If
        Next
        Console.WriteLine()

        Array.Sort(values, New DescendingComparer(Of Tuple(Of Double)))

        Console.WriteLine("The values sorted in descending order:")
        For Each value As Tuple(Of Double) In values
            If value IsNot Nothing Then
                Console.WriteLine("   {0}", value.Item1)
            Else
                Console.WriteLine("   <null>")
            End If
        Next
    End Sub
End Module
' The example displays the following output:
'      The values in unsorted order:
'         13.54
'         NaN
'         -189.42993
'         Infinity
'         4.94065645841247E-324
'         1.934E-17
'         -Infinity
'         -3.588E-12
'         <null>
'
'      The values sorted in descending order:
'         Infinity
'         13.54
'         1.934E-17
'         4.94065645841247E-324
'         -3.588E-12
'         -189.42993
'         -Infinity
'         NaN
'         <null>
' </Snippet2>
