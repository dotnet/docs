
      protected override void CreateChildControls()
      {               
         // Creates a new ControlCollection. 
         this.CreateControlCollection();

         // Create child controls.
          ChildControl firstControl = new ChildControl();
         firstControl.Message = "FirstChildControl";

         ChildControl secondControl = new ChildControl();
         secondControl.Message = "SecondChildControl";
         
         Controls.Add(firstControl);
         Controls.Add(secondControl);

         // Prevent child controls from being created again.
         ChildControlsCreated = true;
      }
