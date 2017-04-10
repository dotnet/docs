Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Threading

Namespace SDKSample

    Public Class StackPanelSamp
        Inherits Page

        Public Sub New()

            WindowTitle = "StackPanel vs. DockPanel"

            '<Snippet1>

            'Add root Grid
            Dim myGrid As New Grid
            myGrid.Width = 175
            myGrid.Height = 150
            Dim myRowDef1 As New RowDefinition
            Dim myRowDef2 As New RowDefinition
            myGrid.RowDefinitions.Add(myRowDef1)
            myGrid.RowDefinitions.Add(myRowDef2)

            'Define the DockPanel
            Dim myDockPanel As New DockPanel
            Grid.SetRow(myDockPanel, 0)

            'Define an Image and Source.
            Dim myImage As New Image
            Dim bi As New BitmapImage
            bi.BeginInit()
            bi.UriSource = New Uri("smiley_stackpanel.png", UriKind.Relative)
            bi.EndInit()
            myImage.Source = bi

            Dim myImage2 As New Image
            Dim bi2 As New BitmapImage
            bi2.BeginInit()
            bi2.UriSource = New Uri("smiley_stackpanel.png", UriKind.Relative)
            bi2.EndInit()
            myImage2.Source = bi2

            '<Snippet3>
            Dim myImage3 As New Image
            Dim bi3 As New BitmapImage
            bi3.BeginInit()
            bi3.UriSource = New Uri("smiley_stackpanel.PNG", UriKind.Relative)
            bi3.EndInit()
            myImage3.Stretch = Stretch.Fill
            myImage3.Source = bi3
            '</Snippet3>

            'Add the images to the parent DockPanel.
            myDockPanel.Children.Add(myImage)
            myDockPanel.Children.Add(myImage2)
            myDockPanel.Children.Add(myImage3)

            'Define a StackPanel.
            Dim myStackPanel As New StackPanel
            myStackPanel.Orientation = Orientation.Horizontal
            Grid.SetRow(myStackPanel, 1)

            Dim myImage4 As New Image
            Dim bi4 As New BitmapImage
            bi4.BeginInit()
            bi4.UriSource = New Uri("smiley_stackpanel.png", UriKind.Relative)
            bi4.EndInit()
            myImage4.Source = bi4

            Dim myImage5 As New Image
            Dim bi5 As New BitmapImage
            bi5.BeginInit()
            bi5.UriSource = New Uri("smiley_stackpanel.png", UriKind.Relative)
            bi5.EndInit()
            myImage5.Source = bi5

            Dim myImage6 As New Image
            Dim bi6 As New BitmapImage
            bi6.BeginInit()
            bi6.UriSource = New Uri("smiley_stackpanel.PNG", UriKind.Relative)
            bi6.EndInit()
            myImage6.Stretch = Stretch.Fill
            myImage6.Source = bi6

            'Add the images to the parent StackPanel.
            myStackPanel.Children.Add(myImage4)
            myStackPanel.Children.Add(myImage5)
            myStackPanel.Children.Add(myImage6)

            'Add the layout panels as children of the Grid
            myGrid.Children.Add(myDockPanel)
            myGrid.Children.Add(myStackPanel)

            '</Snippet1>
            Me.Content = myGrid
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
            Dim myContent As New StackPanelSamp()
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

