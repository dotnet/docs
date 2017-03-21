Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

   Dim myControl As Control
   myControl = sender

   ' Ensure the Form remains square (Height = Width).
   If myControl.Size.Height <> myControl.Size.Width Then
      myControl.Size = New Size(myControl.Size.Width, myControl.Size.Width)
   End If
End Sub