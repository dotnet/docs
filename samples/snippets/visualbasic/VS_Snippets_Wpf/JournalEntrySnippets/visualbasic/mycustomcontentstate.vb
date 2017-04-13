Namespace VisualBasic
    '<Snippet_MyCustomContentState_VB>
    <Serializable()>
    Public Class MyCustomContentState
        Inherits CustomContentState
        Private dateCreated As String
        Private dateTextBlock As TextBlock

        Public Sub New(ByVal dateCreated As String, ByVal dateTextBlock As TextBlock)
            Me.dateCreated = dateCreated
            Me.dateTextBlock = dateTextBlock
        End Sub

        Public Overrides ReadOnly Property JournalEntryName() As String
            Get
                Return "Journal Entry " & Me.dateCreated
            End Get
        End Property

        Public Overrides Sub Replay(ByVal navigationService As NavigationService, ByVal mode As NavigationMode)
            Me.dateTextBlock.Text = Me.dateCreated
        End Sub
    End Class
    '</Snippet_MyCustomContentState_VB>
End Namespace
