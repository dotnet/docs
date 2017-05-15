Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace VisualBasic
    Partial Public Class Window1
        Inherits System.Windows.Window
        Public Sub New()
            InitializeComponent()

            Me.Title = Me.SizeToContent.ToString()
            Me.button.Content = Me.button.Width.ToString() & "," & Me.button.Height.ToString()
            AddHandler SizeChanged, AddressOf Window1_SizeChanged
        End Sub

        Private Sub Window1_SizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)
            Me.Title = Me.SizeToContent.ToString()
            Me.button.Content = Me.button.Width.ToString() & "," & Me.button.Height.ToString()
        End Sub

        Private Sub bob(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetShowSync>
            Dim w As New Window()
            AddHandler w.Loaded, Sub() System.Console.WriteLine("This is written first.")
            w.Show()
            System.Console.WriteLine("This is written last.")
            '</SnippetShowSync>

            '<SnippetShowASync>
            Dim w2 As New Window()
            AddHandler w2.Loaded, Sub() System.Console.WriteLine("This is written last.")
            w2.Visibility = Visibility.Visible
            System.Console.WriteLine("This is written first.")
            '</SnippetShowASync>            
        End Sub

        Private Sub widthAndHeightClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.button.Width = 200
            Me.button.Height = 200
            Me.SizeToContent = SizeToContent.WidthAndHeight
            Me.Title = Me.SizeToContent.ToString()
            Me.button.Content = Me.button.Width.ToString() & "," & Me.button.Height.ToString()
        End Sub

        Private Sub widthClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.button.Width = 200
            Me.button.Height = 200
            Me.SizeToContent = SizeToContent.Width
            Me.Title = Me.SizeToContent.ToString()
            Me.button.Content = Me.button.Width.ToString() & "," & Me.button.Height.ToString()
        End Sub

        Private Sub heightClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.button.Width = 200
            Me.button.Height = 200
            Me.SizeToContent = SizeToContent.Height
            Me.Title = Me.SizeToContent.ToString()
            Me.button.Content = Me.button.Width.ToString() & "," & Me.button.Height.ToString()
        End Sub

        Private Sub manualClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.button.Width = 200
            Me.button.Height = 200
            Me.SizeToContent = SizeToContent.Manual
            Me.Title = Me.SizeToContent.ToString()
            Me.button.Content = Me.button.Width.ToString() & "," & Me.button.Height.ToString()
        End Sub
    End Class
End Namespace