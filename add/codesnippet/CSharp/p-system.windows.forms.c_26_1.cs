private void Form1_Load(object sender, EventArgs e)
{
   // Display the hand cursor when the mouse pointer
   // is over the combo box drop-down button. 
   comboBox1.Cursor = Cursors.Hand;

   // Fill the combo box with all the logical 
   // drives available to the user.
   try
   {
      foreach(string logicalDrive in Environment.GetLogicalDrives() )
      {
         comboBox1.Items.Add(logicalDrive);
      }
   }
   catch(Exception ex)
   {
      MessageBox.Show(ex.Message);
   }
}