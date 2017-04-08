
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace ProgressBarEx
    _
   '/ <summary>
   '/ Summary description for Form1.
   '/ </summary>
   Public Class Form1
      Inherits System.Windows.Forms.Form
      '/ <summary>
      '/ Required designer variable.
      '/ </summary>
      Private components As System.ComponentModel.Container = Nothing
        Private WithEvents button1 As System.Windows.Forms.Button
      Private pBar1 As New ProgressBar()
      
      
      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         
         pBar1.Bounds = New Rectangle(10, 50, 200, 20)
         Me.Controls.Add(pBar1)
      End Sub 'New
       
      
      
      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
      
      Private Function CopyFile(filename as String) As Boolean
            System.Diagnostics.Debug.WriteLine("File Being Copied = " + filename)
         Return True
      End Function 'CopyFiles
      
      
      ' <snippet1>
        Private Sub CopyWithProgress(ByVal ParamArray filenames As String())
            ' Display the ProgressBar control.
            pBar1.Visible = True
            ' Set Minimum to 1 to represent the first file being copied.
            pBar1.Minimum = 1
            ' Set Maximum to the total number of files to copy.
            pBar1.Maximum = filenames.Length
            ' Set the initial value of the ProgressBar.
            pBar1.Value = 1
            ' Set the Step property to a value of 1 to represent each file being copied.
            pBar1.Step = 1

            ' Loop through all files to copy.
            Dim x As Integer
            for x = 1 To filenames.Length - 1
                ' Copy the file and increment the ProgressBar if successful.
                If CopyFile(filenames(x - 1)) = True Then
                    ' Perform the increment on the ProgressBar.
                    pBar1.PerformStep()
                End If
            Next x
        End Sub
        ' </snippet1>

        '/ <summary>
        '/ Clean up any resources being used.
        '/ </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If (components IsNot Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose


        '
        'ToDo: Error processing original source shown below
        '
        '
        '-----^--- Pre-processor directives not translated
        '/ <summary>
        '
        'ToDo: Error processing original source shown below
        '
        '
        '--^--- Unexpected pre-processor directive
        '/ Required method for Designer support - do not modify
        '/ the contents of this method with the code editor.
        '/ </summary>
        Private Sub InitializeComponent()
            Me.button1 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(288, 72)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(120, 16)
            Me.button1.TabIndex = 0
            Me.button1.Text = "button1"
            ' 
            ' Form1
            ' 
            Me.ClientSize = New System.Drawing.Size(472, 398)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent

        '
        'ToDo: Error processing original source shown below
        '
        '
        '-----^--- Pre-processor directives not translated
        '
        'ToDo: Error processing original source shown below
        '
        '
        '--^--- Unexpected pre-processor directive
        '/ <summary>
        '/ The main entry point for the application.
        '/ </summary>
        _
        Shared Sub Main()
            Application.Run(New Form1())
        End Sub 'Main


        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
            Dim tempFiles(5) As String
            tempFiles(0) = "file1.txt"
            tempFiles(1) = "file2.txt"
            tempFiles(2) = "file3.txt"
            tempFiles(3) = "file4.txt"
            tempFiles(4) = "file5.txt"

            CopyWithProgress(tempFiles)
        End Sub 'button1_Click
    End Class 'Form1
End Namespace 'ProgressBarEx