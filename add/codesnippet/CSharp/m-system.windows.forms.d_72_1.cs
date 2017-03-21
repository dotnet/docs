
      private void Button_Click(object sender, EventArgs e)
      {
           // Change the 'GridLineColor'.
           myDataTableStyle.GridLineColor = Color.Blue;
      }

      private void Button1_Click(object sender, EventArgs e)
      {
         // Reset the 'GridLineColor' to its orginal color.
          myDataTableStyle.ResetGridLineColor();
      }