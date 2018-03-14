    Public Class dictionary(Of entryType, keyType As {IComparable, IFormattable, New})
        Public Sub add(ByVal et As entryType, ByVal kt As keyType)
            Dim dk As keyType
            If kt.CompareTo(dk) = 0 Then
            End If
        End Sub
    End Class