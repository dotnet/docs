'<SnippetTextFoundEventCODEBEHIND1>
'<SnippetTextFoundEventRaiseCODEBEHIND1>
'<SnippetFindDialogCloseCODEBEHIND1>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Text.RegularExpressions

Namespace SDKSample

Public Class FindDialogBox
    Inherits Window
    '</SnippetTextFoundEventRaiseCODEBEHIND1>
    '</SnippetFindDialogCloseCODEBEHIND1>
    Public Event TextFound As TextFoundEventHandler
    Protected Overridable Sub OnTextFound()
        RaiseEvent TextFound(Me, EventArgs.Empty)
    End Sub
    '</SnippetTextFoundEventCODEBEHIND1>

    Private _index As Integer
    Private _length As Integer
    Private matches As MatchCollection
    Private matchIndex As Integer
    Private textBoxToSearch As TextBox

    Public Sub New(ByVal textBoxToSearch As TextBox)
        Me.matchIndex = 0
        Me.Index = 0
        Me.Length = 0
        Me.InitializeComponent()
        Me.textBoxToSearch = textBoxToSearch
        AddHandler Me.textBoxToSearch.TextChanged, New TextChangedEventHandler(AddressOf Me.textBoxToSearch_TextChanged)
    End Sub

    Private Sub criteria_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.ResetFind()
    End Sub

    '<SnippetTextFoundEventRaiseCODEBEHIND2>
    Private Sub findNextButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        '</SnippetTextFoundEventRaiseCODEBEHIND2>
        If (Me.matches Is Nothing) Then
            Dim pattern As String = Me.findWhatTextBox.Text
            If Me.matchWholeWordCheckBox.IsChecked.Value Then
                pattern = ("(?<=\W{0,1})" & pattern & "(?=\W)")
            End If
            If Not Me.caseSensitiveCheckBox.IsChecked.Value Then
                pattern = ("(?i)" & pattern)
            End If
            Me.matches = Regex.Matches(Me.textBoxToSearch.Text, pattern)
            Me.matchIndex = 0
            If (Me.matches.Count = 0) Then
                MessageBox.Show(("'" & Me.findWhatTextBox.Text & "' not found."), "Find")
                Me.matches = Nothing
                Return
            End If
        End If
        If (Me.matchIndex = Me.matches.Count) Then
            Dim result As MessageBoxResult = MessageBox.Show("Nmore matches found. Start at beginning?", "Find", MessageBoxButton.YesNo)
            If (result = MessageBoxResult.No) Then
                Return
            End If
            Me.matchIndex = 0
        End If
        Dim match As Match = Me.matches.Item(Me.matchIndex)

        '<SnippetTextFoundEventRaiseCODEBEHIND3>
        Me.Index = match.Index
        Me.Length = match.Length
        RaiseEvent TextFound(Me, EventArgs.Empty)
        '</SnippetTextFoundEventRaiseCODEBEHIND3>

        Me.matchIndex += 1
        '<SnippetTextFoundEventRaiseCODEBEHIND4>
    End Sub
    '</SnippetTextFoundEventRaiseCODEBEHIND4>

    Private Sub findWhatTextBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        Me.ResetFind()
    End Sub

    Private Sub ResetFind()
        Me.findNextButton.IsEnabled = True
        Me.matches = Nothing
    End Sub

    Private Sub textBoxToSearch_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        Me.ResetFind()
    End Sub

    Public Property Index() As Integer
        Get
            Return Me._index
        End Get
        Set(ByVal value As Integer)
            Me._index = value
        End Set
    End Property

    Public Property Length() As Integer
        Get
            Return Me._length
        End Get
        Set(ByVal value As Integer)
            Me._length = value
        End Set
    End Property

    '<SnippetFindDialogCloseCODEBEHIND2>
    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MyBase.Close()
    End Sub
    '<SnippetTextFoundEventCODEBEHIND2>
    '<SnippetTextFoundEventRaiseCODEBEHIND5>
End Class

End Namespace
'</SnippetTextFoundEventCODEBEHIND2>
'</SnippetTextFoundEventRaiseCODEBEHIND5>
'</SnippetFindDialogCloseCODEBEHIND2>
