Partial Public Class Window2

    '<Snippet4>
    Private Sub ShowSelection_Click(ByVal sender As System.Object, _
                                    ByVal e As System.Windows.RoutedEventArgs)

        MessageBox.Show(flowdocScrollViewer1.Selection.Text)

    End Sub
    '</Snippet4>
End Class
