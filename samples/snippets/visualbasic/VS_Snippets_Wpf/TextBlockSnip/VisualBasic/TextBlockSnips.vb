Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class TextBlockSnips
        Inherits Page

        Public Sub New()
            'Create a Canvas as the root Panel
            Dim myParentStackPanel As New StackPanel()
            myParentStackPanel.VerticalAlignment = Windows.VerticalAlignment.Top
            myParentStackPanel.HorizontalAlignment = Windows.HorizontalAlignment.Left

            ' <Snippet1>
            Dim myTextBlock As New TextBlock()
            myTextBlock.FontSize = 18
            myTextBlock.FontWeight = FontWeights.Bold
            myTextBlock.FontStyle = FontStyles.Italic
            myTextBlock.Text = "Hello, world!"
            ' </Snippet1>

            myParentStackPanel.Children.Add(myTextBlock)

            ' Add the parent Canvas as the Content of the Window Object
            Me.Content = myParentStackPanel
        End Sub
    End Class
    'Displays the Sample
    Public Class MyApp
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()
        End Sub

        Private Sub CreateAndShowMainWindow()
            ' Create the application's main window.
            Dim myWindow As New NavigationWindow()
            ' Display the sample
            Dim myContent As New TextBlockSnips()
            myWindow.Navigate(myContent)
            MainWindow = myWindow
            myWindow.Show()
        End Sub
    End Class
    ' Starts the application.
    Public NotInheritable Class EntryClass

        Public Shared Sub Main()
            Dim app As New MyApp()
            app.Run()
        End Sub
    End Class
End Namespace