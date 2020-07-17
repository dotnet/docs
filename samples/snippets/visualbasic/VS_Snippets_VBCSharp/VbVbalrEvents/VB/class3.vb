Class Class3

    ' Handles Clause (Visual Basic)
    ' 1b051c0e-f499-42f6-acb5-6f4f27824b40

    Private WithEvents Button1 As System.Windows.Controls.Button
    Private WithEvents Button2 As System.Windows.Controls.Button

    ' <snippet41>
    Private Sub Button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click
        MessageBox.Show(sender.Name & " clicked")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button2.Click
        MessageBox.Show(sender.Name & " clicked")
    End Sub
    ' </snippet41>

    ' <snippet42>
    Private Sub Button_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click, Button2.Click
        MessageBox.Show(sender.Name & " clicked")
    End Sub
    ' </snippet42>

End Class
