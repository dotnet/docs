' <snippet4>
Imports Windows.Storage.Streams

Public NotInheritable Class BlankPage
    Inherits Page

    Dim ue As System.Text.UnicodeEncoding
    Dim bytesToWrite() As Byte
    Dim bytesToAdd() As Byte
    Dim totalBytes As Integer


    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        ue = New System.Text.UnicodeEncoding()
        bytesToWrite = ue.GetBytes("example text to write to memory stream")
        bytesToAdd = ue.GetBytes("text added through datawriter")
        totalBytes = bytesToWrite.Length + bytesToAdd.Length
    End Sub

    Private Async Sub CreateButton_Click(sender As Object, e As RoutedEventArgs)
        Dim bytesRead(totalBytes - 1) As Byte
        Using memStream As MemoryStream = New MemoryStream(totalBytes)
            Await memStream.WriteAsync(bytesToWrite, 0, bytesToWrite.Length)

            Dim writer As DataWriter = New DataWriter(memStream.AsOutputStream())
            writer.WriteBytes(bytesToAdd)
            Await writer.StoreAsync()

            memStream.Seek(0, SeekOrigin.Begin)

            Dim reader As DataReader = New DataReader(memStream.AsInputStream())
            Await reader.LoadAsync(CType(totalBytes, UInteger))
            reader.ReadBytes(bytesRead)
            Results.Text = ue.GetString(bytesRead, 0, bytesRead.Length)
        End Using
    End Sub
End Class
' </snippet4>