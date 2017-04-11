' <snippet2>
Imports System.IO

Module Module1

    Sub Main()
        Dim topPath = "C:\NewDirectory"
        Dim subPath = "C:\NewDirectory\NewSubDirectory"

        Try
            Directory.CreateDirectory(subPath)

            Using writer As StreamWriter = File.CreateText(subPath + "\example.txt")
                writer.WriteLine("content added")
            End Using

            Directory.Delete(topPath, True)

            Dim directoryExists = Directory.Exists(topPath)

            Console.WriteLine("top-level directory exists: " & directoryExists)
        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.Message)
        End Try
    End Sub

End Module
' </snippet2>
