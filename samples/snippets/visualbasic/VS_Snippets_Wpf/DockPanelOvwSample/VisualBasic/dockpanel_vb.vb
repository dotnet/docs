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
            Dim myDockPanel As New DockPanel()
            myDockPanel.LastChildFill = True

            ' Define the child content
            Dim myBorder1 As New Border()
            myBorder1.Height = 25
            myBorder1.Background = Brushes.SkyBlue
            myBorder1.BorderBrush = Brushes.Black
            myBorder1.BorderThickness = New Thickness(1)
            DockPanel.SetDock(myBorder1, Dock.Top)
            Dim myTextBlock1 As New TextBlock()
            myTextBlock1.Foreground = Brushes.Black
            myTextBlock1.Text = "Dock = Top"
            myBorder1.Child = myTextBlock1

            Dim myBorder2 As New Border()
            myBorder2.Height = 25
            myBorder2.Background = Brushes.SkyBlue
            myBorder2.BorderBrush = Brushes.Black
            myBorder2.BorderThickness = New Thickness(1)
            DockPanel.SetDock(myBorder2, Dock.Top)
            Dim myTextBlock2 As New TextBlock()
            myTextBlock2.Foreground = Brushes.Black
            myTextBlock2.Text = "Dock = Top"
            myBorder2.Child = myTextBlock2

            Dim myBorder3 As New Border()
            myBorder3.Height = 25
            myBorder3.Background = Brushes.LemonChiffon
            myBorder3.BorderBrush = Brushes.Black
            myBorder3.BorderThickness = New Thickness(1)
            DockPanel.SetDock(myBorder3, Dock.Bottom)
            Dim myTextBlock3 As New TextBlock()
            myTextBlock3.Foreground = Brushes.Black
            myTextBlock3.Text = "Dock = Bottom"
            myBorder3.Child = myTextBlock3

            Dim myBorder4 As New Border()
            myBorder4.Width = 200
            myBorder4.Background = Brushes.PaleGreen
            myBorder4.BorderBrush = Brushes.Black
            myBorder4.BorderThickness = New Thickness(1)
            DockPanel.SetDock(myBorder4, Dock.Left)
            Dim myTextBlock4 As New TextBlock()
            myTextBlock4.Foreground = Brushes.Black
            myTextBlock4.Text = "Dock = Left"
            myBorder4.Child = myTextBlock4

            Dim myBorder5 As New Border()
            myBorder5.Background = Brushes.White
            myBorder5.BorderBrush = Brushes.Black
            myBorder5.BorderThickness = New Thickness(1)
            Dim myTextBlock5 As New TextBlock()
            myTextBlock5.Foreground = Brushes.Black
            myTextBlock5.Text = "This content will Fill the remaining space"
            myBorder5.Child = myTextBlock5

            ' Add child elements to the DockPanel Children collection
            myDockPanel.Children.Add(myBorder1)
            myDockPanel.Children.Add(myBorder2)
            myDockPanel.Children.Add(myBorder3)
            myDockPanel.Children.Add(myBorder4)
            myDockPanel.Children.Add(myBorder5)
            Me.Content = myDockPanel
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