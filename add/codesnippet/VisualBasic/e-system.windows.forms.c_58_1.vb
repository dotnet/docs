      Private Sub Button_HideLabel(ByVal sender As Object, ByVal e As EventArgs)
         myLabel.Visible = False
      End Sub 'Button_HideLabel


      Private Sub AddVisibleChangedEventHandler()
         AddHandler myLabel.VisibleChanged, AddressOf Label_VisibleChanged
      End Sub 'AddVisibleChangedEventHandler


      Private Sub Label_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
         MessageBox.Show("Visible change event raised!!!")
      End Sub 'Label_VisibleChanged