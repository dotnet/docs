'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

    <System.STAThread()> _
    Public Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1)
    End Sub 'Main

    Public Sub New()
        MyBase.New()

        ' Create the LinkLabel.
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel

        ' Configure the LinkLabel's location.
        Me.LinkLabel1.Location = New System.Drawing.Point(34, 56)
        ' Specify that the size should be automatically determined by the content.
        Me.LinkLabel1.AutoSize = True

        ' Set the text for the LinkLabel.
        Me.LinkLabel1.Text = "Visit Microsoft"

        ' Set up how the form should be displayed and adds the controls to the form.
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.LinkLabel1})
        Me.Text = "Simple Link Label Example"
    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        ' Specify that the link was visited.
        Me.LinkLabel1.LinkVisited = True

        ' Navigate to a URL.
        System.Diagnostics.Process.Start("http://www.microsoft.com")
    End Sub
End Class
'</Snippet1>