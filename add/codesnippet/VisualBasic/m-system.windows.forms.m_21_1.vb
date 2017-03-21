   Private Sub MenuSelected(ByVal sender As Object, ByVal e As System.EventArgs) _
                        Handles menuOpen.Select, menuExit.Select, menuSave.Select
      If sender Is menuOpen Then
         StatusBar1.Panels(0).Text = "Opens a file to edit"
      Else
         If sender Is menuSave Then
            StatusBar1.Panels(0).Text = "Saves the current file"
         Else
            If sender Is menuExit Then
               StatusBar1.Panels(0).Text = "Exits the application"
            Else
               StatusBar1.Panels(0).Text = "Ready"
            End If
         End If
      End If
   End Sub