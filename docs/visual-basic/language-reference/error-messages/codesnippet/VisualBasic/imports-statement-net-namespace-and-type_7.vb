        Public Function GetFolders() As String
            Dim sb As New strbld

            Dim dInfo As New dirinf("c:\")
            For Each dir As dirinf In dInfo.GetDirectories()
                sb.Append(dir.Name)
                sb.Append(ControlChars.CrLf)
            Next

            Return sb.ToString
        End Function