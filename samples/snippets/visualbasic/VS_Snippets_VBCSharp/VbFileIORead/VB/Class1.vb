Class Class384033c618f94d59961036371226558f
    ' HowtoReadTextFromFilesWithAStreamReader(VisualBasic)

    Public Sub Method1()
        ' <snippet1>
        Dim fileReader As System.IO.StreamReader
        fileReader =
        My.Computer.FileSystem.OpenTextFileReader("C:\\testfile.txt")
        Dim stringReader As String
        stringReader = fileReader.ReadLine()
        MsgBox("The first line of the file is " & stringReader)
        ' </snippet1>
    End Sub

End Class

Class Class735fe9d70f7a4185ba02f35e580ec4b8
    ' HowtoReadfromTextFiles(VisualBasic)

    Public Sub Method2()
        ' <snippet2>
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\test.txt")
        MsgBox(fileReader)
        ' </snippet2>
    End Sub

    Public Sub Method3()
        ' <snippet3>
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\test.txt",
           System.Text.Encoding.UTF32)
        MsgBox(fileReader)
        ' </snippet3>
    End Sub

End Class

Class Class8d185eb279ca42cd95a7d3ff44a5a0f8
    ' HowtoReadFromATextFileWithMultipleFormatsInVisualBasic

    Public Sub Method4()
        ' <snippet4>
        Dim stdFormat As Integer() = {5, 10, 11, -1}
        Dim errorFormat As Integer() = {5, 5, -1}
        ' </snippet4>
    End Sub

    Public Sub Method5()
        Dim stdFormat As Integer() = {5, 10, 11, -1}
        ' <snippet5>
        Using MyReader As New FileIO.TextFieldParser("..\..\testfile.txt")
            MyReader.TextFieldType = FileIO.FieldType.FixedWidth
            MyReader.FieldWidths = stdFormat
            ' </snippet5>
        End Using
    End Sub

    Public Sub Method6()
        Using MyReader As New Microsoft.VisualBasic.
                FileIO.TextFieldParser("C:\testfile.txt")
            MyReader.TextFieldType = FileIO.FieldType.FixedWidth
            Dim stdFormat As Integer() = {5, 10, 11, -1}
            Dim errorFormat As Integer() = {5, 5, -1}
            ' <snippet6>
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
                    ' </snippet6>
                Catch ex as System.Exception
                End Try
            end while
        end using
    End Sub

    Public Sub Method7()
        Using MyReader As New Microsoft.VisualBasic.
                FileIO.TextFieldParser("C:\testfile.txt")
            MyReader.TextFieldType = FileIO.FieldType.FixedWidth
            While Not MyReader.EndOfData
                try
                    ' <snippet7>
                Catch ex As Microsoft.VisualBasic.
                              FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is invalid.")
                End Try
            End While
        End Using
        ' </snippet7>
    End Sub

    Public Sub Method8()
        ' <snippet8>
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
        ' </snippet8>
    End Sub

End Class

Class Class99be5692967a4e85993ecd18139a5a69
    ' HowtoReadFromAFixed-widthTextFileInVisualBasic

    Public Sub Method9()
        ' <snippet9>
        Using Reader As New Microsoft.VisualBasic.
            FileIO.TextFieldParser("C:\TestFolder\test.log")
            ' </snippet9>
        End Using
    End Sub

    Public Sub Method10()
        Using Reader As New Microsoft.VisualBasic.
                            FileIO.TextFieldParser(
                              "C:\TestFolder\test.log")
            ' <snippet10>
            Reader.TextFieldType =
            Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
            Reader.SetFieldWidths(5, 10, 11, -1)
            ' </snippet10>
        end using
    End Sub

    Public Sub Method11()
        Using Reader As New Microsoft.VisualBasic.
                            FileIO.TextFieldParser(
                            "C:\TestFolder\test.log")
            ' <snippet11>
            Dim currentRow As String()
            While Not Reader.EndOfData
                Try
                    currentRow = Reader.ReadFields()
                    Dim currentField As String
                    For Each currentField In currentRow
                        MsgBox(currentField)
                    Next
                Catch ex As Microsoft.VisualBasic.
                            FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try
                ' </snippet11>
            End While
        End Using
    End Sub

    Public Sub Method12()
        using Reader As New Microsoft.VisualBasic.
                            FileIO.TextFieldParser(
                              "C:\TestFolder\test.log")
            while Not Reader.EndOfData
                ' <snippet12>
            End While
        End Using
        ' </snippet12>
    End Sub

    Public Sub Method13()
        ' <snippet13>
        Using Reader As New Microsoft.VisualBasic.FileIO.
           TextFieldParser("C:\TestFolder\test.log")

            Reader.TextFieldType =
               Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
            Reader.SetFieldWidths(5, 10, 11, -1)
            Dim currentRow As String()
            While Not Reader.EndOfData
                Try
                    currentRow = Reader.ReadFields()
                    Dim currentField As String
                    For Each currentField In currentRow
                        MsgBox(currentField)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using
        ' </snippet13>
    End Sub

End Class

Class Classa7ce11069e5448f688deb421c19bd128
    ' HowtoReadfromExistingTextFilesInMyDocuments(VisualBasic)

    Public Sub Method14()
        ' <snippet14>
        Dim filePaths As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        Dim allText As String
        Try
            filePaths = My.Computer.FileSystem.GetFiles(
              My.Computer.FileSystem.SpecialDirectories.MyDocuments)
            For Each file As String In filePaths
                allText = My.Computer.FileSystem.ReadAllText(file)
                My.Computer.FileSystem.WriteAllText("bigfile.txt", allText, True)
            Next
        Catch fileException As Exception
            Throw fileException
        End Try
        ' </snippet14>
    End Sub

End Class

Class Classa8413fe40dba49c8869244fb67a9ec4f
    ' HowtoReadFromAComma-DelimitedTextFileInVisualBasic

    Public Sub Method15()
        ' <snippet15>
        Using MyReader As New Microsoft.VisualBasic.
                              FileIO.TextFieldParser(
                                "C:\TestFolder\test.txt")
            ' </snippet15>
        end using
    End Sub

    Public Sub Method16()
        Using MyReader As New Microsoft.VisualBasic.
                              FileIO.TextFieldParser(
                                "C:\TestFolder\test.txt")
            ' <snippet16>
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            ' </snippet16>
        end using
    End Sub

    Public Sub Method17()
        Using MyReader As New Microsoft.VisualBasic.
                              FileIO.TextFieldParser(
                                "C:\TestFolder\test.txt")
            ' <snippet17>

            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    For Each currentField In currentRow
                        MsgBox(currentField)
                    Next
                Catch ex As Microsoft.VisualBasic.
                            FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try
                ' </snippet17>
            end while
        end using
    End Sub

    Public Sub Method18()
        Using MyReader As New Microsoft.VisualBasic.
                              FileIO.TextFieldParser(
                                "C:\TestFolder\test.txt")
            While Not MyReader.EndOfData
                ' <snippet18>
            End While
        End Using
        ' </snippet18>
    End Sub

    Public Sub Method19()
        ' <snippet19>
        Using MyReader As New Microsoft.VisualBasic.
                              FileIO.TextFieldParser(
                                "C:\TestFolder\test.txt")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    For Each currentField In currentRow
                        MsgBox(currentField)
                    Next
                Catch ex As Microsoft.VisualBasic.
                            FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using
        ' </snippet19>
    End Sub

End Class


