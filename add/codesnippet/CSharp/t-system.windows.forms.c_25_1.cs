   // Set the 'FixedHeight' and 'FixedWidth' styles to false.
   private void MyForm_Load(object sender, EventArgs e)
   {
      this.SetStyle(ControlStyles.FixedHeight, false);
      this.SetStyle(ControlStyles.FixedWidth, false);
   }

   private void RegisterEventHandler()
   {
      this.StyleChanged += new EventHandler(MyForm_StyleChanged);
   }

   // Handle the 'StyleChanged' event for the 'Form'.
   private void MyForm_StyleChanged(object sender, EventArgs e)
   {
      MessageBox.Show("The style releated to the 'Form' has been changed");
   }