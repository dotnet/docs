Option Strict On

' Requires:
'   SaveSaveFileDialog1 named SaveSaveFileDialog11 (Default name)
'   Button named Button1 (default name)
'   TextBox named TextBox1 (default name)
'
' <Snippet1>
Imports System.IO
Imports System.Timers

Public Class Form1
   ' Create the timer to fire at a 60-second interval.
   Dim WithEvents timer As New System.Timers.Timer(60000)
   Dim sw As StreamWriter
   Dim hasChanged As Boolean
   Dim dialogIsOpen As Boolean = False
   Dim elapsedMinutes As Integer = 0
   ' Cache the text box internally without saving it.
   Dim txt As String = ""

   Public Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
      Me.Text = "Quick Text Editor"
      Button1.Text = "Save"
      TextBox1.Multiline = True

      ' Configure the SaveFile dialog
      SaveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
      SaveFileDialog1.RestoreDirectory = True

      ' Create a timer with a 1-minute interval
      timer = New Timer(2000)
      ' Synchronize the timer with the text box
      timer.SynchronizingObject = Me
      ' Start the timer
      timer.AutoReset = True
   End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
      hasChanged = True
      timer.Start()
   End Sub
   Friend Sub PromptForSave(sender As Object, e As ElapsedEventArgs) _
      Handles timer.Elapsed
      If hasChanged And Not dialogIsOpen Then
         elapsedMinutes += 1
         dialogIsOpen = True
         If MsgBox(String.Format("{0} minutes have elapsed since the text was saved. Save it now? ",
                                 elapsedMinutes), MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question,
                   "Save Text") = MsgBoxResult.Yes Then
            If dialogIsOpen Then
               Button1_Click(Me, EventArgs.Empty)
               dialogIsOpen = False
            End If
         End If
      End If
   End Sub

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      If String.IsNullOrEmpty(SaveFileDialog1.FileName) Then
         If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            sw = New StreamWriter(SaveFileDialog1.FileName, False)
         End If
      End If
      txt = TextBox1.Text
      hasChanged = False
      elapsedMinutes = 0
      timer.Stop()
   End Sub

   Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If sw IsNot Nothing Then
         sw.Write(txt)
         sw.Close()
      End If
   End Sub
End Class
' </Snippet1>

