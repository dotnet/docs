Imports System.IO

Class MainWindow

    ' <snippet2>
    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim UserDirectory As String = "c:\Users\exampleuser\"

        Using SourceReader As StreamReader = File.OpenText(UserDirectory + "BigFile.txt")
            Using DestinationWriter As StreamWriter = File.CreateText(UserDirectory + "CopiedFile.txt")
                Await CopyFilesAsync(SourceReader, DestinationWriter)
            End Using
        End Using
    End Sub

    Public Async Function CopyFilesAsync(Source As StreamReader, Destination As StreamWriter) As Task
        Dim buffer(4096) As Char
        Dim numRead As Integer

        numRead = Await Source.ReadAsync(buffer, 0, buffer.Length)
        Do While numRead <> 0
            Await Destination.WriteAsync(buffer, 0, numRead)
            numRead = Await Source.ReadAsync(buffer, 0, buffer.Length)
        Loop
        
    End Function
    ' </snippet2>
End Class





