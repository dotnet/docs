Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Threading

Namespace SDKSample
    Public Class PlotPanelSample
        Inherits Page
        Public Sub New()
            WindowTitle = "PlotPanel Sample"
            Dim plot1 As New PlotPanel
            plot1.Background = Brushes.White
            Dim rect1 As New Rectangle
            rect1.Fill = Brushes.CornflowerBlue
            rect1.Width = 200
            rect1.Height = 200
            plot1.Children.Add(rect1)
            Me.Content = plot1
        End Sub
    End Class
    '<Snippet1>
    Public Class PlotPanel
        Inherits Panel
        'Override the default Measure method of Panel.

        '<Snippet2>
        Protected Overrides Function MeasureOverride(ByVal availableSize As System.Windows.Size) As System.Windows.Size
            Dim panelDesiredSize As Size = New Size()
            ' In our example, we just have one child. 
            ' Report that our panel requires just the size of its only child.
            For Each child As UIElement In InternalChildren
                child.Measure(availableSize)
                panelDesiredSize = child.DesiredSize
            Next
            Return panelDesiredSize
        End Function
        '</Snippet2>
        Protected Overrides Function ArrangeOverride(ByVal finalSize As System.Windows.Size) As System.Windows.Size
            For Each child As UIElement In InternalChildren
                Dim x As Double = 50
                Dim y As Double = 50
                child.Arrange(New Rect(New System.Windows.Point(x, y), child.DesiredSize))
            Next
            Return finalSize
        End Function
    End Class
    '</Snippet1>

    'Displays the Sample.
    Public Class app
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()
        End Sub

        Private Sub CreateAndShowMainWindow()
            ' Create the application's main window.
            Dim myWindow As New NavigationWindow()
            ' Display the sample.
            Dim myContent As New PlotPanelSample()
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

