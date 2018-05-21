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