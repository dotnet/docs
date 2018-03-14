    Public Sub Reset() _
        Implements System.Collections.IEnumerator.Reset

        _sr.DiscardBufferedData()
        _sr.BaseStream.Seek(0, IO.SeekOrigin.Begin)
        _current = Nothing
    End Sub