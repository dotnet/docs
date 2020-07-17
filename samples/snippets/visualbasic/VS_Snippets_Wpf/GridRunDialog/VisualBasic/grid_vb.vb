Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class Window1
        Inherits Page

        Public Sub New()
            WindowTitle = "Grid Run Dialog Sample Sample"
            '<Snippet1>
            
            'Create a Grid as the root Panel element.
            Dim myGrid As New Grid()
            myGrid.Height = 165
            myGrid.Width = 425
            myGrid.Background = Brushes.Gainsboro
            myGrid.ShowGridLines = True
            myGrid.HorizontalAlignment = Windows.HorizontalAlignment.Left
            myGrid.VerticalAlignment = Windows.VerticalAlignment.Top

            ' Define and Add the Rows and Columns.
            Dim colDef1 As New ColumnDefinition
            colDef1.Width = New GridLength(1, GridUnitType.Auto)
            Dim colDef2 As New ColumnDefinition
            colDef2.Width = New GridLength(1, GridUnitType.Star)
            Dim colDef3 As New ColumnDefinition
            colDef3.Width = New GridLength(1, GridUnitType.Star)
            Dim colDef4 As New ColumnDefinition
            colDef4.Width = New GridLength(1, GridUnitType.Star)
            Dim colDef5 As New ColumnDefinition
            colDef5.Width = New GridLength(1, GridUnitType.Star)
            myGrid.ColumnDefinitions.Add(colDef1)
            myGrid.ColumnDefinitions.Add(colDef2)
            myGrid.ColumnDefinitions.Add(colDef3)
            myGrid.ColumnDefinitions.Add(colDef4)
            myGrid.ColumnDefinitions.Add(colDef5)

            Dim rowDef1 As New RowDefinition
            rowDef1.Height = New GridLength(1, GridUnitType.Auto)
            Dim rowDef2 As New RowDefinition
            rowDef2.Height = New GridLength(1, GridUnitType.Auto)
            Dim rowDef3 As New Controls.RowDefinition
            rowDef3.Height = New GridLength(1, GridUnitType.Star)
            Dim rowDef4 As New RowDefinition
            rowDef4.Height = New GridLength(1, GridUnitType.Auto)
            myGrid.RowDefinitions.Add(rowDef1)
            myGrid.RowDefinitions.Add(rowDef2)
            myGrid.RowDefinitions.Add(rowDef3)
            myGrid.RowDefinitions.Add(rowDef4)

            ' Add the Image.
            Dim img1 As New Image
            img1.Source = New System.Windows.Media.Imaging.BitmapImage(New Uri("runicon.png", UriKind.Relative))
            Grid.SetRow(img1, 0)
            Grid.SetColumn(img1, 0)
            myGrid.Children.Add(img1)

            ' Add the main application dialog.
            Dim txt1 As New TextBlock
            txt1.Text = "Type the name of a program, document, or Internet resource, and Windows will open it for you."
            txt1.TextWrapping = TextWrapping.Wrap
            Grid.SetColumnSpan(txt1, 4)
            Grid.SetRow(txt1, 0)
            Grid.SetColumn(txt1, 1)
            myGrid.Children.Add(txt1)

            ' Add the second TextBlock Cell to the Grid.
            Dim txt2 As New TextBlock
            txt2.Text = "Open:"
            Grid.SetRow(txt2, 1)
            Grid.SetColumn(txt2, 0)
            myGrid.Children.Add(txt2)

            ' Add the TextBox control.
            Dim tb1 As New TextBox
            Grid.SetRow(tb1, 1)
            Grid.SetColumn(tb1, 1)
            Grid.SetColumnSpan(tb1, 5)
            myGrid.Children.Add(tb1)

            ' Add the Button controls.
            Dim button1 As New Button
            Dim button2 As New Button
            Dim button3 As New Button
            button1.Content = "OK"
            button1.Margin = New Thickness(10, 0, 10, 15)
            button2.Content = "Cancel"
            button2.Margin = New Thickness(10, 0, 10, 15)
            button3.Content = "Browse ..."
            button3.Margin = New Thickness(10, 0, 10, 15)

            Grid.SetRow(button1, 3)
            Grid.SetColumn(button1, 2)
            Grid.SetRow(button2, 3)
            Grid.SetColumn(button2, 3)
            Grid.SetRow(button3, 3)
            Grid.SetColumn(button3, 4)
            myGrid.Children.Add(button1)
            myGrid.Children.Add(button2)
            myGrid.Children.Add(button3)

            Me.Content = myGrid
            '</Snippet1>
        End Sub
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
                Dim myContent As New Window1()
                myWindow.Navigate(myContent)
                myWindow.Height = 225
                myWindow.Width = 425
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
    End Class
End Namespace