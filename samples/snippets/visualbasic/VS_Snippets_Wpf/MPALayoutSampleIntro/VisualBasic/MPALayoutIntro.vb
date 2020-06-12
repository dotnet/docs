Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class PositioningProps
        Inherits Page

        Public Sub New()
            '<Snippet1>
            WindowTitle = "Margins, Padding and Alignment Sample"

            'Add a Border.
            Dim myBorder As New Border()
            myBorder.Background = Brushes.LightBlue
            myBorder.BorderBrush = Brushes.Black
            myBorder.Padding = New Thickness(15)
            myBorder.BorderThickness = New Thickness(2)

            Dim myStackPanel As New StackPanel()
            myStackPanel.Background = Brushes.White
            myStackPanel.HorizontalAlignment = Windows.HorizontalAlignment.Center
            myStackPanel.VerticalAlignment = Windows.VerticalAlignment.Top

            Dim myTextBlock As New TextBlock()
            myTextBlock.Margin = New Thickness(5, 0, 5, 0)
            myTextBlock.FontSize = 18
            myTextBlock.HorizontalAlignment = Windows.HorizontalAlignment.Center
            myTextBlock.Text = "Alignment, Margin and Padding Sample"
            Dim myButton1 As New Button()
            myButton1.HorizontalAlignment = Windows.HorizontalAlignment.Left
            myButton1.Margin = New Thickness(20)
            myButton1.Content = "Button 1"
            Dim myButton2 As New Button()
            myButton2.HorizontalAlignment = Windows.HorizontalAlignment.Right
            myButton2.Margin = New Thickness(10)
            myButton2.Content = "Button 2"
            Dim myButton3 As New Button()
            myButton3.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
            myButton3.Margin = New Thickness(0)
            myButton3.Content = "Button 3"

            'Add child elements to the parent StackPanel.
            myStackPanel.Children.Add(myTextBlock)
            myStackPanel.Children.Add(myButton1)
            myStackPanel.Children.Add(myButton2)
            myStackPanel.Children.Add(myButton3)

            'Add the StackPanel as the lone Child of the Border.
            myBorder.Child = myStackPanel

            ' Add the Canvas as the lone Child of the Border
            myBorder.Child = myStackPanel
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