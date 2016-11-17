    Private Sub Button_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click, Button2.Click
        MessageBox.Show(sender.Name & " clicked")
    End Sub