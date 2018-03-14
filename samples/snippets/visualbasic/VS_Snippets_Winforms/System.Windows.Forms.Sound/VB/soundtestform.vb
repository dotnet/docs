' <snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Media
Imports System.Windows.Forms

Public Class SoundTestForm
    Inherits System.Windows.Forms.Form
    Private label1 As System.Windows.Forms.Label
    Private WithEvents filepathTextbox As System.Windows.Forms.TextBox
    Private WithEvents playOnceSyncButton As System.Windows.Forms.Button
    Private WithEvents playOnceAsyncButton As System.Windows.Forms.Button
    Private WithEvents playLoopAsyncButton As System.Windows.Forms.Button
    Private WithEvents selectFileButton As System.Windows.Forms.Button

    Private WithEvents stopButton As System.Windows.Forms.Button
    Private statusBar As System.Windows.Forms.StatusBar
    Private WithEvents loadSyncButton As System.Windows.Forms.Button
    Private WithEvents loadAsyncButton As System.Windows.Forms.Button
    Private player As SoundPlayer


    Public Sub New()

        ' Initialize Forms Designer generated code.
        InitializeComponent()

        ' Disable playback controls until a valid .wav file 
        ' is selected.
        EnablePlaybackControls(False)

        ' Set up the status bar and other controls.
        InitializeControls()

        ' Set up the SoundPlayer object.
        InitializeSound()

    End Sub


    ' Sets up the status bar and other controls.
    Private Sub InitializeControls()

        ' Set up the status bar.
        Dim panel As New StatusBarPanel
        panel.BorderStyle = StatusBarPanelBorderStyle.Sunken
        panel.Text = "Ready."
        panel.AutoSize = StatusBarPanelAutoSize.Spring
        Me.statusBar.ShowPanels = True
        Me.statusBar.Panels.Add(panel)

    End Sub


    ' Sets up the SoundPlayer object.
    Private Sub InitializeSound()

        ' Create an instance of the SoundPlayer class.
        player = New SoundPlayer

        ' Listen for the LoadCompleted event.
        AddHandler player.LoadCompleted, AddressOf player_LoadCompleted

        ' Listen for the SoundLocationChanged event.
        AddHandler player.SoundLocationChanged, AddressOf player_LocationChanged

    End Sub


    Private Sub selectFileButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles selectFileButton.Click

        ' Create a new OpenFileDialog.
        Dim dlg As New OpenFileDialog

        ' Make sure the dialog checks for existence of the 
        ' selected file.
        dlg.CheckFileExists = True

        ' Allow selection of .wav files only.
        dlg.Filter = "WAV files (*.wav)|*.wav"
        dlg.DefaultExt = ".wav"

        ' Activate the file selection dialog.
        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ' Get the selected file's path from the dialog.
            Me.filepathTextbox.Text = dlg.FileName

            ' Assign the selected file's path to the SoundPlayer object.
            player.SoundLocation = filepathTextbox.Text
        End If

    End Sub


    ' Convenience method for setting message text in 
    ' the status bar.
    Private Sub ReportStatus(ByVal statusMessage As String)

        ' If the caller passed in a message...
        If (statusMessage IsNot Nothing) AndAlso _
            statusMessage <> [String].Empty Then
            ' ...post the caller's message to the status bar.
            Me.statusBar.Panels(0).Text = statusMessage
        End If

    End Sub


    ' Enables and disables play controls.
    Private Sub EnablePlaybackControls(ByVal enabled As Boolean)

        Me.playOnceSyncButton.Enabled = enabled
        Me.playOnceAsyncButton.Enabled = enabled
        Me.playLoopAsyncButton.Enabled = enabled
        Me.stopButton.Enabled = enabled

    End Sub


    Private Sub filepathTextbox_TextChanged(ByVal sender As Object, _
        ByVal e As EventArgs) Handles filepathTextbox.TextChanged

        ' Disable playback controls until the new .wav is loaded.
        EnablePlaybackControls(False)

    End Sub


    Private Sub loadSyncButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles loadSyncButton.Click

        ' Disable playback controls until the .wav is successfully
        ' loaded. The LoadCompleted event handler will enable them.
        EnablePlaybackControls(False)

        ' <snippet2>
        Try
            ' Assign the selected file's path to the SoundPlayer object.
            player.SoundLocation = filepathTextbox.Text

            ' Load the .wav file.
            player.Load()
        Catch ex As Exception
            ReportStatus(ex.Message)
        End Try
        ' </snippet2>

    End Sub


    Private Sub loadAsyncButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles loadAsyncButton.Click

        ' Disable playback controls until the .wav is successfully
        ' loaded. The LoadCompleted event handler will enable them.
        EnablePlaybackControls(False)

        ' <snippet3>
        Try
            ' Assign the selected file's path to the SoundPlayer object.
            player.SoundLocation = Me.filepathTextbox.Text

            ' Load the .wav file.
            player.LoadAsync()
        Catch ex As Exception
            ReportStatus(ex.Message)
        End Try
        ' </snippet3>

    End Sub


    ' Synchronously plays the selected .wav file once.
    ' If the file is large, UI response will be visibly 
    ' affected.
    Private Sub playOnceSyncButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles playOnceSyncButton.Click

        ' <snippet4>
        ReportStatus("Playing .wav file synchronously.")
        player.PlaySync()
        ReportStatus("Finished playing .wav file synchronously.")
        ' </snippet4>
    End Sub


    ' Asynchronously plays the selected .wav file once.
    Private Sub playOnceAsyncButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles playOnceAsyncButton.Click

        ' <snippet5>
        ReportStatus("Playing .wav file asynchronously.")
        player.Play()
        ' </snippet5>

    End Sub


    ' Asynchronously plays the selected .wav file until the user
    ' clicks the Stop button.
    Private Sub playLoopAsyncButton_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles playLoopAsyncButton.Click

        ' <snippet6>
        ReportStatus("Looping .wav file asynchronously.")
        player.PlayLooping()
        ' </snippet6>

    End Sub


    ' Stops the currently playing .wav file, if any.
    Private Sub stopButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles stopButton.Click

        ' <snippet7>
        player.Stop()
        ReportStatus("Stopped by user.")
        ' </snippet7>

    End Sub


    ' <snippet8>
    ' Handler for the LoadCompleted event.
    Private Sub player_LoadCompleted(ByVal sender As Object, _
        ByVal e As AsyncCompletedEventArgs)

        Dim message As String = [String].Format("LoadCompleted: {0}", _
            Me.filepathTextbox.Text)
        ReportStatus(message)
        EnablePlaybackControls(True)

    End Sub
    ' </snippet8>

    ' <snippet9>
    ' Handler for the SoundLocationChanged event.
    Private Sub player_LocationChanged(ByVal sender As Object, _
        ByVal e As EventArgs)
        Dim message As String = [String].Format("SoundLocationChanged: {0}", _
            player.SoundLocation)
        ReportStatus(message)
    End Sub
    ' </snippet9>

    ' <snippet10>
    Private Sub playSoundFromResource(ByVal sender As Object, _
    ByVal e As EventArgs)
        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim s As System.IO.Stream = a.GetManifestResourceStream("<AssemblyName>.chimes.wav")
        Dim player As SoundPlayer = New SoundPlayer(s)
        player.Play()
    End Sub
    ' </snippet10>

    Private Sub InitializeComponent()
        Me.filepathTextbox = New System.Windows.Forms.TextBox
        Me.selectFileButton = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.loadSyncButton = New System.Windows.Forms.Button
        Me.playOnceSyncButton = New System.Windows.Forms.Button
        Me.playOnceAsyncButton = New System.Windows.Forms.Button
        Me.stopButton = New System.Windows.Forms.Button
        Me.playLoopAsyncButton = New System.Windows.Forms.Button
        Me.statusBar = New System.Windows.Forms.StatusBar
        Me.loadAsyncButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        ' 
        ' filepathTextbox
        ' 
        Me.filepathTextbox.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.filepathTextbox.Location = New System.Drawing.Point(7, 25)
        Me.filepathTextbox.Name = "filepathTextbox"
        Me.filepathTextbox.Size = New System.Drawing.Size(263, 20)
        Me.filepathTextbox.TabIndex = 1
        Me.filepathTextbox.Text = ""
        ' 
        ' selectFileButton
        ' 
        Me.selectFileButton.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.selectFileButton.Location = New System.Drawing.Point(276, 25)
        Me.selectFileButton.Name = "selectFileButton"
        Me.selectFileButton.Size = New System.Drawing.Size(23, 21)
        Me.selectFileButton.TabIndex = 2
        Me.selectFileButton.Text = "..."
        ' 
        ' label1
        ' 
        Me.label1.Location = New System.Drawing.Point(7, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(145, 17)
        Me.label1.TabIndex = 3
        Me.label1.Text = ".wav path or URL:"
        ' 
        ' loadSyncButton
        ' 
        Me.loadSyncButton.Location = New System.Drawing.Point(7, 53)
        Me.loadSyncButton.Name = "loadSyncButton"
        Me.loadSyncButton.Size = New System.Drawing.Size(142, 23)
        Me.loadSyncButton.TabIndex = 4
        Me.loadSyncButton.Text = "Load Synchronously"
        ' 
        ' playOnceSyncButton
        ' 
        Me.playOnceSyncButton.Location = New System.Drawing.Point(7, 86)
        Me.playOnceSyncButton.Name = "playOnceSyncButton"
        Me.playOnceSyncButton.Size = New System.Drawing.Size(142, 23)
        Me.playOnceSyncButton.TabIndex = 5
        Me.playOnceSyncButton.Text = "Play Once Synchronously"
        ' 
        ' playOnceAsyncButton
        ' 
        Me.playOnceAsyncButton.Location = New System.Drawing.Point(149, 86)
        Me.playOnceAsyncButton.Name = "playOnceAsyncButton"
        Me.playOnceAsyncButton.Size = New System.Drawing.Size(147, 23)
        Me.playOnceAsyncButton.TabIndex = 6
        Me.playOnceAsyncButton.Text = "Play Once Asynchronously"
        ' 
        ' stopButton
        ' 
        Me.stopButton.Location = New System.Drawing.Point(149, 109)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(147, 23)
        Me.stopButton.TabIndex = 7
        Me.stopButton.Text = "Stop"
        ' 
        ' playLoopAsyncButton
        ' 
        Me.playLoopAsyncButton.Location = New System.Drawing.Point(7, 109)
        Me.playLoopAsyncButton.Name = "playLoopAsyncButton"
        Me.playLoopAsyncButton.Size = New System.Drawing.Size(142, 23)
        Me.playLoopAsyncButton.TabIndex = 8
        Me.playLoopAsyncButton.Text = "Loop Asynchronously"
        ' 
        ' statusBar
        ' 
        Me.statusBar.Location = New System.Drawing.Point(0, 146)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(306, 22)
        Me.statusBar.SizingGrip = False
        Me.statusBar.TabIndex = 9
        Me.statusBar.Text = "(no status)"
        ' 
        ' loadAsyncButton
        ' 
        Me.loadAsyncButton.Location = New System.Drawing.Point(149, 53)
        Me.loadAsyncButton.Name = "loadAsyncButton"
        Me.loadAsyncButton.Size = New System.Drawing.Size(147, 23)
        Me.loadAsyncButton.TabIndex = 10
        Me.loadAsyncButton.Text = "Load Asynchronously"
        ' 
        ' SoundTestForm
        '
        Me.ClientSize = New System.Drawing.Size(306, 168)
        Me.Controls.Add(loadAsyncButton)
        Me.Controls.Add(statusBar)
        Me.Controls.Add(playLoopAsyncButton)
        Me.Controls.Add(stopButton)
        Me.Controls.Add(playOnceAsyncButton)
        Me.Controls.Add(playOnceSyncButton)
        Me.Controls.Add(loadSyncButton)
        Me.Controls.Add(label1)
        Me.Controls.Add(selectFileButton)
        Me.Controls.Add(filepathTextbox)
        Me.MinimumSize = New System.Drawing.Size(310, 165)
        Me.Name = "SoundTestForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Sound API Test Form"
        Me.ResumeLayout(False)
    End Sub 'InitializeComponent

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New SoundTestForm)
    End Sub
End Class 'SoundTestForm
' </snippet1>