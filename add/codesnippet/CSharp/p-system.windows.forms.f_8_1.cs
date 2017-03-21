      private void AddButtonsToMyChildren()
      {
         // If there are child forms in the parent form, add Button controls to them.
         for (int x =0; x < this.MdiChildren.Length;x++)
         {
            // Create a temporary Button control to add to the child form.
            Button tempButton = new Button();
            // Set the location and text of the Button control.
            tempButton.Location = new Point(10,10);
            tempButton.Text = "OK";
            // Create a temporary instance of a child form (Form 2 in this case).
            Form tempChild = (Form)this.MdiChildren[x];
            // Add the Button control to the control collection of the form.
            tempChild.Controls.Add(tempButton);
         }
      }