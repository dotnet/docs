   private void RegisterEventHandler()
   {
      myButton1.SizeChanged += new EventHandler(this.MyButton1_SizeChanged);
   }

   private void MyButton2_Click(object sender, System.EventArgs e)
   {
      // Set the scale for the control to the value provided.
      float scale = (float)myNumericUpDown1.Value;
      myButton1.Scale(scale);
   }

   private void MyButton1_SizeChanged(object sender, System.EventArgs e)
   {
      MessageBox.Show("The size of the 'Button' control has changed");
   }