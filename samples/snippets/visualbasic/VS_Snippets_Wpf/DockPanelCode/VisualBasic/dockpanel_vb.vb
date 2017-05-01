' <Snippet2>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace SDKSample
    Public Class DockPanel_VB
        Inherits Page

        Public Sub New()
            '<Snippet1>
            WindowTitle = "DockPanel Sample"
            'Create a DockPanel as the root Panel
            Dim myDP As New DockPanel()
            ' Add the first Rectangle to the DockPanel
            Dim rect1 As New Rectangle
            rect1.Stroke = Brushes.Black
            rect1.Fill = Brushes.SkyBlue
            rect1.Height = 25
            DockPanel.SetDock(rect1, Dock.Top)
            myDP.Children.Add(rect1)

            ' Add the second Rectangle to the DockPanel
            Dim rect2 As New Rectangle
            rect2.Stroke = Brushes.Black
            rect2.Fill = Brushes.SkyBlue
            rect2.Height = 25
            DockPanel.SetDock(rect2, Dock.Top)
            myDP.Children.Add(rect2)

            ' Add the third Rectangle to the DockPanel
            Dim rect3 As New Rectangle
            rect3.Stroke = Brushes.Black
            rect3.Fill = Brushes.Khaki
            rect3.Height = 25
            DockPanel.SetDock(rect3, Dock.Bottom)
            myDP.Children.Add(rect3)

            ' Add the fourth Rectangle to the DockPanel
            Dim rect4 As New Rectangle
            rect4.Stroke = Brushes.Black
            rect4.Fill = Brushes.PaleGreen
            rect4.Width = 200
            rect4.VerticalAlignment = VerticalAlignment.Stretch
            DockPanel.SetDock(rect4, Dock.Left)
            myDP.Children.Add(rect4)

            ' Add the fourth Rectangle to the DockPanel
            Dim rect5 As New Rectangle
            rect5.Stroke = Brushes.Black
            rect5.Fill = Brushes.White
            myDP.Children.Add(rect5)
            Me.Content = myDP
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
            Dim myContent As New DockPanel_VB()
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