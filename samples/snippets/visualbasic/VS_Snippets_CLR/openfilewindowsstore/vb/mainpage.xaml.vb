'<snippetCode>
Imports System.IO
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.Storage
Imports System.Text
Imports Windows.Storage.Pickers
Imports Windows.UI.Popups
Partial Public NotInheritable Class MainPage
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    ' Create a file picker to open a file. Most file access in Windows Store Apps
    ' requires the use of a file picker for security purposes.
    Private picker As New FileOpenPicker()
    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)

        ' Set properties on the file picker such as start location and the type 
        ' of files to display.
        picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary
        picker.ViewMode = PickerViewMode.List
        picker.FileTypeFilter.Add(".txt")

        ' Show picker enabling user to pick one file.
        Dim result As StorageFile = Await picker.PickSingleFileAsync()

        If result IsNot Nothing Then
            Try
                ' Use FileIO to replace the content of the text file
                Await FileIO.WriteTextAsync(result, UserInputTextBox.Text)

                ' Display a success message
                StatusTextBox.Text = "Status: File saved successfully"
            Catch ex As Exception
                ' Display an error message
                StatusTextBox.Text = "Status: error saving the file - " + ex.Message
            End Try
        Else
            StatusTextBox.Text = "Status: User cancelled save operation"
        End If
    End Sub
End Class

'</snippetCode>