Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class WrapPanel_VB
        Inherits Page

        Public Sub New()
            '<Snippet1>
            WindowTitle = "WrapPanel Sample"
            '<Snippet2>

            ' Instantiate a new WrapPanel and set properties
            Dim myWrapPanel As New WrapPanel()
            myWrapPanel.Background = Brushes.Azure
            myWrapPanel.Orientation = Orientation.Horizontal

            myWrapPanel.Width = 200
            myWrapPanel.HorizontalAlignment = Windows.HorizontalAlignment.Left
            myWrapPanel.VerticalAlignment = Windows.VerticalAlignment.Top

            ' Define 3 button elements. The last three buttons are sized at width 
            ' of 75, so the forth button wraps to the next line.
            Dim btn1 As New Button()
            btn1.Content = "Button 1"
            btn1.Width = 200
            Dim btn2 As New Button()
            btn2.Content = "Button 2"
            btn2.Width = 75
            Dim btn3 As New Button()
            btn3.Content = "Button 3"
            btn3.Width = 75
            Dim btn4 As New Button()
            btn4.Content = "Button 4"
            btn4.Width = 75

            ' Add the buttons to the parent WrapPanel using the Children.Add method.
            myWrapPanel.Children.Add(btn1)
            myWrapPanel.Children.Add(btn2)
            myWrapPanel.Children.Add(btn3)
            myWrapPanel.Children.Add(btn4)

            ' Add the WrapPanel to the Page as Content
            Me.Content = myWrapPanel
            '</Snippet2>

            '</Snippet1>
        End Sub

        Sub DimensionSnippets(ByVal myWrapPanel As WrapPanel)
            '<Snippet4>
            myWrapPanel.ItemHeight = 25
            '</Snippet4>

            '<Snippet3>
            myWrapPanel.ItemWidth = 75
            '</Snippet3>

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
            Dim myContent As New WrapPanel_VB()
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