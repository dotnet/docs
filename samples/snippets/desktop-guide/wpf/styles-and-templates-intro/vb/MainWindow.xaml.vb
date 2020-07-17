Class MainWindow
    Private Sub Window_Loaded(sender As Object, e As Windows.RoutedEventArgs)
        '<SnippetSetStyleCode>
        textblock1.Style = CType(Resources("TitleText"), Windows.Style)
        '</SnippetSetStyleCode>
    End Sub
End Class
