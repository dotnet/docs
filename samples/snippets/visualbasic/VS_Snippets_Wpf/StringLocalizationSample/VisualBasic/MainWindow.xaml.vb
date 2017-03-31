
Namespace SDKSample

    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub messageBoxButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetGetLocalizedResourceFromCode>
            ' Programmatic use of string resource from StringResources.xaml resource dictionary
            Dim localizedMessage As String = CStr(Application.Current.FindResource("localizedMessage"))
            MessageBox.Show(localizedMessage)
            '</SnippetGetLocalizedResourceFromCode>
        End Sub

    End Class

End Namespace