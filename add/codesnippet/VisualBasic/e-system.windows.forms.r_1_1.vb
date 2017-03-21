   Private Sub Link_Clicked(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs)
      System.Diagnostics.Process.Start(e.LinkText)
   End Sub 'Link_Clicked