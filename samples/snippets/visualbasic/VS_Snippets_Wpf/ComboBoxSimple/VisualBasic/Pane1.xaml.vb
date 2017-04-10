'This is a list of commonly used namespaces for a pane.
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Input

'@ <summary>
'@ Interaction logic for Pane1.xaml
'@ </summary>

Partial Public Class Pane1
    Inherits Canvas


    Private Sub OnHover(ByVal Sender As Object, ByVal e As MouseEventArgs)

        '<Snippet3>
        If (cbi1.IsHighlighted = True) Then

            cbi2.Content = "Item2"
            cbi3.Content = "Item3"
            cbi1.Content = "Highlighted Item"
            '</Snippet3>
        ElseIf (cbi2.IsHighlighted = True) Then

            cbi1.Content = "Item1"
            cbi3.Content = "Item3"
            cbi2.Content = "Highlighted Item"

        ElseIf (cbi3.IsHighlighted = True) Then

            cbi1.Content = "Item1"
            cbi2.Content = "Item2"
            cbi3.Content = "Highlighted Item"
        End If
    End Sub

    '<SnippetComboBoxEvents2>
    Private Sub OnDropDownOpened(ByVal Sender As Object, ByVal e As EventArgs)

        If (cb.IsDropDownOpen = True) Then
            cb.Text = "Combo box opened"
        End If

    End Sub

    Private Sub OnDropDownClosed(ByVal Sender As Object, ByVal e As EventArgs)

        If (cb.IsDropDownOpen = False) Then
            cb.Text = "Combo box closed"
        End If

    End Sub
    '</SnippetComboBoxEvents2>

    Private Sub OnClick(ByVal Sender As Object, ByVal e As RoutedEventArgs)
        '<Snippet2>
        Dim cbox As System.Windows.Controls.ComboBox
        Dim cboxitem As System.Windows.Controls.ComboBoxItem
        Dim cboxitem2 As System.Windows.Controls.ComboBoxItem
        Dim cboxitem3 As System.Windows.Controls.ComboBoxItem

        cbox = New ComboBox()
        cbox.Background = Brushes.LightBlue
        cboxitem = New ComboBoxItem()
        cboxitem.Content = "Created with Visual Basic."
        cbox.Items.Add(cboxitem)
        cboxitem2 = New ComboBoxItem()
        cboxitem2.Content = "Item 2"
        cbox.Items.Add(cboxitem2)
        cboxitem3 = New ComboBoxItem()
        cboxitem3.Content = "Item 3"
        cbox.Items.Add(cboxitem3)

        cv2.Children.Add(cbox)
        '</Snippet2>
    End Sub
End Class
