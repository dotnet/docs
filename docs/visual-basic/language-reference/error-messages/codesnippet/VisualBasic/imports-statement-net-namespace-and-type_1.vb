        Public Function GetFolders() As String
            ' Create a new StringBuilder, which is used
            ' to efficiently build strings.
            Dim sb As New System.Text.StringBuilder

            Dim dInfo As New System.IO.DirectoryInfo("c:\")

            ' Obtain an array of directories, and iterate through
            ' the array.
            For Each dir As System.IO.DirectoryInfo In dInfo.GetDirectories()
                sb.Append(dir.Name)
                sb.Append(Microsoft.VisualBasic.ControlChars.CrLf)
            Next

            Return sb.ToString
        End Function