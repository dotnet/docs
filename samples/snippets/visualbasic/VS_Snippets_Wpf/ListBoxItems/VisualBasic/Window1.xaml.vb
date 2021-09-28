Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data

Partial Public Class Window1
    Inherits Window

    Public Sub Window1()

        InitializeComponent()
    End Sub

    '<Snippet2>	
    Private Sub GetIndex0(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        Dim lbi As ListBoxItem = CType( _
            lb.ItemContainerGenerator.ContainerFromIndex(0), ListBoxItem)
        '<Snippet3>
        Item.Content = "The contents of the item at index 0 are: " + _
            (lbi.Content.ToString()) + "."
        '</Snippet3>
    End Sub
    '</Snippet2>      

    Private Sub GetIndex1(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        Dim lbi As ListBoxItem = CType( _
            lb.ItemContainerGenerator.ContainerFromIndex(1), ListBoxItem)
        Item.Content = "The contents of the item at index 1 are: " + _
            (lbi.Content.ToString()) + "."
    End Sub

    Private Sub GetIndex2(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        Dim lbi As ListBoxItem = CType( _
            lb.ItemContainerGenerator.ContainerFromIndex(2), ListBoxItem)
        Item.Content = "The contents of the item at index 2 are: " + _
            (lbi.Content.ToString()) + "."
    End Sub

    Private Sub GetIndex3(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        Dim lbi As ListBoxItem = CType( _
            lb.ItemContainerGenerator.ContainerFromIndex(3), ListBoxItem)
        Item.Content = "The contents of the item at index 3 are: " + _
             (lbi.Content.ToString()) + "."
    End Sub
End Class
