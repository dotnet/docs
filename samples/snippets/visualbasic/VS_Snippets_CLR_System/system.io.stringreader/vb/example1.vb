' <snippet1>
Imports System.IO

Module Module1

    Sub Main()
        ReadCharacters()
    End Sub

    Async Sub ReadCharacters()
        Dim stringToRead = "Some characters to read but not all"
        Dim charsRead(stringToRead.Length) As Char

        Using reader As StringReader = New StringReader(stringToRead)
            Await reader.ReadAsync(charsRead, 0, 23)
            Console.WriteLine(charsRead)
        End Using
    End Sub

End Module
' The example displays the following output:
' Some characters to read
'
' </snippet1>