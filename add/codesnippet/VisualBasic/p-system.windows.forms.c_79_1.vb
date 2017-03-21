Private Sub AboutDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
   ' Display the application information in the label.
   Me.labelVersionInfo.Text = _
      Me.CompanyName + "  " + _
      Me.ProductName + "  Version: " + _
      Me.ProductVersion
   End Sub