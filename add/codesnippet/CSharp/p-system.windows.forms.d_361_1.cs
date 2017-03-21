      // Attach to event handler.
      private void AttachFlatModeChanged()
      {
         this.myDataGrid.FlatModeChanged += new EventHandler(this.myDataGrid_FlatModeChanged);
      }
      // Check if the 'FlatMode' property is changed.
      private void myDataGrid_FlatModeChanged(object sender, EventArgs e)
      {
         string strMessage = "false";
         if(myDataGrid.FlatMode == true)
            strMessage = "true";

         MessageBox.Show("Flat mode changed to "+strMessage,
            "Message",   MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
         
      }
      // Toggle the 'FlatMode'.
      private void button1_Click(object sender, EventArgs e)
      {
         if(myDataGrid.FlatMode == true)
            myDataGrid.FlatMode = false;
         else
            myDataGrid.FlatMode = true;
      }