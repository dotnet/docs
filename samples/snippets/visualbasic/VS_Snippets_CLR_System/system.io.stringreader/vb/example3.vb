' <snippet3>
Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        ReadCharacters()
    End Sub

    Async Sub ReadCharacters()
        Dim stringToRead = New StringBuilder()
        stringToRead.AppendLine("Characters in 1st line to read")
        stringToRead.AppendLine("and 2nd line")
        stringToRead.AppendLine("and the end")

        Using reader As StringReader = New StringReader(stringToRead.ToString())
            Dim readText As String = Await reader.ReadLineAsync()
            While Not IsNothing(readText)
                Console.WriteLine(readText)
                readText = Await reader.ReadLineAsync()
            End While
        End Using
    End Sub
End Module
' The example displays the following output:
'
' Characters in 1st line to read
' and 2nd line
' and the end
'
' </snippet3>