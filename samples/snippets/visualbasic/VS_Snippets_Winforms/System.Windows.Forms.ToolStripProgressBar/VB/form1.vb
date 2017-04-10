 ' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.ComponentModel



Class FibonacciNumber
   Inherits Form
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New FibonacciNumber())
   End Sub    
   Private progressStatusStrip As StatusStrip
   Private toolStripProgressBar As ToolStripProgressBar
   Private requestedCountControl As NumericUpDown
   Private goButton As Button
   Private outputTextBox As TextBox
   Private backgroundWorker As BackgroundWorker
   Private toolStripStatusLabel As ToolStripStatusLabel
   Private requestedCount As Integer
   
   
   Public Sub New()
      [Text] = "Fibonacci"
      
      ' Prepare the StatusStrip.
      progressStatusStrip = New StatusStrip()
      toolStripProgressBar = New ToolStripProgressBar()
      toolStripProgressBar.Enabled = False
      toolStripStatusLabel = New ToolStripStatusLabel()
      progressStatusStrip.Items.Add(toolStripProgressBar)
      progressStatusStrip.Items.Add(toolStripStatusLabel)
      
      Dim flp As New FlowLayoutPanel()
      flp.Dock = DockStyle.Top
      
      Dim beforeLabel As New Label()
      beforeLabel.Text = "Calculate the first "
      beforeLabel.AutoSize = True
      flp.Controls.Add(beforeLabel)
      ' <Snippet2>
      requestedCountControl = New NumericUpDown()
      requestedCountControl.Maximum = 1000
      requestedCountControl.Minimum = 1
      requestedCountControl.Value = 100
      flp.Controls.Add(requestedCountControl)
      ' </Snippet2>
      Dim afterLabel As New Label()
      afterLabel.Text = "Numbers in the Fibonacci sequence."
      afterLabel.AutoSize = True
      flp.Controls.Add(afterLabel)
      
      goButton = New Button()
      goButton.Text = "&Go"
      AddHandler goButton.Click, AddressOf button1_Click
      flp.Controls.Add(goButton)
      
      outputTextBox = New TextBox()
      outputTextBox.Multiline = True
      outputTextBox.ReadOnly = True
      outputTextBox.ScrollBars = ScrollBars.Vertical
      outputTextBox.Dock = DockStyle.Fill
      
      Controls.Add(outputTextBox)
      Controls.Add(progressStatusStrip)
      Controls.Add(flp)
      
      backgroundWorker = New BackgroundWorker()
      backgroundWorker.WorkerReportsProgress = True
      AddHandler backgroundWorker.DoWork, AddressOf backgroundWorker1_DoWork
      AddHandler backgroundWorker.RunWorkerCompleted, AddressOf backgroundWorker1_RunWorkerCompleted
      AddHandler backgroundWorker.ProgressChanged, AddressOf backgroundWorker1_ProgressChanged
   End Sub 
    
   
    ' <snippet10>
   Private Sub backgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs)
      ' This method will run on a thread other than the UI thread.
      ' Be sure not to manipulate any Windows Forms controls created
      ' on the UI thread from this method.
      backgroundWorker.ReportProgress(0, "Working...")
      Dim lastlast As [Decimal] = 0
      Dim last As [Decimal] = 1
      Dim current As [Decimal]
      If requestedCount >= 1 Then
         AppendNumber(0)
      End If
      If requestedCount >= 2 Then
         AppendNumber(1)
      End If
      Dim i As Integer
      
      While i < requestedCount
         ' Calculate the number.
         current = lastlast + last
         ' Introduce some delay to simulate a more complicated calculation.
         System.Threading.Thread.Sleep(100)
         AppendNumber(current)
         backgroundWorker.ReportProgress(100 * i / requestedCount, "Working...")
         ' Get ready for the next iteration.
         lastlast = last
         last = current
         i += 1
      End While
      
      
      backgroundWorker.ReportProgress(100, "Complete!")
    End Sub
    ' </snippet10>
   
   
   Delegate Sub AppendNumberDelegate(number As [Decimal])
   
   ' <Snippet3>
   Private Sub AppendNumber(number As [Decimal])
      If outputTextBox.InvokeRequired Then
         outputTextBox.Invoke(New AppendNumberDelegate(AddressOf AppendNumber), number)
      Else
         outputTextBox.AppendText((number.ToString("N0") + Environment.NewLine))
      End If
   End Sub 
    ' </Snippet3>
   Private Sub backgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
      toolStripProgressBar.Value = e.ProgressPercentage
      toolStripStatusLabel.Text = e.UserState '
   End Sub 
   
   
   Private Sub backgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
      If TypeOf e.Error Is OverflowException Then
         outputTextBox.AppendText((Environment.NewLine + "**OVERFLOW ERROR, number is too large to be represented by the decimal data type**"))
      End If
      toolStripProgressBar.Enabled = False
      requestedCountControl.Enabled = True
      goButton.Enabled = True
   End Sub 
    
   
   Private Sub button1_Click(sender As Object, e As EventArgs)
      goButton.Enabled = False
      toolStripProgressBar.Enabled = True
      requestedCount = Fix(requestedCountControl.Value)
      requestedCountControl.Enabled = False
      outputTextBox.Clear()
      backgroundWorker.RunWorkerAsync()
   End Sub 
End Class 
' </Snippet1>