      Protected Overrides Sub CreateChildControls()
         ' Creates a new ControlCollection. 
         Me.CreateControlCollection()
         
         ' Create child controls.
         Dim firstControl As New ChildControl()
         firstControl.Message = "FirstChildControl"
         
         Dim secondControl As New ChildControl()
         secondControl.Message = "SecondChildControl"
         
         Controls.Add(firstControl)
         Controls.Add(secondControl)
         
         ' Prevent child controls from being created again.
         ChildControlsCreated = True
      End Sub 'CreateChildControls
      
      