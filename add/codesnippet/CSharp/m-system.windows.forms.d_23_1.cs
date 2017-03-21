            private void BtnSetForeColor_Click(Object sender, EventArgs e)
            {
               // Set the foreground color of table.
               myDataGridTableStyle.ForeColor=Color.Blue;
               myDataGrid.TableStyles.Add(myDataGridTableStyle);
            }
           private void BtnResetForeColor_Click(Object sender, EventArgs e)
           {
              // Reset the foreground color of table to its default value.
              myDataGridTableStyle.ResetForeColor();
           }