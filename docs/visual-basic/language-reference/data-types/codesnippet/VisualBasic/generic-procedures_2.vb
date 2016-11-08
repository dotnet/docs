    Public Function findElement(Of T As IComparable) (
            ByVal searchArray As T(), ByVal searchValue As T) As Integer

        If searchArray.GetLength(0) > 0 Then
            For i As Integer = 0 To searchArray.GetUpperBound(0)
                If searchArray(i).CompareTo(searchValue) = 0 Then Return i
            Next i
        End If

        Return -1
    End Function