'<Snippet1>
' This example demonstrates a thread-safe method that adds to a
' running total.  It cannot be run directly.  You can compile it
' as a library, or add the class to a project.
Imports System.Threading

Public Class ThreadSafe
    ' Field totalValue contains a running total that can be updated
    ' by multiple threads. It must be protected from unsynchronized 
    ' access.
    Private totalValue As Integer = 0

    ' The Total property returns the running total.
    Public ReadOnly Property Total As Integer
        Get
            Return totalValue
        End Get
    End Property

    ' AddToTotal safely adds a value to the running total.
    Public Function AddToTotal(ByVal addend As Integer) As Integer
        Dim initialValue, computedValue As Integer
        Do
            ' Save the current running total in a local variable.
            initialValue = totalValue

            ' Add the new value to the running total.
            computedValue = initialValue + addend

            ' CompareExchange compares totalValue to initialValue. If
            ' they are not equal, then another thread has updated the
            ' running total since this loop started. CompareExchange
            ' does not update totalValue. CompareExchange returns the
            ' contents of totalValue, which do not equal initialValue,
            ' so the loop executes again.
        Loop While initialValue <> Interlocked.CompareExchange( _
            totalValue, computedValue, initialValue)
        ' If no other thread updated the running total, then 
        ' totalValue and initialValue are equal when CompareExchange
        ' compares them, and computedValue is stored in totalValue.
        ' CompareExchange returns the value that was in totalValue
        ' before the update, which is equal to initialValue, so the 
        ' loop ends.

        ' The function returns computedValue, not totalValue, because
        ' totalValue could be changed by another thread between
        ' the time the loop ends and the function returns.
        Return computedValue
    End Function
End Class
'</Snippet1>