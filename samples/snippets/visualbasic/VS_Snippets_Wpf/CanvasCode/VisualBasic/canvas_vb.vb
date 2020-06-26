' <Snippet2>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class Canvas_VB
        Inherits Page

        Public Sub New()
            '<Snippet1>
            WindowTitle = "Canvas Sample"
            'Create a Canvas as the root Panel
            Dim myCanvas As New Canvas()
            myCanvas.Background = Brushes.LightSteelBlue

            Dim txt1 As New TextBlock
            txt1.FontSize = 14
            txt1.Text = "Hello World!"
            Canvas.SetLeft(txt1, 10)
            Canvas.SetTop(txt1, 100)
            myCanvas.Children.Add(txt1)

            'Add a second text element to show how absolute positioning works in a Canvas
            Dim txt2 As New TextBlock
            txt2.FontSize = 22
            txt2.Text = "Isn't absolute positioning handy?"
            Canvas.SetLeft(txt2, 75)
            Canvas.SetTop(txt2, 200)
            myCanvas.Children.Add(txt2)
            Me.Content = myCanvas
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
            Dim myContent As New Canvas_VB()
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
' </Snippet2>
