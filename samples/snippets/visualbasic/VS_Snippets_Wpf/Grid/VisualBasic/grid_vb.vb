Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class Window1
        Inherits Page

        '<Snippet3>
        Public Sub New()
            WindowTitle = "Grid Sample"
            'Create a Grid as the root Panel element
            Dim myGrid As New Grid()
            myGrid.Height = 100
            myGrid.Width = 250
            myGrid.ShowGridLines = True
            myGrid.HorizontalAlignment = Windows.HorizontalAlignment.Left
            myGrid.VerticalAlignment = Windows.VerticalAlignment.Top

            ' Define and Add the Rows and Columns
            Dim colDef1 As New ColumnDefinition
            Dim colDef2 As New ColumnDefinition
            Dim colDef3 As New ColumnDefinition
            myGrid.ColumnDefinitions.Add(colDef1)
            myGrid.ColumnDefinitions.Add(colDef2)
            myGrid.ColumnDefinitions.Add(colDef3)

            Dim rowDef1 As New RowDefinition
            Dim rowDef2 As New RowDefinition
            Dim rowDef3 As New RowDefinition
            Dim rowDef4 As New RowDefinition
            myGrid.RowDefinitions.Add(rowDef1)
            myGrid.RowDefinitions.Add(rowDef2)
            myGrid.RowDefinitions.Add(rowDef3)
            myGrid.RowDefinitions.Add(rowDef4)

            Dim txt1 As New TextBlock
            txt1.Text = "2004 Products Shipped"
            txt1.FontSize = 20
            txt1.FontWeight = FontWeights.Bold
            Grid.SetColumnSpan(txt1, 3)
            Grid.SetRow(txt1, 0)
            myGrid.Children.Add(txt1)

            Dim txt2 As New TextBlock
            txt2.Text = "Quarter 1"
            txt2.FontSize = 12
            txt2.FontWeight = FontWeights.Bold
            Grid.SetRow(txt2, 1)
            Grid.SetColumn(txt2, 0)
            myGrid.Children.Add(txt2)

            Dim txt3 As New TextBlock
            txt3.Text = "Quarter 2"
            txt3.FontSize = 12
            txt3.FontWeight = FontWeights.Bold
            Grid.SetRow(txt3, 1)
            Grid.SetColumn(txt3, 1)
            myGrid.Children.Add(txt3)

            Dim txt4 As New TextBlock
            txt4.Text = "Quarter 3"
            txt4.FontSize = 12
            txt4.FontWeight = FontWeights.Bold
            Grid.SetRow(txt4, 1)
            Grid.SetColumn(txt4, 2)
            myGrid.Children.Add(txt4)

            Dim txt5 As New TextBlock
            txt5.Text = "50,000"
            Grid.SetRow(txt5, 2)
            Grid.SetColumn(txt5, 0)
            myGrid.Children.Add(txt5)

            Dim txt6 As New Controls.TextBlock
            txt6.Text = "100,000"
            Grid.SetRow(txt6, 2)
            Grid.SetColumn(txt6, 1)
            myGrid.Children.Add(txt6)

            Dim txt7 As New TextBlock
            txt7.Text = "150,000"
            Grid.SetRow(txt7, 2)
            Grid.SetColumn(txt7, 2)
            myGrid.Children.Add(txt7)

            ' Add the final TextBlock Cell to the Grid
            Dim txt8 As New TextBlock
            txt8.FontSize = 16
            txt8.FontWeight = FontWeights.Bold
            txt8.Text = "Total Units: 300000"
            Grid.SetRow(txt8, 3)
            Grid.SetColumnSpan(txt8, 3)
            myGrid.Children.Add(txt8)

            Me.Content = myGrid
        End Sub
        '</Snippet3>
        
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
                Dim myContent As New Window1()
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
    End Class
End Namespace