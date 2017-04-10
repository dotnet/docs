' <snippet14>
Imports System.IO

Module Module1

    Sub Main()
        Dim sourceDirectory As String = "C:\source"
        Dim destinationDirectory As String = "C:\destination"

        Try
            Directory.Move(sourceDirectory, destinationDirectory)
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub

End Module
' </snippet14>
