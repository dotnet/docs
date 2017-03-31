Namespace NavigationServiceSnippetSample_VisualBasic
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
            AddHandler NavigationService.Navigating, AddressOf NavigationService_Navigating
            AddHandler NavigationService.Navigated, AddressOf NavigationService_Navigated
            AddHandler NavigationService.NavigationProgress, AddressOf NavigationService_NavigationProgress
            AddHandler NavigationService.LoadCompleted, AddressOf NavigationService_LoadCompleted
            AddHandler NavigationService.NavigationStopped, AddressOf NavigationService_NavigationStopped
            AddHandler Me.NavigationService.FragmentNavigation, AddressOf NavigationService_FragmentNavigation
            AddHandler NavigationService.NavigationFailed, AddressOf NavigationService_NavigationFailed
            Me.NavigationService.Navigate(New Uri(Me.addressTextBox.Text))
        End Sub

        '<SnippetMainWindowNavigateCODE>
        Private Sub goButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.NavigationService.Navigate(New Uri(Me.addressTextBox.Text))
        End Sub
        '</SnippetMainWindowNavigateCODE>

        '<SnippetMainWindowNavigateObjectCODE>
        Private Sub goObjectButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.NavigationService.Navigate(New ContentPage())
        End Sub
        '</SnippetMainWindowNavigateObjectCODE>

        '<SnippetMainWindowBackCODE>
        Private Sub backButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If Me.NavigationService.CanGoBack Then
                Me.NavigationService.GoBack()
            End If
        End Sub
        '</SnippetMainWindowBackCODE>
        '<SnippetMainWindowForwardCODE>
        Private Sub forwardButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If Me.NavigationService.CanGoForward Then
                Me.NavigationService.GoForward()
            End If
        End Sub
        '</SnippetMainWindowForwardCODE>
        '<SnippetMainWindowStopLoadingCODE>
        Private Sub stopButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.NavigationService.StopLoading()
        End Sub
        '</SnippetMainWindowStopLoadingCODE>
        '<SnippetMainWindowRefreshCODE>
        Private Sub refreshButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.NavigationService.Refresh()
        End Sub
        '</SnippetMainWindowRefreshCODE>

        '<SnippetMainWindowNavigatingCODE>
        Private Sub NavigationService_Navigating(ByVal sender As Object, ByVal e As NavigatingCancelEventArgs)
            ' Don't allow refreshing of a static page
            If (e.NavigationMode = NavigationMode.Refresh) AndAlso (e.Uri.OriginalString = "StaticPage.xaml") Then
                e.Cancel = True
            End If
        End Sub
        '</SnippetMainWindowNavigatingCODE>

        '<SnippetMainWindowNavigatedCODE>
        Private Sub NavigationService_Navigated(ByVal sender As Object, ByVal e As NavigationEventArgs)
            Dim msg As String = String.Format("Downloading {0}.", e.Uri.OriginalString)
            Me.progressStatusBarItem.Content = msg
        End Sub
        '</SnippetMainWindowNavigatedCODE>

        '<SnippetMainWindowNavigationProgressCODE>
        Private Sub NavigationService_NavigationProgress(ByVal sender As Object, ByVal e As NavigationProgressEventArgs)
            Dim msg As String = String.Format("{0} of {1} bytes retrieved.", e.BytesRead, e.MaxBytes)
            Me.progressStatusBarItem.Content = msg
        End Sub
        '</SnippetMainWindowNavigationProgressCODE>

        '<SnippetMainWindowLoadCompletedCODE>
        Private Sub NavigationService_LoadCompleted(ByVal sender As Object, ByVal e As NavigationEventArgs)
            Dim msg As String = String.Format("{0} loaded.", e.Uri.OriginalString)
            Me.progressStatusBarItem.Content = msg
        End Sub
        '</SnippetMainWindowLoadCompletedCODE>

        '<SnippetMainWindowNavigationStoppedCODE>
        Private Sub NavigationService_NavigationStopped(ByVal sender As Object, ByVal e As NavigationEventArgs)
            Me.progressStatusBarItem.Content = "Navigation stopped."
        End Sub
        '</SnippetMainWindowNavigationStoppedCODE>

        '<SnippetMainWindowNavigationFailedCODE>
        Private Sub NavigationService_NavigationFailed(ByVal sender As Object, ByVal e As NavigationFailedEventArgs)
            Dim msg As String = String.Format("Navigation to {0} failed: {1}.", e.Uri.OriginalString, e.Exception.Message)
            Me.progressStatusBarItem.Content = msg
        End Sub
        '</SnippetMainWindowNavigationFailedCODE>

        '<SnippetMainWindowFragmentNavigationCODE>
        Private Sub NavigationService_FragmentNavigation(ByVal sender As Object, ByVal e As FragmentNavigationEventArgs)
            ' Get content the ContentControl that contains the XAML page that was navigated to
            Dim content As Object = (CType(e.Navigator, ContentControl)).Content

            ' Find the fragment, which is the FrameworkElement with its Name attribute set
            Dim fragmentElement As FrameworkElement = TryCast(LogicalTreeHelper.FindLogicalNode(CType(content, DependencyObject), e.Fragment), FrameworkElement)

            ' If fragment found, bring it into view, or open an error page
            If fragmentElement Is Nothing Then
                Me.NavigationService.Navigate(New FragmentNotFoundPage())

                ' Don't let NavigationService handle this event, since we just did
                e.Handled = True
            End If
        End Sub
        '</SnippetMainWindowFragmentNavigationCODE>
    End Class
End Namespace