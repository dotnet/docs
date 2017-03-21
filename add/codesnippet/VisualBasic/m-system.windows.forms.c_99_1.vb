    ' Demonstrates SetText, ContainsText, and GetText.
    Public Function SwapClipboardHtmlText( _
        ByVal replacementHtmlText As String) As String

        Dim returnHtmlText As String = Nothing

        If (Clipboard.ContainsText(TextDataFormat.Html)) Then
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html)
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Html)
        End If

        Return returnHtmlText

    End Function