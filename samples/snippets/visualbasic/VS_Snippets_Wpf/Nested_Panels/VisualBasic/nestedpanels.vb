Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class NestedPanels
        Inherits Page

        Public Sub New()
            WindowTitle = "Nested Panels Sample"
            Dim myBorder As New Border()
            myBorder.Width = 400
            myBorder.Height = 300
            myBorder.Background = Brushes.AliceBlue
            myBorder.BorderBrush = Brushes.DarkSlateBlue
            myBorder.BorderThickness = New Thickness(2)
            myBorder.HorizontalAlignment = HorizontalAlignment.Left
            myBorder.VerticalAlignment = VerticalAlignment.Top
            '<Snippet1>
            Dim myDockPanel As New DockPanel()

            Dim myBorder2 As New Border()
            myBorder2.BorderThickness = New Thickness(1)
            myBorder2.BorderBrush = Brushes.Black
            DockPanel.SetDock(myBorder2, Dock.Left)
            Dim myStackPanel As New StackPanel()
            Dim myButton1 As New Button()
            myButton1.Content = "Left Docked"
            myButton1.Margin = New Thickness(5)
            Dim myButton2 As New Button()
            myButton2.Content = "StackPanel"
            myButton2.Margin = New Thickness(5)
            myStackPanel.Children.Add(myButton1)
            myStackPanel.Children.Add(myButton2)
            myBorder2.Child = myStackPanel

            Dim myBorder3 As New Border()
            myBorder3.BorderThickness = New Thickness(1)
            myBorder3.BorderBrush = Brushes.Black
            DockPanel.SetDock(myBorder3, Dock.Top)
            Dim myGrid As New Grid()
            myGrid.ShowGridLines = True
            Dim myRowDef1 As New RowDefinition()
            Dim myRowDef2 As New RowDefinition()
            Dim myColDef1 As New ColumnDefinition()
            Dim myColDef2 As New ColumnDefinition()
            Dim myColDef3 As New ColumnDefinition()
            myGrid.ColumnDefinitions.Add(myColDef1)
            myGrid.ColumnDefinitions.Add(myColDef2)
            myGrid.ColumnDefinitions.Add(myColDef3)
            myGrid.RowDefinitions.Add(myRowDef1)
            myGrid.RowDefinitions.Add(myRowDef2)
            Dim myTextBlock1 As New TextBlock()
            myTextBlock1.FontSize = 20
            myTextBlock1.Margin = New Thickness(10)
            myTextBlock1.Text = "Grid Element Docked at the Top"
            Grid.SetRow(myTextBlock1, 0)
            Grid.SetColumnSpan(myTextBlock1, 3)
            Dim myButton3 As New Button()
            myButton3.Margin = New Thickness(5)
            myButton3.Content = "A Row"
            Grid.SetColumn(myButton3, 0)
            Grid.SetRow(myButton3, 1)
            Dim myButton4 As New Button()
            myButton4.Margin = New Thickness(5)
            myButton4.Content = "of Button"
            Grid.SetColumn(myButton4, 1)
            Grid.SetRow(myButton4, 1)
            Dim myButton5 As New Button()
            myButton5.Margin = New Thickness(5)
            myButton5.Content = "Elements"
            Grid.SetColumn(myButton5, 2)
            Grid.SetRow(myButton5, 1)
            myGrid.Children.Add(myTextBlock1)
            myGrid.Children.Add(myButton3)
            myGrid.Children.Add(myButton4)
            myGrid.Children.Add(myButton5)
            myBorder3.Child = myGrid

            Dim myBorder4 As New Border()
            myBorder4.BorderBrush = Brushes.Black
            myBorder4.BorderThickness = New Thickness(1)
            DockPanel.SetDock(myBorder4, Dock.Bottom)
            Dim myStackPanel2 As New StackPanel()
            myStackPanel2.Orientation = Orientation.Horizontal
            Dim myTextBlock2 As New TextBlock()
            myTextBlock2.Text = "This StackPanel is Docked to the Bottom"
            myTextBlock2.Margin = New Thickness(5)
            myStackPanel2.Children.Add(myTextBlock2)
            myBorder4.Child = myStackPanel2

            Dim myBorder5 As New Border()
            myBorder5.BorderBrush = Brushes.Black
            myBorder5.BorderThickness = New Thickness(1)
            Dim myCanvas As New Canvas()
            myCanvas.ClipToBounds = True
            Dim myTextBlock3 As New TextBlock()
            myTextBlock3.Text = "Content in the Canvas will Fill the remaining space."
            Canvas.SetTop(myTextBlock3, 50)
            Canvas.SetLeft(myTextBlock3, 50)
            Dim myEllipse As New Ellipse()
            myEllipse.Height = 100
            myEllipse.Width = 125
            myEllipse.Fill = Brushes.CornflowerBlue
            myEllipse.Stroke = Brushes.Aqua
            Canvas.SetTop(myEllipse, 100)
            Canvas.SetLeft(myEllipse, 150)
            myCanvas.Children.Add(myTextBlock3)
            myCanvas.Children.Add(myEllipse)
            myBorder5.Child = myCanvas

            myDockPanel.Children.Add(myBorder2)
            myDockPanel.Children.Add(myBorder3)
            myDockPanel.Children.Add(myBorder4)
            myDockPanel.Children.Add(myBorder5)
            '</Snippet1>
            myBorder.Child = myDockPanel
            Me.Content = myBorder

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
            Dim myContent As New NestedPanels()
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
