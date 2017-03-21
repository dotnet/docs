      // Attach to event handler.
      private void AttachReadOnlyChanged()
      {
         this.myDataGrid.ReadOnlyChanged += new EventHandler(this.myDataGrid_ReadOnlyChanged);
      }
      // Check if the 'ReadOnly' property is changed.
      private void myDataGrid_ReadOnlyChanged(object sender, EventArgs e)
      {   
         string strMessage = "false";
         if(myDataGrid.ReadOnly == true)
            strMessage = "true";

         MessageBox.Show("Read only changed to "+strMessage,
            "Message",   MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);         
      }
      // Toggle the 'ReadOnly' property.
      private void button2_Click(object sender, EventArgs e)
      {
         if(myDataGrid.ReadOnly == true)
            myDataGrid.ReadOnly = false;
         else
            myDataGrid.ReadOnly = true;
      }      