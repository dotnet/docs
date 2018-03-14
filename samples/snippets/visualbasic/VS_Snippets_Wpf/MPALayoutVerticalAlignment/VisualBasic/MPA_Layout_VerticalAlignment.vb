Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class PositioningProps
        Inherits Page

        Public Sub New()
            '<Snippet1>
            WindowTitle = "VerticalAlignment Sample"

            'Add a Border.
            Dim myBorder As New Border()
            myBorder.Background = Brushes.LightBlue
            myBorder.BorderBrush = Brushes.Black
            myBorder.Padding = New Thickness(15)
            myBorder.BorderThickness = New Thickness(2)

            Dim myGrid As New Grid()
            myGrid.Background = Brushes.White
            myGrid.ShowGridLines = True
            Dim myRowDef1 As New RowDefinition()
            myRowDef1.Height = New GridLength(25)
            Dim myRowDef2 As New RowDefinition()
            myRowDef2.Height = New GridLength(50)
            Dim myRowDef3 As New RowDefinition()
            myRowDef3.Height = New GridLength(50)
            Dim myRowDef4 As New RowDefinition()
            myRowDef4.Height = New GridLength(50)
            Dim myRowDef5 As New RowDefinition()
            myRowDef5.Height = New GridLength(50)
            myGrid.RowDefinitions.Add(myRowDef1)
            myGrid.RowDefinitions.Add(myRowDef2)
            myGrid.RowDefinitions.Add(myRowDef3)
            myGrid.RowDefinitions.Add(myRowDef4)
            myGrid.RowDefinitions.Add(myRowDef5)

            '<Snippet2>
            Dim myTextBlock As New TextBlock()
            myTextBlock.FontSize = 18
            myTextBlock.HorizontalAlignment = Windows.HorizontalAlignment.Center
            myTextBlock.Text = "VerticalAlignment Sample"
            Grid.SetRow(myTextBlock, 0)
            Dim myButton1 As New Button()
            myButton1.VerticalAlignment = Windows.VerticalAlignment.Top
            myButton1.Content = "Button 1 (Top)"
            Grid.SetRow(myButton1, 1)
            Dim myButton2 As New Button()
            myButton2.VerticalAlignment = Windows.VerticalAlignment.Bottom
            myButton2.Content = "Button 2 (Bottom)"
            Grid.SetRow(myButton2, 2)
            Dim myButton3 As New Button()
            myButton3.VerticalAlignment = Windows.VerticalAlignment.Center
            myButton3.Content = "Button 3 (Center)"
            Grid.SetRow(myButton3, 3)
            Dim myButton4 As New Button()
            myButton4.VerticalAlignment = Windows.VerticalAlignment.Stretch
            myButton4.Content = "Button 4 (Stretch)"
            Grid.SetRow(myButton4, 4)
            '</Snippet2>

            'Add child elements to the parent Grid.
            myGrid.Children.Add(myTextBlock)
            myGrid.Children.Add(myButton1)
            myGrid.Children.Add(myButton2)
            myGrid.Children.Add(myButton3)
            myGrid.Children.Add(myButton4)

            ' Add the Grid as the lone Child of the Border.
            myBorder.Child = myGrid
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
            Dim myContent As New PositioningProps()
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