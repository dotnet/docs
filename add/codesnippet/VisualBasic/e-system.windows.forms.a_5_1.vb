Private Sub ApplicationContext1_ThreadExit(sender as Object, e as EventArgs) _ 
     Handles ApplicationContext1.ThreadExit

   MessageBox.Show("You are in the ApplicationContext.ThreadExit event.")

End Sub