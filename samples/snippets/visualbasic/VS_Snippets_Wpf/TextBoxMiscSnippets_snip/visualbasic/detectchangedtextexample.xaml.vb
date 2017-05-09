' <SnippetDetectChangedTextCodeExampleWholePage>

Namespace SDKSample

    Partial Public Class DetectChangedTextExample
        Inherits Page

        ' This is a counter for the number of times the TextChanged fires
        ' for the tbCountingChanges TextBox.
        Private uiChanges As Integer = 0

        ' Event handler for TextChanged Event.
        Private Sub textChangedEventHandler(ByVal sender As Object,
                                            ByVal args As TextChangedEventArgs)

            uiChanges += 1
            If tbCounterText IsNot Nothing Then
                tbCounterText.Text = uiChanges.ToString()
            End If

        End Sub
    End Class
End Namespace
' </SnippetDetectChangedTextCodeExampleWholePage>