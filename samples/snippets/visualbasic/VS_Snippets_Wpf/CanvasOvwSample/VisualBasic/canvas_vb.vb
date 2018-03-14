Imports System
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
            Dim myParentCanvas As New Canvas()
            myParentCanvas.Width = 400
            myParentCanvas.Height = 400

            ' Define child Canvas elements
            Dim myCanvas1 As New Canvas()
            myCanvas1.Background = Brushes.Red
            myCanvas1.Height = 100
            myCanvas1.Width = 100
            Canvas.SetTop(myCanvas1, 0)
            Canvas.SetLeft(myCanvas1, 0)

            Dim myCanvas2 As New Canvas()
            myCanvas2.Background = Brushes.Green
            myCanvas2.Height = 100
            myCanvas2.Width = 100
            Canvas.SetTop(myCanvas2, 100)
            Canvas.SetLeft(myCanvas2, 100)

            Dim myCanvas3 As New Canvas()
            myCanvas3.Background = Brushes.Blue
            myCanvas3.Height = 100
            myCanvas3.Width = 100
            Canvas.SetTop(myCanvas3, 50)
            Canvas.SetLeft(myCanvas3, 50)

            ' Add child elements to the Canvas' Children collection
            myParentCanvas.Children.Add(myCanvas1)
            myParentCanvas.Children.Add(myCanvas2)
            myParentCanvas.Children.Add(myCanvas3)

            ' Add the parent Canvas as the Content of the Window Object
            Me.Content = myParentCanvas
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