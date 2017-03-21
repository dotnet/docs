            private void SetHeaderText(object sender, System.EventArgs e)
            {
               // Set the HeaderText property.
               myDataGridColumnStyle.HeaderText = "Emp ID";
               myDataGrid.Invalidate();
            } 
            private void ResetHeaderText(object sender, System.EventArgs e)
            {
               // Reset the HeaderText property to its default value.
               myDataGridColumnStyle.ResetHeaderText();
               myDataGrid.Invalidate();
               }