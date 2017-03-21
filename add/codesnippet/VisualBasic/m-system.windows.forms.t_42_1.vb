   ' The method defines the behavior of the DoubleClick 
   ' event. It shows a MessageBox with the item's text.
   Protected Overrides Sub OnDoubleClick(e As EventArgs)
      MyBase.OnDoubleClick(e)
      
      Dim msg As String = String.Format("Item: {0}", Me.Text)
      
      MessageBox.Show(msg)
    End Sub