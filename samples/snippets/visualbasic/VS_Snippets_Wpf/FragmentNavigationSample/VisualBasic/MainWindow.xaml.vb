Imports System.Windows.Threading

Public Class MainWindow
    Inherits Window

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    '<SnippetFEBringIntoView>
    Private Sub browserFrame_FragmentNavigation(ByVal sender As Object, ByVal e As FragmentNavigationEventArgs)
        Dim element As FrameworkElement = TryCast(LogicalTreeHelper.FindLogicalNode(DirectCast(DirectCast(e.Navigator, ContentControl).Content, DependencyObject), e.Fragment), FrameworkElement)
        If (element Is Nothing) Then
            ' Redirect to error page
            ' Note - You can't navigate from within a FragmentNavigation event handler,
            '        hence creation of an async dispatcher work item
            Dim callback As New DispatcherOperationCallback(AddressOf Me.FragmentNotFoundNavigationRedirect)
            Me.Dispatcher.BeginInvoke(DispatcherPriority.Normal, callback, Nothing)
        End If
        e.Handled = True
    End Sub

    Function FragmentNotFoundNavigationRedirect(ByVal unused As Object) As Object
        Me.browserFrame.Navigate(New Uri("FragmentNotFoundPage.xaml", UriKind.Relative))
        Return Nothing
    End Function

    '</SnippetFEBringIntoView>

    Private Sub goButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Navigate to Uri, with or with out fragment
        ' NOTE - Uri with fragment looks like "DocumentPage.xaml#Fragment5"
        Me.browserFrame.Navigate(New Uri(Me.addressTextBox.Text, UriKind.RelativeOrAbsolute))
    End Sub

End Class