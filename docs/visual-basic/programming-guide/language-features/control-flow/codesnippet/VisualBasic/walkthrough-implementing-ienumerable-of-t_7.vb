    Public Function MoveNext() As Boolean _
        Implements System.Collections.IEnumerator.MoveNext

        _current = _sr.ReadLine()
        If _current Is Nothing Then Return False
        Return True
    End Function