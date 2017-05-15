' <Snippet41>
Imports System.IO

Module Module1

    Sub Main()
        ReadCharacters()
    End Sub

    Async Sub ReadCharacters()
        Dim result As String

        Using reader As StreamReader = File.OpenText("existingfile.txt")
            Console.WriteLine("Opened file.")
            result = Await reader.ReadLineAsync()
            Console.WriteLine("First line contains: " + result)
        End Using
    End Sub
End Module
' </Snippet41>