    Private Sub WriteFile()
        Using writer As System.IO.TextWriter = System.IO.File.CreateText("log.txt")
            writer.WriteLine("This is line one.")
            writer.WriteLine("This is line two.")
        End Using
    End Sub

    Private Sub ReadFile()
        Using reader As System.IO.TextReader = System.IO.File.OpenText("log.txt")
            Dim line As String

            line = reader.ReadLine()
            Do Until line Is Nothing
                Console.WriteLine(line)
                line = reader.ReadLine()
            Loop
        End Using
    End Sub