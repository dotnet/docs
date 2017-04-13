Option Explicit On
Option Strict On


Public Class Class1

    '**********************************************************************
    Public Sub TestTextFieldParser()


        '********************************************************************
        '<Snippet23>
        Dim reader = 
          My.Computer.FileSystem.OpenTextFieldParser("C:\TestFolder1\test1.txt")
        reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
        reader.Delimiters = New String() {","}
        Dim currentRow As String()
        While Not reader.EndOfData
          Try
              currentRow = reader.ReadFields()
              Dim currentField As String
                For Each currentField In currentRow
                    MsgBox(currentField)
                Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                  MsgBox("Line " & ex.Message & 
                  "is not valid and will be skipped.")
            End Try
        End While
        '</Snippet23>


        '********************************************************************
        Using testReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\logs\test.log")
          '<Snippet21>
  testReader.SetDelimiters(vbTab)
          '</Snippet21>

          '<Snippet22>
  testReader.SetFieldWidths(5, 10, 11, -1)
  testReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
          '</Snippet22>
        End Using


        '********************************************************************
        ' <snippet4>
        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\logs\test.log")

            FileReader.SetDelimiters(vbTab)
        End Using
        ' </snippet4>


        '**********************************************************************
        ' <snippet7>
        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            FileReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileReader.SetDelimiters(",")
            FileReader.TrimWhiteSpace = True
        End Using
        ' </snippet7>

        'Combine 7 & 19 ???

        '**********************************************************************
        ' <snippet19>
        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            FileReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileReader.SetDelimiters(",")
        End Using
        ' </snippet19>


        '**********************************************************************
        ' <snippet20>
        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            FileReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
            FileReader.FieldWidths = New Integer() {5, 10, 11, -1}
        End Using
        ' </snippet20>


        '********************************************************************
        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\logs\test.log")

            ' <snippet5>
            FileReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileReader.CommentTokens = New String() {"'"}
            ' </snippet5>
        End Using

        'Combine 5 & 18 ???

        '**********************************************************************
        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            ' <snippet18>
            FileReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileReader.Delimiters = New String() {","}
            FileReader.CommentTokens = New String() {""}
            FileReader.HasFieldsEnclosedInQuotes = True
            ' </snippet18>
        End Using


        '**********************************************************************
        ' <snippet10>
        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            Dim allText As String = FileReader.ReadToEnd
            My.Computer.FileSystem.WriteAllText("C://testfile.txt", allText, True)
        End Using
        ' </snippet10>


        '**********************************************************************
        ' <snippet12>
        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\logs\test.log")

            FileReader.SetFieldWidths(5)
        End Using
        ' </snippet12>


        '**********************************************************************
        ' <snippet13>
        Using MyReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\logs\test.log")

            MyReader.SetFieldWidths(5, 10, -1)
        End Using
        ' </snippet13>


        '**********************************************************************
        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            ' <snippet14>
            FileReader.Close()
            ' </snippet14>
        End Using
    End Sub


    '********************************************************************
    Public Sub TestErrorLine()
        ' <snippet1>
        Dim FileReader As Microsoft.VisualBasic.FileIO.TextFieldParser
        FileReader = My.Computer.FileSystem.OpenTextFieldParser("C:\test.txt")
        Dim currentRow As String()
        While Not FileReader.EndOfData
            Try
                currentRow = FileReader.ReadFields
                For Each currentField As String In currentRow
                    My.Computer.FileSystem.WriteAllText(
                        "C://testfile.txt", currentField, True)
                Next
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & FileReader.ErrorLine & " is not valid.")
            End Try
        End While
        ' </snippet1>
    End Sub

    'Combine 1 & 3 ???

    '********************************************************************
    Public Sub TestErrorLineNumber()
        ' <snippet3>
        Dim FileReader As Microsoft.VisualBasic.FileIO.TextFieldParser
        FileReader = My.Computer.FileSystem.OpenTextFieldParser("C:\test.txt")
        Dim currentRow As String()
        While Not FileReader.EndOfData
            Try
                currentRow = FileReader.ReadFields
                For Each currentField As String In currentRow
                    My.Computer.FileSystem.WriteAllText(
                        "C://testfile.txt", currentField, True)
                Next
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & FileReader.ErrorLineNumber & " is not valid.")
            End Try
        End While
        ' </snippet3>
    End Sub


    '********************************************************************
    ' TextFieldParser.ReadFields Method
    Public Sub Method2()
        ' <snippet2>
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\ParserText.txt")
            MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {","}
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    For Each currentField As String In currentRow
                        My.Computer.FileSystem.WriteAllText(
                            "C://testfile.txt", currentField, True)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is invalid.  Skipping")
                End Try
            End While
        End Using
        ' </snippet2>
    End Sub


    '********************************************************************
    Public Sub TestEndOfData()
        ' <snippet6>
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
        ' </snippet6>
    End Sub


    '********************************************************************
    Public Sub TestPeekChars()
        ' <snippet8>
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\ParserText.txt")
            MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {","}
            MyReader.CommentTokens = New String() {"'"}
            Dim currentRow As String()
            While (MyReader.PeekChars(1) IsNot "")
                Try
                    currentRow = MyReader.ReadFields()
                    For Each currentField As String In currentRow
                        My.Computer.FileSystem.WriteAllText(
                           "C://testfile.txt", currentField, True)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is invalid.  Skipping")
                End Try
            End While
        End Using
        ' </snippet8>
    End Sub


    '********************************************************************
    Public Sub TestLineNumber()
        ' <snippet11>
        Using FileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\ParserText.txt")
            ' <snippet9>
            FileReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileReader.Delimiters = New String() {","}
            ' </snippet9>
            Dim currentRow As String()
            While Not FileReader.EndOfData
                Try
                    currentRow = FileReader.ReadFields()
                    Dim currentField As String
                    For Each currentField In currentRow
                        If currentField = "Jones" Then
                            MsgBox("The name Jones occurs on line " & 
                            FileReader.LineNumber)
                        End If
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & 
                   "is not valid and will be skipped.")
                End Try
            End While
        End Using
        ' </snippet11>
    End Sub



    '********************************************************************
    Public Sub TestReadLine()
        ' <snippet15>
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\ParserText.txt")
            MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {","}
            Dim currentRow As String
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadLine()
                    My.Computer.FileSystem.WriteAllText(
                       "C://testfile.txt", currentRow, True)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is invalid.  Skipping")
                End Try
            End While
        End Using
        ' </snippet15>
    End Sub


    '********************************************************************
    Public Sub TestFieldWidths()
        ' <snippet16>
        Using MyReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            MyReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
            MyReader.FieldWidths = {5, 10, 11, -1}
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
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
        ' </snippet16>
    End Sub


    '********************************************************************
    Public Sub TestTextFieldParserObject()
        ' <snippet17>
        Using MyReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("c:\logs\bigfile")

            MyReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {vbTab}
            Dim currentRow As String()
            'Loop through all of the fields in the file. 
            'If any lines are corrupt, report an error and continue parsing. 
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    ' Include code here to handle the row.
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & 
                    " is invalid.  Skipping")
                End Try
            End While
        End Using
        ' </snippet17>
    End Sub
End Class
