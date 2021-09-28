Imports System.IO
Imports System.Windows

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>

Partial Public Class MainWindow
    Inherits Window
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Async Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs)
        Try
            Using sr As New StreamReader("TestFile.txt")
                ResultBlock.Text = Await sr.ReadToEndAsync()
            End Using
        Catch ex As FileNotFoundException
            ResultBlock.Text = ex.Message
        End Try
    End Sub
End Class
