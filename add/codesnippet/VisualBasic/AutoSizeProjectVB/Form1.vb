Public Class Form1
    Dim flowPanel As FlowLayoutPanel
    Dim urlLabel As Label
    Dim urlTextBox As TextBox
    Dim WithEvents urlButton As Button

    '<SNIPPET1>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Text = "URL Opener"

        flowPanel = New FlowLayoutPanel()
        flowPanel.AutoSize = True
        flowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(flowPanel)

        urlLabel = New Label()
        urlLabel.Name = "urlLabel"
        urlLabel.Text = "URL:"
        urlLabel.Width = 50
        urlLabel.TextAlign = ContentAlignment.MiddleCenter
        flowPanel.Controls.Add(urlLabel)

        urlTextBox = New TextBox()
        urlTextBox.Name = "urlTextBox"
        urlTextBox.Width = 250
        flowPanel.Controls.Add(urlTextBox)

        urlButton = New Button()
        urlButton.Name = "urlButton"
        urlButton.Text = "Open URL in Browser"
        flowPanel.Controls.Add(urlButton)
    End Sub


    Private Sub urlButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles urlButton.Click
        Try
            Dim newUri As New Uri(urlTextBox.Text)
        Catch uriEx As UriFormatException
            MessageBox.Show(("Sorry, your URL is malformed. Try again. Error: " + uriEx.Message))
            urlTextBox.ForeColor = Color.Red
            Return
        End Try

        ' Valid URI. Reset any previous error color, and launch the URL in the 
        ' default browser.
        ' NOTE: Depending on the user's settings, this method of starting the
        ' browser may use an existing window in an existing Web browser process.
        ' To get around this, start up a specific browser instance instead using one of
        ' the overloads for Process.Start. You can examine the registry to find the
        ' current default browser and launch that, or hard-code a specific browser.
        urlTextBox.ForeColor = Color.Black
        Process.Start(urlTextBox.Text)
    End Sub
    '</SNIPPET1>
End Class