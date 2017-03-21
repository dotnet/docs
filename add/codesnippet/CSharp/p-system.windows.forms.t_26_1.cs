      // This example assumes that the Form_Load event handling method
      // is connected to the Load event of the form.
      private void Form1_Load(object sender, System.EventArgs e)
      {
         // Create the ToolTip and associate with the Form container.
         ToolTip toolTip1 = new ToolTip();

         // Set up the delays for the ToolTip.
         toolTip1.AutoPopDelay = 5000;
         toolTip1.InitialDelay = 1000;
         toolTip1.ReshowDelay = 500;
         // Force the ToolTip text to be displayed whether or not the form is active.
         toolTip1.ShowAlways = true;
			
         // Set up the ToolTip text for the Button and Checkbox.
         toolTip1.SetToolTip(this.button1, "My button1");
         toolTip1.SetToolTip(this.checkBox1, "My checkBox1");
      }