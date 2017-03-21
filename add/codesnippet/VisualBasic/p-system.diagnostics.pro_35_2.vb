      Private button1 As MyButton
      Private Sub button1_Click(sender As Object, e As EventArgs)
         Dim myProcess As New Process()
         Dim myProcessStartInfo As New ProcessStartInfo("mspaint")
         myProcess.StartInfo = myProcessStartInfo
         myProcess.Start()
         AddHandler myProcess.Exited, AddressOf MyProcessExited
         ' Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
         myProcess.EnableRaisingEvents = True
         ' Set method handling the exited event to be called  ;
         ' on the same thread on which MyButton was created.
         myProcess.SynchronizingObject = button1
         MessageBox.Show("Waiting for the process 'mspaint' to exit....")
         myProcess.WaitForExit()
         myProcess.Close()
      End Sub 'button1_Click
      Private Sub MyProcessExited(source As Object, e As EventArgs)
         MessageBox.Show("The process has exited.")
      End Sub 'MyProcessExited
   End Class 'Form1

   Public Class MyButton
      Inherits Button

   End Class 'MyButton