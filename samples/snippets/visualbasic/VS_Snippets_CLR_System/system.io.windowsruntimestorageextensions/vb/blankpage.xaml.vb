' <snippet2>
Imports System.Text
Imports System.IO
Imports Windows.Storage.Pickers
Imports Windows.Storage

NotInheritable Public Class BlankPage
    Inherits Page

    

    Private Async Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim contents As StringBuilder = New StringBuilder()
        Dim nextLine As String
        Dim lineCounter As Integer = 1

        Dim openPicker = New FileOpenPicker()
        openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary

        openPicker.FileTypeFilter.Add(".txt")
        Dim selectedFile As StorageFile = Await openPicker.PickSingleFileAsync()

        Using reader As StreamReader = New StreamReader(Await selectedFile.OpenStreamForReadAsync())
            nextLine = Await reader.ReadLineAsync()
            While (nextLine <> Nothing)
                contents.AppendFormat("{0}. ", lineCounter)
                contents.Append(nextLine)
                contents.AppendLine()
                lineCounter = lineCounter + 1
                If (lineCounter > 3) Then
                    contents.AppendLine("Only first 3 lines shown.")
                    Exit While
                End If
                nextLine = Await reader.ReadLineAsync()
            End While
        End Using
        DisplayContentsBlock.Text = contents.ToString()
    End Sub
End Class
' </snippet2>