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