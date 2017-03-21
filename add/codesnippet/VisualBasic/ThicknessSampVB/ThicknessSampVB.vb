Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Threading

Namespace SDKSample

    Public Class ThicknessSampVB
        Inherits Page

        Public Sub New()

            WindowTitle = "Thickness Sample"
            ' Create a Border

	    '<Snippet1>
            Dim myBorder1 As New Border()
            myBorder1.BorderBrush = Brushes.SlateBlue
            myBorder1.BorderThickness = New Thickness(5, 10, 15, 20)
            myBorder1.Background = Brushes.AliceBlue
            myBorder1.Padding = New Thickness(5)
            myBorder1.CornerRadius = New CornerRadius(15)
	    '</Snippet1>

            Dim myCanvas As New Canvas()
            myCanvas.Background = Brushes.LightSteelBlue
            myBorder1.Child = myCanvas

	    '<Snippet2>
            Dim myBorder2 As New Border()
            myBorder2.BorderBrush = Brushes.SteelBlue
            myBorder2.Width = 400
            myBorder2.Height = 400
            Dim myThickness As New Thickness()
            myThickness.Bottom = 5
            myThickness.Left = 10
            myThickness.Right = 15
            myThickness.Top = 20
            myBorder2.BorderThickness = myThickness
	    '</Snippet2>

            myCanvas.Children.Add(myBorder2)
            Canvas.SetLeft(myBorder2, 100)
            Canvas.SetTop(myBorder2, 100)

            Me.Content = myBorder1
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
            Dim myContent As New ThicknessSampVB()
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

