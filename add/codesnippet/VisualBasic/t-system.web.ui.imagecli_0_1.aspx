      ' Define the event handler that uses coordinate information through ImageClickEventArgs.
      Sub ImageButton_Click(sender As Object, e As ImageClickEventArgs) 
         Label1.Text = "You clicked the ImageButton control at the coordinates: (" & _ 
                       e.X.ToString() & ", " & e.Y.ToString() & ")"
      End Sub