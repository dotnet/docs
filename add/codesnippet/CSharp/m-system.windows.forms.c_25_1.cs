      // This example uses the Parent property and the Find method of Control to set
      // properties on the parent control of a Button and its Form. The example assumes
      // that a Button control named button1 is located within a GroupBox control. The 
      // example also assumes that the Click event of the Button control is connected to
      // the event handler method defined in the example.
      private void button1_Click(object sender, System.EventArgs e)
      {
         // Get the control the Button control is located in. In this case a GroupBox.
         Control control = button1.Parent;
         // Set the text and backcolor of the parent control.
         control.Text = "My Groupbox";
         control.BackColor = Color.Blue;
         // Get the form that the Button control is contained within.
         Form myForm = button1.FindForm();
         // Set the text and color of the form containing the Button.
         myForm.Text = "The Form of My Control";
         myForm.BackColor = Color.Red;
      }