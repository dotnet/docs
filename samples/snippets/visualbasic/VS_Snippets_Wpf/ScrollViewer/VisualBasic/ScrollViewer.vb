Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Threading

Namespace SDKSample

    Public Class ScrollViewerSample
        Inherits Page

        Public Sub New()

            WindowTitle = "ScrollViewer Sample"
            '<Snippet1>

            'Define a ScrollViewer.
            Dim myScrollViewer As New ScrollViewer
            myScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto

            'Add Layout control.
            Dim myStackPanel As New StackPanel
            myStackPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            myStackPanel.VerticalAlignment = System.Windows.VerticalAlignment.Top

            Dim myTextBlock As New TextBlock
            myTextBlock.TextWrapping = TextWrapping.Wrap
            myTextBlock.Margin = New Thickness(0, 0, 0, 20)
            myTextBlock.Text = "Scrolling is enabled when it is necessary. Resize the Window, making it larger and smaller."

            Dim myRectangle As New Rectangle
            myRectangle.Fill = Brushes.Red
            myRectangle.Width = 500
            myRectangle.Height = 500

            'Add child elements to the parent StackPanel.
            myStackPanel.Children.Add(myTextBlock)
            myStackPanel.Children.Add(myRectangle)

            'Add the StackPanel as the lone Child of the Border
            myScrollViewer.Content = myStackPanel
            Me.Content = myScrollViewer
            '</Snippet1>
        End Sub
    End Class
    'Displays the Sample
    Public Class app
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()
        End Sub

        Private Sub CreateAndShowMainWindow()
            ' Create the application's main window.
            Dim myWindow As New NavigationWindow()
            ' Display the sample
            Dim myContent As New ScrollViewerSample()
            myWindow.Navigate(myContent)
            MainWindow = myWindow
            myWindow.Show()
        End Sub
    End Class
    ' Starts the application.
    Public NotInheritable Class EntryClass

        Public Shared Sub Main()
            Dim app As New app()
            app.Run()
        End Sub
    End Class
End Namespace

