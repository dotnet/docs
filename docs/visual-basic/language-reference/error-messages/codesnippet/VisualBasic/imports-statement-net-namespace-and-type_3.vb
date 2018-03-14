        Public Function GetFolders() As String
            Dim sb As New StringBuilder

            Dim dInfo As New DirectoryInfo("c:\")
            For Each dir As DirectoryInfo In dInfo.GetDirectories()
                sb.Append(dir.Name)
                sb.Append(CrLf)
            Next

            Return sb.ToString
        End Function