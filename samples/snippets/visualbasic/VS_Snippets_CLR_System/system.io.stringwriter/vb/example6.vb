' <Snippet6>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        WriteCharacters()
    End Sub

    Async Sub WriteCharacters()
        Dim stringToWrite As StringBuilder = New StringBuilder("Characters in StringBuilder")
        stringToWrite.AppendLine()

        Using writer As StringWriter = New StringWriter(stringToWrite)

            Dim ue As UnicodeEncoding = New UnicodeEncoding()
            Dim charsToAdd() = ue.GetChars(ue.GetBytes("and chars to add"))

            Await writer.WriteAsync(charsToAdd, 0, charsToAdd.Length)

            Console.WriteLine(stringToWrite.ToString())
        End Using
    End Sub
End Module
' The example displays the following output:
'
' Characters in StringBuilder
' and chars to add
'
' </Snippet6>