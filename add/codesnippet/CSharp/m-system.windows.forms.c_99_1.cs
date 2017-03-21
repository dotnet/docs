    // Demonstrates SetText, ContainsText, and GetText.
    public String SwapClipboardHtmlText(String replacementHtmlText)
    {
        String returnHtmlText = null;
        if (Clipboard.ContainsText(TextDataFormat.Html))
        {
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html);
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Html);
        }
        return returnHtmlText;
    }