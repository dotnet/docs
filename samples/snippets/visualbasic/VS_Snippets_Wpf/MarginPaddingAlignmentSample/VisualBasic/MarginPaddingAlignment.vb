Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Threading

Namespace SDKSample

    Public Class MarginPaddingAlignment
        Inherits Page

        Public Sub New()

            WindowTitle = "Margin, Padding and Alignment Sample"

            '<Snippet4>  

            '<Snippet3>
            Dim myBorder As New Border
            myBorder.Background = Brushes.LightBlue
            myBorder.BorderBrush = Brushes.Black
            myBorder.BorderThickness = New Thickness(2)
            myBorder.CornerRadius = New CornerRadius(45)
            myBorder.Padding = New Thickness(25)
            '</Snippet3>

            'Define the Grid.
            Dim myGrid As New Grid
            myGrid.Background = Brushes.White
            myGrid.ShowGridLines = True

            'Define the Columns.
            Dim myColDef1 As New ColumnDefinition
            myColDef1.Width = New GridLength(1, GridUnitType.Auto)
            Dim myColDef2 As New ColumnDefinition
            myColDef2.Width = New GridLength(1, GridUnitType.Star)
            Dim myColDef3 As New ColumnDefinition
            myColDef3.Width = New GridLength(1, GridUnitType.Auto)

            'Add the ColumnDefinitions to the Grid
            myGrid.ColumnDefinitions.Add(myColDef1)
            myGrid.ColumnDefinitions.Add(myColDef2)
            myGrid.ColumnDefinitions.Add(myColDef3)

            'Add the first child StackPanel.
            Dim myStackPanel As New StackPanel
            myStackPanel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            myStackPanel.VerticalAlignment = System.Windows.VerticalAlignment.Top
            Grid.SetColumn(myStackPanel, 0)
            Grid.SetRow(myStackPanel, 0)
            Dim myTextBlock1 As New TextBlock
            myTextBlock1.FontSize = 18
            myTextBlock1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            myTextBlock1.Margin = New Thickness(0, 0, 0, 15)
            myTextBlock1.Text = "StackPanel 1"

            '<Snippet2>
            Dim myButton1 As New Button
            myButton1.Margin = New Thickness(0, 10, 0, 10)
            myButton1.Content = "Button 1"
            Dim myButton2 As New Button
            myButton2.Margin = New Thickness(0, 10, 0, 10)
            myButton2.Content = "Button 2"
            Dim myButton3 As New Button
            myButton3.Margin = New Thickness(0, 10, 0, 10)
            '</Snippet2>

            Dim myTextBlock2 As New TextBlock
            myTextBlock2.Text = "ColumnDefinition.Width = ""Auto"""
            Dim myTextBlock3 As New TextBlock
            myTextBlock3.Text = "StackPanel.HorizontalAlignment = ""Left"""
            Dim myTextBlock4 As New TextBlock
            myTextBlock4.Text = "StackPanel.VerticalAlignment = ""Top"""
            Dim myTextBlock5 As New TextBlock
            myTextBlock5.Text = "StackPanel.Orientation = ""Vertical"""
            Dim myTextBlock6 As New TextBlock
            myTextBlock6.Text = "Button.Margin = ""1,10,0,10"""
            myStackPanel.Children.Add(myTextBlock1)
            myStackPanel.Children.Add(myButton1)
            myStackPanel.Children.Add(myButton2)
            myStackPanel.Children.Add(myButton3)
            myStackPanel.Children.Add(myTextBlock2)
            myStackPanel.Children.Add(myTextBlock3)
            myStackPanel.Children.Add(myTextBlock4)
            myStackPanel.Children.Add(myTextBlock5)
            myStackPanel.Children.Add(myTextBlock6)

            'Add the second child StackPanel.
            Dim myStackPanel2 As New StackPanel
            myStackPanel2.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch
            myStackPanel2.VerticalAlignment = System.Windows.VerticalAlignment.Top
            myStackPanel2.Orientation = Orientation.Vertical
            Grid.SetColumn(myStackPanel2, 1)
            Grid.SetRow(myStackPanel2, 0)
            Dim myTextBlock7 As New TextBlock
            myTextBlock7.FontSize = 18
            myTextBlock7.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            myTextBlock7.Margin = New Thickness(0, 0, 0, 15)
            myTextBlock7.Text = "StackPanel 2"
            Dim myButton4 As New Button
            myButton4.Margin = New Thickness(10, 0, 10, 0)
            myButton4.Content = "Button 4"
            Dim myButton5 As New Button
            myButton5.Margin = New Thickness(10, 0, 10, 0)
            myButton5.Content = "Button 5"
            Dim myButton6 As New Button
            myButton6.Margin = New Thickness(10, 0, 10, 0)
            myButton6.Content = "Button 6"
            Dim myTextBlock8 As New TextBlock
            myTextBlock8.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            myTextBlock8.Text = "ColumnDefinition.Width = ""*"""
            Dim myTextBlock9 As New TextBlock
            myTextBlock9.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            myTextBlock9.Text = "StackPanel.HorizontalAlignment = ""Stretch"""
            Dim myTextBlock10 As New TextBlock
            myTextBlock10.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            myTextBlock10.Text = "StackPanel.VerticalAlignment = ""Top"""
            Dim myTextBlock11 As New TextBlock
            myTextBlock11.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            myTextBlock11.Text = "StackPanel.Orientation = ""Horizontal"""
            Dim myTextBlock12 As New TextBlock
            myTextBlock12.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            myTextBlock12.Text = "Button.Margin = ""10,0,10,0"""
            myStackPanel2.Children.Add(myTextBlock7)
            myStackPanel2.Children.Add(myButton4)
            myStackPanel2.Children.Add(myButton5)
            myStackPanel2.Children.Add(myButton6)
            myStackPanel2.Children.Add(myTextBlock8)
            myStackPanel2.Children.Add(myTextBlock9)
            myStackPanel2.Children.Add(myTextBlock10)
            myStackPanel2.Children.Add(myTextBlock11)
            myStackPanel2.Children.Add(myTextBlock12)

            'Add the final child StackPanel.
            Dim myStackPanel3 As New StackPanel
            myStackPanel3.HorizontalAlignment = System.Windows.HorizontalAlignment.Left
            myStackPanel3.VerticalAlignment = System.Windows.VerticalAlignment.Top
            Grid.SetColumn(myStackPanel3, 2)
            Grid.SetRow(myStackPanel3, 0)
            Dim myTextBlock13 As New TextBlock
            myTextBlock13.FontSize = 18
            myTextBlock13.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            myTextBlock13.Margin = New Thickness(0, 0, 0, 15)
            myTextBlock13.Text = "StackPanel 3"

            '<Snippet1>
            Dim myButton7 As New Button
            myButton7.Margin = New Thickness(10)
            myButton7.Content = "Button 7"
            Dim myButton8 As New Button
            myButton8.Margin = New Thickness(10)
            myButton8.Content = "Button 8"
            Dim myButton9 As New Button
            myButton9.Margin = New Thickness(10)
            myButton9.Content = "Button 9"
            '</Snippet1>
            Dim myTextBlock14 As New TextBlock
            myTextBlock14.Text = "ColumnDefinition.Width = ""Auto"""
            Dim myTextBlock15 As New TextBlock
            myTextBlock15.Text = "StackPanel.HorizontalAlignment = ""Left"""
            Dim myTextBlock16 As New TextBlock
            myTextBlock16.Text = "StackPanel.VerticalAlignment = ""Top"""
            Dim myTextBlock17 As New TextBlock
            myTextBlock17.Text = "StackPanel.Orientation = ""Vertical"""
            Dim myTextBlock18 As New TextBlock
            myTextBlock18.Text = "Button.Margin = ""10"""
            myStackPanel3.Children.Add(myTextBlock13)
            myStackPanel3.Children.Add(myButton7)
            myStackPanel3.Children.Add(myButton8)
            myStackPanel3.Children.Add(myButton9)
            myStackPanel3.Children.Add(myTextBlock14)
            myStackPanel3.Children.Add(myTextBlock15)
            myStackPanel3.Children.Add(myTextBlock16)
            myStackPanel3.Children.Add(myTextBlock17)
            myStackPanel3.Children.Add(myTextBlock18)

            'Add child content to the parent Grid.
            myGrid.Children.Add(myStackPanel)
            myGrid.Children.Add(myStackPanel2)
            myGrid.Children.Add(myStackPanel3)

            'Add the Grid as the lone child of the Border.
            myBorder.Child = myGrid

            '</Snippet4>

            Me.Content = myBorder
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
            Dim myContent As New MarginPaddingAlignment()
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

