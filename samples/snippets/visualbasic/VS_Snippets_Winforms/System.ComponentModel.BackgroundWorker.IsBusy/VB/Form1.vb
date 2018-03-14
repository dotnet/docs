' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml

Public Class Form1
    Inherits Form

    Private WithEvents downloadButton As Button
    Private WithEvents progressBar1 As ProgressBar
    Private WithEvents backgroundWorker1 As BackgroundWorker
    Private document As XmlDocument = Nothing

    Public Sub New()
        InitializeComponent()
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
    End Sub

    ' <snippet2>
    Private Sub downloadButton_Click( _
        ByVal sender As Object, _
        ByVal e As EventArgs) _
        Handles downloadButton.Click

        ' Start the download operation in the background.
        Me.backgroundWorker1.RunWorkerAsync()

        ' Disable the button for the duration of the download.
        Me.downloadButton.Enabled = False

        ' Once you have started the background thread you 
        ' can exit the handler and the application will 
        ' wait until the RunWorkerCompleted event is raised.

        ' If you want to do something else in the main thread,
        ' such as update a progress bar, you can do so in a loop 
        ' while checking IsBusy to see if the background task is
        ' still running.
        While Me.backgroundWorker1.IsBusy
            progressBar1.Increment(1)
            ' Keep UI messages moving, so the form remains 
            ' responsive during the asynchronous operation.
            Application.DoEvents()
        End While
    End Sub
    ' </snippet2>

    ' <snippet3>
    Private Sub backgroundWorker1_DoWork( _
        ByVal sender As Object, _
        ByVal e As DoWorkEventArgs) _
        Handles backgroundWorker1.DoWork

        document = New XmlDocument()

        ' Replace this file name with a valid file name.
        document.Load("http://www.tailspintoys.com/sample.xml")

        ' Uncomment the following line to
        ' simulate a noticeable latency.
        'Thread.Sleep(5000);
    End Sub
    ' </snippet3>

    ' <snippet4>
    Private Sub backgroundWorker1_RunWorkerCompleted( _
        ByVal sender As Object, _
        ByVal e As RunWorkerCompletedEventArgs) _
        Handles backgroundWorker1.RunWorkerCompleted

        ' Set progress bar to 100% in case it isn't already there.
        progressBar1.Value = 100

        If e.Error Is Nothing Then
            MessageBox.Show(document.InnerXml, "Download Complete")
        Else
            MessageBox.Show("Failed to download file", "Download failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Enable the download button and reset the progress bar.
        Me.downloadButton.Enabled = True
        progressBar1.Value = 0
    End Sub
    ' </snippet4>

#Region "Windows Form Designer generated code"
    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
    ' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
        Me.downloadButton = New System.Windows.Forms.Button
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'downloadButton
        '
        Me.downloadButton.Location = New System.Drawing.Point(12, 12)
        Me.downloadButton.Name = "downloadButton"
        Me.downloadButton.Size = New System.Drawing.Size(100, 23)
        Me.downloadButton.TabIndex = 0
        Me.downloadButton.Text = "Download file"
        Me.downloadButton.UseVisualStyleBackColor = True
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(12, 50)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(100, 26)
        Me.progressBar1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(136, 104)
        Me.Controls.Add(Me.downloadButton)
        Me.Controls.Add(Me.progressBar1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class


Public Class Program

    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>