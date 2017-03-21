        Dim StdFormat As Integer() = {5, 10, 11, -1}
        Dim ErrorFormat As Integer() = {5, 5, -1}
        Using FileReader As New  Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\testfile.txt")

            FileReader.TextFieldType = FileIO.FieldType.FixedWidth
            FileReader.FieldWidths = StdFormat
            Dim CurrentRow As String()
            While Not FileReader.EndOfData
                Try
                    Dim RowType As String = FileReader.PeekChars(3)
                    If String.Compare(RowType, "Err") = 0 Then
                        ' If this line describes an error, the format of the row will be different.
                        FileReader.SetFieldWidths(ErrorFormat)
                        CurrentRow = FileReader.ReadFields
                        FileReader.SetFieldWidths(StdFormat)
                    Else
                        ' Otherwise parse the fields normally
                        CurrentRow = FileReader.ReadFields
                        For Each newString As String In CurrentRow
                            My.Computer.FileSystem.WriteAllText("newFile.txt", newString, True)
                        Next
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is invalid.  Skipping")
                End Try
            End While
        End Using