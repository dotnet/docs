        Public Function GetFolders() As String
            Dim sb As New systxt.StringBuilder

            Dim dInfo As New sysio.DirectoryInfo("c:\")
            For Each dir As sysio.DirectoryInfo In dInfo.GetDirectories()
                sb.Append(dir.Name)
                sb.Append(ch.CrLf)
            Next

            Return sb.ToString
        End Function