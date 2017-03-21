   ' Set the 'FixedHeight' and 'FixedWidth' styles to false.
   Private Sub MyForm_Load(sender As Object, e As EventArgs)
      Me.SetStyle(ControlStyles.FixedHeight, False)
      Me.SetStyle(ControlStyles.FixedWidth, False)
   End Sub 'MyForm_Load

   Private Sub RegisterEventHandler()
      AddHandler Me.StyleChanged, AddressOf MyForm_StyleChanged
   End Sub 'RegisterEventHandler

   ' Handle the 'StyleChanged' event for the 'Form'.
   Private Sub MyForm_StyleChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The style releated to the 'Form' has been changed")
   End Sub 'MyForm_StyleChanged