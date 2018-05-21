    Public Function GetPropertyValue(ByVal propertyName As String,
                                     Optional ByVal StringSearchOption As StringSearchOption = StringSearchOption.StartsWith,
                                     Optional ByVal trimSpaces As Boolean = True) As List(Of String)

        Dim sr As StreamReader = Nothing
        Dim results As New List(Of String)
        Dim line = ""
        Dim testLine = ""

        Try
            sr = New StreamReader(p_filePath)

            While Not sr.EndOfStream
                line = sr.ReadLine()

                ' Perform a case-insensitive search by using the specified search options.
                testLine = UCase(line)
                If trimSpaces Then testLine = Trim(testLine)

                Select Case StringSearchOption
                    Case StringSearchOption.StartsWith
                        If testLine.StartsWith(UCase(propertyName)) Then results.Add(line)
                    Case StringSearchOption.Contains
                        If testLine.Contains(UCase(propertyName)) Then results.Add(line)
                    Case StringSearchOption.EndsWith
                        If testLine.EndsWith(UCase(propertyName)) Then results.Add(line)
                End Select
            End While
        Catch
            ' Trap any exception that occurs in reading the file and return Nothing.
            results = Nothing
        Finally
            If sr IsNot Nothing Then sr.Close()
        End Try

        Return results
    End Function