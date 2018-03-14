Imports System.Diagnostics

Public Class Class8
    ' ebce3120-95c3-42b1-b70b-fa7da40c75e2
    ' For Each...Next Statement (Visual Basic)

    '<Snippet126>
    Public Sub ListColors()
        Dim colors As New AllColors()

        For Each theColor As Color In colors
            Debug.Write(theColor.Name & " ")
        Next
        Debug.WriteLine("")
        ' Output: red blue green
    End Sub

    ' Collection class.
    Public Class AllColors
        Implements System.Collections.IEnumerable

        Private _colors() As Color =
        {
            New Color With {.Name = "red"},
            New Color With {.Name = "blue"},
            New Color With {.Name = "green"}
        }

        Public Function GetEnumerator() As System.Collections.IEnumerator _
            Implements System.Collections.IEnumerable.GetEnumerator

            Return New ColorEnumerator(_colors)

            ' Instead of creating a custom enumerator, you could
            ' use the GetEnumerator of the array.
            'Return _colors.GetEnumerator
        End Function

        ' Custom enumerator.
        Private Class ColorEnumerator
            Implements System.Collections.IEnumerator

            Private _colors() As Color
            Private _position As Integer = -1

            Public Sub New(ByVal colors() As Color)
                _colors = colors
            End Sub

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return _colors(_position)
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                _position += 1
                Return (_position < _colors.Length)
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                _position = -1
            End Sub
        End Class
    End Class

    ' Element class.
    Public Class Color
        Public Property Name As String
    End Class
    '</Snippet126>

End Class
