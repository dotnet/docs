        Private Sub Media_MediaFailed(ByVal sender As Object, ByVal args As ExceptionRoutedEventArgs)
            If (True) Then
                MessageBox.Show(args.ErrorException.Message)
            End If
        End Sub 'Media_MediaFailed