        Dim lst As New List(Of Integer) From {10, 20, 30, 40}

        For index As Integer = lst.Count - 1 To 0 Step -1
            lst.RemoveAt(index)
        Next

        Debug.WriteLine(lst.Count.ToString)
        ' Output: 0