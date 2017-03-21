
      private void Button_Click(object sender, EventArgs e)
      {
         // Change the color of 'HeaderBack'.
         myDataTableStyle.HeaderBackColor = Color.LightPink;
      }

      private void Button1_Click(object sender, EventArgs e)
      {
          // Reset the 'HeaderBack' to its origanal color.
          myDataTableStyle.ResetHeaderBackColor();
      }