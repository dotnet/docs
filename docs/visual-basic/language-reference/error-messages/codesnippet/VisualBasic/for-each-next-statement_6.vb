        Dim dInfo As New System.IO.DirectoryInfo("c:\")
        For Each dir As System.IO.DirectoryInfo In dInfo.GetDirectories()
            Debug.WriteLine(dir.Name)
        Next