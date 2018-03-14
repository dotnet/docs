'<snippet0>
Imports System
Imports System.Windows.Forms
Imports System.Security.Permissions

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
Public Class Form1
    Inherits Form

    Private webBrowser1 As New WebBrowser()
    Private WithEvents button1 As New Button()

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

    Public Sub New()
        button1.Text = "call script code from client code"
        button1.Dock = DockStyle.Top
        webBrowser1.Dock = DockStyle.Fill
        Controls.Add(webBrowser1)
        Controls.Add(button1)
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        '<snippet1>
        webBrowser1.AllowWebBrowserDrop = False
        '</snippet1>
        '<snippet2>
        webBrowser1.IsWebBrowserContextMenuEnabled = False
        '</snippet2>
        '<snippet3>
        webBrowser1.WebBrowserShortcutsEnabled = False
        '</snippet3>
        '<snippet4>
        webBrowser1.ObjectForScripting = Me
        '</snippet4>
        '<snippet9>
        ' Uncomment the following line when you are finished debugging.
        'webBrowser1.ScriptErrorsSuppressed = True
        '</snippet9>

        webBrowser1.DocumentText = _
            "<html><head><script>" & _
            "function test(message) { alert(message); }" & _
            "</script></head><body><button " & _
            "onclick=""window.external.Test('called from script code')"" > " & _
            "call client code from script code</button>" & _
            "</body></html>"
    End Sub

    '<snippet5>
    Public Sub Test(ByVal message As String)
        MessageBox.Show(message, "client code")
    End Sub
    '</snippet5>

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        '<snippet8>
        webBrowser1.Document.InvokeScript("test", _
            New String() {"called from client code"})
        '</snippet8>

    End Sub

End Class
'</snippet0>