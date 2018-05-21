        Dim stdFormat As Integer() = {5, 10, 11, -1}
        Dim errorFormat As Integer() = {5, 5, -1}
        Using MyReader As New FileIO.TextFieldParser("..\..\testfile.txt")
            MyReader.TextFieldType = FileIO.FieldType.FixedWidth
            MyReader.FieldWidths = stdFormat
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    Dim rowType = MyReader.PeekChars(3)
                    If String.Compare(rowType, "Err") = 0 Then
                        ' If this line describes an error, the format of the row will be different.
                        MyReader.SetFieldWidths(errorFormat)
                    Else
                        ' Otherwise parse the fields normally
                        MyReader.SetFieldWidths(stdFormat)
                    End If
                    currentRow = MyReader.ReadFields
                    For Each newString In currentRow
                        Console.Write(newString & "|")
                    Next
                    Console.WriteLine()
                Catch ex As FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is invalid.  Skipping")
                End Try
            End While
        End Using
        Console.ReadLine()