'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms

Public Class ByteViewerForm
   Inherits System.Windows.Forms.Form
   Private button1 As System.Windows.Forms.Button
   Private button2 As System.Windows.Forms.Button
   Private byteviewer As System.ComponentModel.Design.ByteViewer
   
    Public Sub New()
        ' Initialize the controls other than the ByteViewer.
        InitializeForm()

        ' Initialize the ByteViewer.
        byteviewer = New ByteViewer
        byteviewer.Location = New Point(8, 46)
        byteviewer.Size = New Size(600, 338)
        byteviewer.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Top
        byteviewer.SetBytes(New Byte() {})
        Me.Controls.Add(byteviewer)
    End Sub

    ' Show a file selection dialog and cues the byte viewer to 
    ' load the data in a selected file.
    Private Sub loadBytesFromFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
            Return
        End If
        byteviewer.SetFile(ofd.FileName)
    End Sub

    ' Clear the bytes in the byte viewer.
    Private Sub clearBytes(ByVal sender As Object, ByVal e As EventArgs)
        byteviewer.SetBytes(New Byte() {})
    End Sub

    ' Changes the display mode of the byte viewer according to the 
    ' Text property of the RadioButton sender control.
    Private Sub changeByteMode(ByVal sender As Object, ByVal e As EventArgs)
        Dim rbutton As System.Windows.Forms.RadioButton = _
            CType(sender, System.Windows.Forms.RadioButton)

        Dim mode As DisplayMode
        Select Case rbutton.Text
            Case "ANSI"
                mode = DisplayMode.Ansi
            Case "Hex"
                mode = DisplayMode.Hexdump
            Case "Unicode"
                mode = DisplayMode.Unicode
            Case Else
                mode = DisplayMode.Auto
        End Select

        ' Sets the display mode.
        byteviewer.SetDisplayMode(mode)
    End Sub

    Private Sub InitializeForm()
        Me.SuspendLayout()
        Me.ClientSize = New System.Drawing.Size(680, 440)
        Me.MinimumSize = New System.Drawing.Size(660, 400)
        Me.Size = New System.Drawing.Size(680, 440)
        Me.Name = "Byte Viewer Form"
        Me.Text = "Byte Viewer Form"

        Me.button1 = New System.Windows.Forms.Button
        Me.button1.Location = New System.Drawing.Point(8, 8)
        Me.button1.Size = New System.Drawing.Size(190, 23)
        Me.button1.Name = "button1"
        Me.button1.Text = "Set Bytes From File..."
        Me.button1.TabIndex = 0
        AddHandler Me.button1.Click, AddressOf Me.loadBytesFromFile
        Me.Controls.Add(Me.button1)

        Me.button2 = New System.Windows.Forms.Button
        Me.button2.Location = New System.Drawing.Point(198, 8)
        Me.button2.Size = New System.Drawing.Size(190, 23)
        Me.button2.Name = "button2"
        Me.button2.Text = "Clear Bytes"
        AddHandler Me.button2.Click, AddressOf Me.clearBytes
        Me.button2.TabIndex = 1

        Me.Controls.Add(Me.button2)

        Dim group As New System.Windows.Forms.GroupBox
        group.Location = New Point(418, 3)
        group.Size = New Size(220, 36)
        group.Text = "Display Mode"
        Me.Controls.Add(group)

        Dim rbutton1 As New System.Windows.Forms.RadioButton
        rbutton1.Location = New Point(6, 15)
        rbutton1.Size = New Size(46, 16)
        rbutton1.Text = "Auto"
        rbutton1.Checked = True
        AddHandler rbutton1.Click, AddressOf Me.changeByteMode
        group.Controls.Add(rbutton1)

        Dim rbutton2 As New System.Windows.Forms.RadioButton
        rbutton2.Location = New Point(54, 15)
        rbutton2.Size = New Size(50, 16)
        rbutton2.Text = "ANSI"
        AddHandler rbutton2.Click, AddressOf Me.changeByteMode
        group.Controls.Add(rbutton2)

        Dim rbutton3 As New System.Windows.Forms.RadioButton
        rbutton3.Location = New Point(106, 15)
        rbutton3.Size = New Size(46, 16)
        rbutton3.Text = "Hex"
        AddHandler rbutton3.Click, AddressOf Me.changeByteMode
        group.Controls.Add(rbutton3)

        Dim rbutton4 As New System.Windows.Forms.RadioButton
        rbutton4.Location = New Point(152, 15)
        rbutton4.Size = New Size(64, 16)
        rbutton4.Text = "Unicode"
        AddHandler rbutton4.Click, AddressOf Me.changeByteMode
        group.Controls.Add(rbutton4)
        Me.ResumeLayout(False)
    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New ByteViewerForm)
    End Sub
End Class
'</Snippet1>