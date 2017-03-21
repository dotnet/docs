      // Get the width of row header.
      private void button9_Click(object sender, EventArgs e)
      {
         Int32 myRowHeaderWidth = myDataGrid.RowHeaderWidth;
         MessageBox.Show("Width of row headers is: "+ 
                  myRowHeaderWidth.ToString(), "Message",
                  MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
      }      