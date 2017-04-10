' Interaction logic for Window1.xaml
Partial Public Class Window1
    Inherits System.Windows.Window

    Public Sub New()
        InitializeComponent()
    End Sub

    '<Snippet3>
    Private Sub chkbox_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        textBlock1.FontStyle = FontStyles.Normal
    End Sub

    Private Sub chkbox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        textBlock1.FontStyle = FontStyles.Italic
    End Sub
    '</Snippet3>

    '<Snippet5>
    Private Sub HandleCheck(ByVal sender As Object, ByVal e As RoutedEventArgs)
        text1.Text = "The CheckBox is checked."
    End Sub

    Private Sub HandleUnchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        text1.Text = "The CheckBox is unchecked."
    End Sub

    Private Sub HandleThirdState(ByVal sender As Object, ByVal e As RoutedEventArgs)
        text1.Text = "The CheckBox is in the indeterminate state."
    End Sub
    '</Snippet5>
End Class
