   Private time As New Timer()

   ' Call this method from the constructor of the form.
   Private Sub InitializeMyTimer()
      ' Set the interval for the timer.
      time.Interval = 250
      ' Connect the Tick event of the timer to its event handler.
      AddHandler time.Tick, AddressOf IncreaseProgressBar
      ' Start the timer.
      time.Start()
   End Sub


   Private Sub IncreaseProgressBar(ByVal sender As Object, ByVal e As EventArgs)
      ' Increment the value of the ProgressBar a value of one each time.
      ProgressBar1.Increment(1)
      ' Display the textual value of the ProgressBar in the StatusBar control's first panel.
      statusBarPanel1.Text = ProgressBar1.Value.ToString() + "% Completed"
      ' Determine if we have completed by comparing the value of the Value property to the Maximum value.
      If ProgressBar1.Value = ProgressBar1.Maximum Then
         ' Stop the timer.
         time.Stop()
      End If
   End Sub