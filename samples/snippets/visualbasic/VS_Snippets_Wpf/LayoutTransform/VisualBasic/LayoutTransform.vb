Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation
Imports System.Threading

Namespace SDKSample

    Public Class LayoutTransformVB
        Inherits Page

        Public Sub New()

            WindowTitle = "LayoutTransform Sample"
            ' Create a Grid as the Root Panel
            Dim grid1 As New Grid()
            grid1.HorizontalAlignment = Windows.HorizontalAlignment.Left
            grid1.VerticalAlignment = Windows.VerticalAlignment.Top
            grid1.ShowGridLines = True

            Dim colDef1 As New ColumnDefinition()
            colDef1.Width = GridLength.Auto
            Dim colDef2 As New ColumnDefinition()
            colDef2.Width = GridLength.Auto
            grid1.ColumnDefinitions.Add(colDef1)
            grid1.ColumnDefinitions.Add(colDef2)

            Dim rowDef1 As New RowDefinition()
            rowDef1.Height = GridLength.Auto
            Dim rowDef2 As New RowDefinition()
            rowDef2.Height = GridLength.Auto
            Dim rowDef3 As New RowDefinition()
            rowDef3.Height = GridLength.Auto
            Dim rowDef4 As New RowDefinition()
            rowDef4.Height = GridLength.Auto
            Dim rowDef5 As New RowDefinition()
            rowDef5.Height = GridLength.Auto
            Dim rowDef6 As New RowDefinition()
            rowDef6.Height = GridLength.Auto
            grid1.RowDefinitions.Add(rowDef1)
            grid1.RowDefinitions.Add(rowDef2)
            grid1.RowDefinitions.Add(rowDef3)
            grid1.RowDefinitions.Add(rowDef4)
            grid1.RowDefinitions.Add(rowDef5)
            grid1.RowDefinitions.Add(rowDef6)

            ' RotateTransform Sample
            Dim btn1 As New Button()
            btn1.Background = Brushes.LightCoral
            btn1.Content = "No Transform Applied"
            Grid.SetRow(btn1, 0)
            Grid.SetColumn(btn1, 0)
            grid1.Children.Add(btn1)

            ' <Snippet1>

            Dim btn2 As New Button()
            btn2.Background = Brushes.LightCoral
            btn2.Content = "RotateTransform"
            btn2.LayoutTransform = New RotateTransform(45, 25, 25)
            Grid.SetRow(btn2, 0)
            Grid.SetColumn(btn2, 1)
            grid1.Children.Add(btn2)

            ' </Snippet1>

            ' SkewTransform Sample
            Dim btn3 As New Button()
            btn3.Background = Brushes.LightCyan
            btn3.Content = "No Transform Applied"
            Grid.SetRow(btn3, 1)
            Grid.SetColumn(btn3, 0)
            grid1.Children.Add(btn3)

            Dim btn4 As New Button()
            btn4.Background = Brushes.LightCyan
            btn4.Content = "SkewTransform"
            btn4.LayoutTransform = New SkewTransform(45, 0, 0, 0)
            Grid.SetRow(btn4, 1)
            Grid.SetColumn(btn4, 1)
            grid1.Children.Add(btn4)

            ' ScaleTransform Sample
            Dim btn5 As New Button()
            btn5.Background = Brushes.LightSlateGray
            btn5.Content = "No Transform Applied"
            Grid.SetRow(btn5, 2)
            Grid.SetColumn(btn5, 0)
            grid1.Children.Add(btn5)

            Dim btn6 As New Button()
            btn6.Background = Brushes.LightSlateGray
            btn6.Content = "ScaleTransform"
            btn6.LayoutTransform = New ScaleTransform(2, 2, 25, 25)
            Grid.SetRow(btn6, 2)
            Grid.SetColumn(btn6, 1)
            grid1.Children.Add(btn6)

            ' TranslateTransform Sample
            Dim btn7 As New Button()
            btn7.Background = Brushes.LightSeaGreen
            btn7.Content = "No Transform Applied"
            Grid.SetRow(btn7, 3)
            Grid.SetColumn(btn7, 0)
            grid1.Children.Add(btn7)

            Dim btn8 As New Button()
            btn8.Background = Brushes.LightSeaGreen
            btn8.Content = "TranslateTransform: RenderTransform"
            btn8.RenderTransform = New TranslateTransform(100, 200)
            Grid.SetRow(btn8, 3)
            Grid.SetColumn(btn8, 1)
            grid1.Children.Add(btn8)

            ' TranslateTransform Sample
            Dim btn9 As New Button()
            btn9.Background = Brushes.LightBlue
            btn9.Content = "No Transform Applied"
            Grid.SetRow(btn9, 4)
            Grid.SetColumn(btn9, 0)
            grid1.Children.Add(btn9)

            Dim btn10 As New Button()
            btn10.Background = Brushes.LightBlue
            btn10.Content = "TranslateTransform: LayoutTransform"
            btn10.LayoutTransform = New TranslateTransform(100, 200)
            Grid.SetRow(btn10, 4)
            Grid.SetColumn(btn10, 1)
            grid1.Children.Add(btn10)

            ' MatrixTransform Sample
            Dim btn11 As New Button()
            btn11.Background = Brushes.LightGoldenrodYellow
            btn11.Content = "No Transform Applied"
            Grid.SetRow(btn11, 5)
            Grid.SetColumn(btn11, 0)
            grid1.Children.Add(btn11)

            Dim btn12 As New Button()
            btn12.Background = Brushes.LightGoldenrodYellow
            btn12.Content = "MatrixTransform"
            btn12.LayoutTransform = New MatrixTransform(1, 3, 3, 3, 3, 3)
            Grid.SetRow(btn12, 5)
            Grid.SetColumn(btn12, 1)
            grid1.Children.Add(btn12)

            Me.Content = grid1
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
            Dim myContent As New LayoutTransformVB()
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

