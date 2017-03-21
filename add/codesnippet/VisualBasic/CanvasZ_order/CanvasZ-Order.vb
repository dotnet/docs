Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Threading

Namespace SDKSample

    Public Class CanvasZOrder
        Inherits Page

        Public Sub New()

            WindowTitle = "Canvas ZIndex Sample"
            ' Create a Canvas as the Root Panel

            Dim myCanvas As New Canvas()

            ' Create the child Rectangle elements
            Dim myRectangle1 As New Rectangle()
            Dim myRectangle2 As New Rectangle()
            Dim myRectangle3 As New Rectangle()
            Dim myRectangle4 As New Rectangle()
            Dim myRectangle5 As New Rectangle()
            Dim myRectangle6 As New Rectangle()

            ' Set properties on the Rectangle elements
            Canvas.SetTop(myRectangle1, 100)
            Canvas.SetLeft(myRectangle1, 100)
            Canvas.SetZIndex(myRectangle1, 3)
            myRectangle1.Fill = Brushes.Blue
            myRectangle1.Width = 100
            myRectangle1.Height = 100

            ' <Snippet2>
            Canvas.SetTop(myRectangle2, 150)
            Canvas.SetLeft(myRectangle2, 150)
            Canvas.SetZIndex(myRectangle2, 1)
            myRectangle2.Fill = Brushes.Yellow
            myRectangle2.Width = 100
            myRectangle2.Height = 100
            ' </Snippet2>

            Canvas.SetTop(myRectangle3, 200)
            Canvas.SetLeft(myRectangle3, 200)
            Canvas.SetZIndex(myRectangle3, 2)
            myRectangle3.Fill = Brushes.Green
            myRectangle3.Width = 100
            myRectangle3.Height = 100

            Canvas.SetTop(myRectangle4, 300)
            Canvas.SetLeft(myRectangle4, 200)
            Canvas.SetZIndex(myRectangle4, 1)
            myRectangle4.Fill = Brushes.Green
            myRectangle4.Width = 100
            myRectangle4.Height = 100

            Canvas.SetTop(myRectangle5, 350)
            Canvas.SetLeft(myRectangle5, 150)
            Canvas.SetZIndex(myRectangle5, 3)
            myRectangle5.Fill = Brushes.Yellow
            myRectangle5.Width = 100
            myRectangle5.Height = 100

            Canvas.SetTop(myRectangle6, 400)
            Canvas.SetLeft(myRectangle6, 100)
            Canvas.SetZIndex(myRectangle6, 2)
            myRectangle6.Fill = Brushes.Blue
            myRectangle6.Width = 100
            myRectangle6.Height = 100

            ' Add the Rectangles to the Canvas' Children collection
            myCanvas.Children.Add(myRectangle1)
            myCanvas.Children.Add(myRectangle2)
            myCanvas.Children.Add(myRectangle3)
            myCanvas.Children.Add(myRectangle4)
            myCanvas.Children.Add(myRectangle5)
            myCanvas.Children.Add(myRectangle6)

            ' Add the Canvas as the Content of the parent Window Object

            Me.Content = myCanvas
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
            Dim myContent As New CanvasZOrder()
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

