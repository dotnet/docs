Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class CanvasAttachedProperties
        Inherits Page

        Public Sub New()
            '<Snippet1>
            WindowTitle = "Attached Properties Sample"
            ' Add a Border
            Dim myBorder As New Border()
            myBorder.HorizontalAlignment = Windows.HorizontalAlignment.Left
            myBorder.VerticalAlignment = Windows.VerticalAlignment.Top
            myBorder.BorderBrush = Brushes.Black
            myBorder.BorderThickness = New Thickness(2)

            ' Create a Canvas as the root Panel
            Dim myCanvas As New Canvas()
            myCanvas.Background = Brushes.LightBlue
            myCanvas.Width = 400
            myCanvas.Height = 400

            ' Create the child Button elements
            Dim myButton1 As New Button()
            Dim myButton2 As New Button()
            Dim myButton3 As New Button()
            Dim myButton4 As New Button()

            ' Set Positioning attached properties on Button elements
            Canvas.SetTop(myButton1, 50)
            myButton1.Content = "Canvas.Top=50"
            Canvas.SetBottom(myButton2, 50)
            myButton2.Content = "Canvas.Bottom=50"
            Canvas.SetLeft(myButton3, 50)
            myButton3.Content = "Canvas.Left=50"
            Canvas.SetRight(myButton4, 50)
            myButton4.Content = "Canvas.Right=50"

            ' Add Buttons to the Canvas' Children collection
            myCanvas.Children.Add(myButton1)
            myCanvas.Children.Add(myButton2)
            myCanvas.Children.Add(myButton3)
            myCanvas.Children.Add(myButton4)

            ' Add the Canvas as the lone Child of the Border
            myBorder.Child = myCanvas
            Me.Content = myBorder
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
            Dim myContent As New CanvasAttachedProperties()
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