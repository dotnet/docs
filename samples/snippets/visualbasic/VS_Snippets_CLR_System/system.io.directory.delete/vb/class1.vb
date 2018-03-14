' <snippet1>
Imports System.IO

Module Module1

    Sub Main()
        Dim subPath = "C:\NewDirectory\NewSubDirectory"

        Try
            Directory.CreateDirectory(subPath)
            Directory.Delete(subPath)

            Dim directoryExists = Directory.Exists("C:\NewDirectory")
            Dim subDirectoryExists = Directory.Exists(subPath)

            Console.WriteLine("top-level directory exists: " & directoryExists)
            Console.WriteLine("sub-directory exists: " & subDirectoryExists)

        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.Message)
        End Try
    End Sub

End Module
' </snippet1>
