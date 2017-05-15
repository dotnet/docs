Namespace VisualBasic
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        Private ReadOnly Property NavigationService() As NavigationService
            Get
                Return Me.browserFrame.NavigationService
            End Get
        End Property

        Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As EventArgs)
            AddHandler NavigationService.LoadCompleted, AddressOf NavigationService_LoadCompleted
        End Sub

        '<SnippetMainWindowCODE>
        Private Sub goButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.NavigationService.Navigate(New Uri(Me.addressTextBox.Text), Date.Now)
        End Sub
        Private Sub NavigationService_LoadCompleted(ByVal sender As Object, ByVal e As NavigationEventArgs)
            Dim requestDateTime As Date = CDate(e.ExtraData)
            Dim msg As String = String.Format("Request started {0}" & vbLf & "Request completed {1}", requestDateTime, Date.Now)
            MessageBox.Show(msg)
        End Sub
        '</SnippetMainWindowCODE>
    End Class
End Namespace