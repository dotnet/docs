Namespace VisualBasic
    ''' <summary>
    ''' Interaction logic for ContentUserControl.xaml
    ''' </summary>

    Partial Public Class ContentUserControl
        Inherits UserControl
        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetGetNavigationServiceCODE1>
        Private Sub getNavigationServiceButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Retrieve first navigation service up the content tree
            Dim svc As NavigationService = NavigationService.GetNavigationService(Me.getNavigationServiceButton)
            If svc IsNot Nothing Then
                ' Use navigation service
                '</SnippetGetNavigationServiceCODE1>
                '<SnippetGetNavigationServiceCODE2>
            End If
        End Sub
        '</SnippetGetNavigationServiceCODE2>
    End Class
End Namespace