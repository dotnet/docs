        ' Use the Contains method to check whether
        ' a child control exists, and if it does,
        ' use the Remove method to delete it.        
        If myButton.Controls.Contains(myChildControl)
           myButton.Controls.Remove(myChildControl)
           msgRemove.Text = "You removed myLiteralControl."
        Else
           msgRemove.Text="The control to remove does not exist." 
        End If