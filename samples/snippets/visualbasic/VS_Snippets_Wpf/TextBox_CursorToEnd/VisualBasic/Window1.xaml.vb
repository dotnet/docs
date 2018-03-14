Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample

    Partial Class Window1

        Public Sub New()

            InitializeComponent()

        End Sub

        Private Sub OnClickMoveToEnd(ByVal sender As Object, ByVal e As RoutedEventArgs)

            tbPositionCursor.Focus()
            tbPositionCursor.Select(tbPositionCursor.Text.Length, 0)

        End Sub
'<SnippetUIElementFocus>
        Private Sub OnClickMoveToStart(ByVal sender As Object, ByVal e As RoutedEventArgs)

            tbPositionCursor.Focus()
            tbPositionCursor.Select(0, 0)

        End Sub
'</SnippetUIElementFocus>
    End Class

End Namespace