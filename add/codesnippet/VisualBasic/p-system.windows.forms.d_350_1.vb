   ' Create an instance of the 'AllowNavigationChanged' EventHandler.
   Private Sub CallAllowNavigationChanged()
      AddHandler myDataGrid.AllowNavigationChanged, AddressOf Grid_AllowNavChange
   End Sub 'CallAllowNavigationChanged
   
   
   ' Set the 'AllowNavigation' property on click of a button.
    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If myDataGrid.AllowNavigation = True Then
            myDataGrid.AllowNavigation = False
        Else
            myDataGrid.AllowNavigation = True
        End If
    End Sub 'myButton_Click
    
   ' Raise the event when 'AllowNavigation' property is changed.
    Private Sub Grid_AllowNavChange(ByVal sender As Object, ByVal e As EventArgs)
        Dim myString As String = "AllowNavigationChanged event raised, Navigation "
        Dim myBool As Boolean = myDataGrid.AllowNavigation
        ' Create appropriate alert message.
        myString = myString + IIF(mybool, "is", "is not") + "allowed"
        ' Show information about navigation.
        MessageBox.Show(myString, "Navigation information")
    End Sub 'Grid_AllowNavChange
   