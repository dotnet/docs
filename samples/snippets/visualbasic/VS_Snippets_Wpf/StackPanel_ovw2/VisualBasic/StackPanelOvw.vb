' <Snippet2>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Navigation

Namespace SDKSample

    Public Class StackPanel_VB
        Inherits Page

        Public Sub New()
            '<Snippet1>
            WindowTitle = "StackPanel Sample"
            ' Define the StackPanel
            Dim myStackPanel As New StackPanel()
            myStackPanel.HorizontalAlignment = Windows.HorizontalAlignment.Left
            myStackPanel.VerticalAlignment = Windows.VerticalAlignment.Top

            ' Define child content
            Dim myButton1 As New Button()
            myButton1.Content = "Button 1"
            Dim myButton2 As New Button()
            myButton2.Content = "Button 2"
            Dim myButton3 As New Button()
            myButton3.Content = "Button 3"

            ' Add child elements to the parent StackPanel
            myStackPanel.Children.Add(myButton1)
            myStackPanel.Children.Add(myButton2)
            myStackPanel.Children.Add(myButton3)

            Me.Content = myStackPanel
            '</Snippet1>
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
            Dim myContent As New StackPanel_VB()
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
' </Snippet2>