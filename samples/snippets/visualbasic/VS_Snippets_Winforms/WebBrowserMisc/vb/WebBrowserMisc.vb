Imports System
Imports System.Windows.Forms
Imports System.Security.Permissions

<PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
Public Class Form1
    Inherits Form

    <STAThreadAttribute()> _
    Public Shared Sub Main()

        Application.Run(New Form1())

    End Sub

    Private WithEvents button As New Button()

    Public Sub New()

        Me.Controls.Add(button)
        Me.Controls.Add(webBrowser1)

    End Sub

    Private Sub button_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button.Click

        PrintHelpPage()

    End Sub

    '<snippet10>
    Private Sub PrintHelpPage()

        ' Create a WebBrowser instance. 
        Dim webBrowserForPrinting As New WebBrowser()

        ' Add an event handler that prints the document after it loads.
        AddHandler webBrowserForPrinting.DocumentCompleted, New _
            WebBrowserDocumentCompletedEventHandler(AddressOf PrintDocument)

        ' Set the Url property to load the document.
        webBrowserForPrinting.Url = New Uri("\\myshare\help.html")

    End Sub

    Private Sub PrintDocument(ByVal sender As Object, _
        ByVal e As WebBrowserDocumentCompletedEventArgs)

        Dim webBrowserForPrinting As WebBrowser = CType(sender, WebBrowser)

        ' Print the document now that it is fully loaded.
        webBrowserForPrinting.Print()
        MessageBox.Show("print")

        ' Dispose the WebBrowser now that the task is complete. 
        webBrowserForPrinting.Dispose()

    End Sub
    '</snippet10>

    Private WithEvents webBrowser1 As New WebBrowser()

    Private Sub InitializeHtmlViewer()

        '<snippet20>
        webBrowser1.AllowWebBrowserDrop = False
        '</snippet20>

        '<snippet21>
        webBrowser1.Url = New Uri("http://www.contoso.com/")
        '</snippet21>

    End Sub

    '<snippet30>
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        webBrowser1.DocumentText = _
            "<html><body>Please enter your name:<br/>" & _
            "<input type='text' name='userName'/><br/>" & _
            "<a href='http://www.microsoft.com'>continue</a>" & _
            "</body></html>"

    End Sub

    Private Sub webBrowser1_Navigating( _
        ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs) _
        Handles webBrowser1.Navigating

        Dim document As System.Windows.Forms.HtmlDocument = _
            webBrowser1.Document
        If document IsNot Nothing And _
            document.All("userName") IsNot Nothing And _
            String.IsNullOrEmpty( _
            document.All("userName").GetAttribute("value")) Then

            e.Cancel = True
            MsgBox("You must enter your name before you can navigate to " & _
                e.Url.ToString())
        End If

    End Sub
    '</snippet30>

    '<snippet40>
    ' Hides script errors without hiding other dialog boxes.
    Private Sub SuppressScriptErrorsOnly(ByVal browser As WebBrowser)

        ' Ensure that ScriptErrorsSuppressed is set to false.
        browser.ScriptErrorsSuppressed = False

        ' Handle DocumentCompleted to gain access to the Document object.
        AddHandler browser.DocumentCompleted, _
            AddressOf browser_DocumentCompleted

    End Sub

    Private Sub browser_DocumentCompleted(ByVal sender As Object, _
    ByVal e As WebBrowserDocumentCompletedEventArgs)

        AddHandler CType(sender, WebBrowser).Document.Window.Error, _
            AddressOf Window_Error

    End Sub

    Private Sub Window_Error(ByVal sender As Object, _
        ByVal e As HtmlElementErrorEventArgs)

        ' Ignore the error and suppress the error dialog box. 
        e.Handled = True

    End Sub
    '</snippet40>

End Class
