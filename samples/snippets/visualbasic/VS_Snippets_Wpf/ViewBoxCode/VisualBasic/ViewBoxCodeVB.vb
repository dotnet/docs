Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Threading

Namespace SDKSample

    Public Class ViewBoxCodeVB
        Inherits Page

        Public Sub New()

            WindowTitle = "ViewBoxCode Sample"
            ' Create a Canvas as the Root Panel
            Dim myCanvas As New Canvas()
            myCanvas.Background = Brushes.Silver
            myCanvas.Width = 600
            myCanvas.Height = 600
            ' <Snippet1>
            
            ' <Snippet2>

            ' Create a ViewBox and add it to the Canvas
            Dim myViewbox As New Viewbox()
            myViewbox.StretchDirection = StretchDirection.Both
            myViewbox.Stretch = Stretch.Fill
            myViewbox.MaxWidth = 400
            myViewbox.MaxHeight = 400
            ' </Snippet2>

            ' Create a new Grid that is hosted in the Viewbox
            Dim myGrid As New Grid()

            ' Create an Ellipse that is also hosted in the Grid
            Dim myEllipse As New Ellipse()
            myEllipse.Stroke = Brushes.RoyalBlue
            myEllipse.Fill = Brushes.LightBlue

            ' Create a TextBlock that is also hosted in the Grid
            Dim myTextBlock As New TextBlock()
            myTextBlock.Text = "Viewbox"

            ' Add the children to the Grid
            myGrid.Children.Add(myEllipse)
            myGrid.Children.Add(myTextBlock)

            ' <Snippet3>
            
            ' Add the Grid as the single child of the Viewbox
            myViewbox.Child = myGrid
            ' </Snippet3>

            'Position the Viewbox in the Parent Canvas
            Canvas.SetTop(myViewbox, 100)
            Canvas.SetLeft(myViewbox, 100)
            myCanvas.Children.Add(myViewbox)
            ' </Snippet1>

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
            Dim myContent As New ViewBoxCodeVB()
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

