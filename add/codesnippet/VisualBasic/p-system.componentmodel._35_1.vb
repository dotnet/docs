   Private Sub backgroundWorker1_DoWork( _
   sender As Object, e As DoWorkEventArgs) _
   Handles backgroundWorker1.DoWork

      ' Do not access the form's BackgroundWorker reference directly.
      ' Instead, use the reference provided by the sender parameter.
      Dim bw As BackgroundWorker = CType( sender, BackgroundWorker )
      
      ' Extract the argument.
      Dim arg As Integer = Fix(e.Argument)
      
      ' Start the time-consuming operation.
      e.Result = TimeConsumingOperation(bw, arg)
      
      ' If the operation was canceled by the user, 
      ' set the DoWorkEventArgs.Cancel property to true.
      If bw.CancellationPending Then
         e.Cancel = True
      End If

   End Sub   