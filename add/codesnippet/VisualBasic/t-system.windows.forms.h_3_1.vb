    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim Doc As HtmlDocument = WebBrowser1.Document

        AddHandler Doc.MouseDown, New HtmlElementEventHandler(AddressOf Document_MouseDown)
        AddHandler Doc.MouseMove, New HtmlElementEventHandler(AddressOf Document_MouseMove)
        AddHandler Doc.MouseUp, New HtmlElementEventHandler(AddressOf Document_MouseUp)
    End Sub

    Private Sub Document_MouseDown(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        ' Insert your code here.
    End Sub

    Private Sub Document_MouseMove(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        ' Insert your code here.
    End Sub

    Private Sub Document_MouseUp(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        ' Insert your code here.
    End Sub