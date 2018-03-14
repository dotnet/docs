' Interaction logic for Window1.xaml
Partial Public Class Window1
    Inherits System.Windows.Window

    Public Sub New()
        InitializeComponent()
    End Sub

    '<Snippet2>
    Private Sub OnClick1(ByVal sender As Object, ByVal e As RoutedEventArgs)
        btn1.Background = Brushes.LightBlue
    End Sub

    Private Sub OnClick2(ByVal sender As Object, ByVal e As RoutedEventArgs)
        btn2.Background = Brushes.Pink
    End Sub

    Private Sub OnClick3(ByVal sender As Object, ByVal e As RoutedEventArgs)
        btn1.Background = Brushes.Pink
        btn2.Background = Brushes.LightBlue
    End Sub
    '</Snippet2>
End Class
