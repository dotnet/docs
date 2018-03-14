Namespace VisualBasic
    Partial Public Class DatePage
        Inherits Page
        Implements IProvideCustomContentState
        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf DatePage_Loaded
        End Sub

        Private dateTime As Date = Date.Now

        Private Sub DatePage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.textBlockLabel.Text = Me.dateTime.ToString()
        End Sub

        Private Sub addBackEntryButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.NavigationService.AddBackEntry(New MyCustomContentState(Me.dateTime.ToString(), Me.textBlockLabel))
            Me.dateTime = Date.Now
            Me.textBlockLabel.Text = Me.dateTime.ToString()
        End Sub

        '<SnippetGetJournalEntryCODEBEHIND>
        Private Sub removeJournalEntryButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' If there are journal entries on the back navigation stack
            If Me.NavigationService.CanGoBack Then
                ' Remove and get the most recent entry on the back navigation stack
                Dim journalEntry As JournalEntry = Me.NavigationService.RemoveBackEntry()

                Dim name As String = journalEntry.Name
                Dim uri As String = journalEntry.Source.OriginalString
                MessageBox.Show(name & " [" & uri & "] removed from back navigation.")
            End If
        End Sub
        '</SnippetGetJournalEntryCODEBEHIND>

#Region "IProvideCustomContentState Members"

        Public Function GetContentState() As CustomContentState Implements IProvideCustomContentState.GetContentState
            Return New MyCustomContentState(Me.textBlockLabel.Text, Me.textBlockLabel)
        End Function

#End Region
    End Class
End Namespace