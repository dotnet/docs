' When you implement IEnumerable, you must also implement IEnumerator.
Public Class PeopleEnum
    Implements IEnumerator

    Public _people() As Person

    ' Enumerators are positioned before the first element
    ' until the first MoveNext() call.
    Dim position As Integer = -1

    Public Sub New(ByVal list() As Person)
        _people = list
    End Sub

    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        position = position + 1
        Return (position < _people.Length)
    End Function

    Public Sub Reset() Implements IEnumerator.Reset
        position = -1
    End Sub

    Public ReadOnly Property Current() As Object Implements IEnumerator.Current
        Get
            Try
                Return _people(position)
            Catch ex As IndexOutOfRangeException
                Throw New InvalidOperationException()
            End Try
        End Get
    End Property
End Class