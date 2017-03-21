'This is a list of commonly used namespaces for a pane.
Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Collections.ObjectModel

	'@ <summary>
	'@ Interaction logic for Pane1.xaml
	'@ </summary>
        
        
Partial Public Class Pane1
    Inherits Grid

    Private Sub OnClick(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        sp2.Children.Clear()
        '<Snippet1>       
        Dim style As Style = New Style()
        style.Setters.Add(New Setter(ListBoxItem.HorizontalContentAlignmentProperty, _
             HorizontalAlignment.Stretch))
        Dim lb As ListBox = New ListBox()
        lb.ItemContainerStyle = style
        Dim lbi1 As ListBoxItem = New ListBoxItem()
        Dim btn As Button = New Button()
        btn.Content = "Button as styled list box item."
        lbi1.Content = (btn)
        lb.Items.Add(lbi1)
        '</Snippet1>

        Dim lbi2 As ListBoxItem = New ListBoxItem()
        Dim btn2 As Button = New Button()
        btn2.Content = "Button as styled list box item."
        lbi2.Content = (btn2)
        lb.Items.Add(lbi2)

        sp2.Children.Add(lb)
    End Sub

End Class
        
