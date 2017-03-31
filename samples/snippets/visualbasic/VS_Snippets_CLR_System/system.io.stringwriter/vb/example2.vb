' <Snippet2>
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
            For Each c As Char In charsToAdd
                Await writer.WriteLineAsync(c)
            Next
            Console.WriteLine(stringToWrite.ToString())
        End Using
    End Sub
End Module
' The example displays the following output:
'
' Characters in StringBuilder
' a
' n
' d 
'
' c
' h
' a
' r
' s
' 
' t
' o
'
' a
' d
' d
'
' </Snippet2>