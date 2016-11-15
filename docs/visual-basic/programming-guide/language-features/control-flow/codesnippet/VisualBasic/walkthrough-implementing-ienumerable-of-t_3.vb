    Public Function GetEnumerator() As IEnumerator(Of String) _
        Implements IEnumerable(Of String).GetEnumerator

        Return New StreamReaderEnumerator(_filePath)
    End Function

    Private Function GetEnumerator1() As IEnumerator _
        Implements IEnumerable.GetEnumerator

        Return Me.GetEnumerator()
    End Function