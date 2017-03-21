      private void PopupMyMenu(object sender, System.EventArgs e)
      {
         if (textBox1.Enabled == false || textBox1.Focused == false ||
            textBox1.SelectedText.Length == 0)
         {
            menuCut.Enabled = false;
            menuCopy.Enabled = false;
            menuDelete.Enabled = false;
         }
         else
         {
            menuCut.Enabled = true;
            menuCopy.Enabled = true;
            menuDelete.Enabled = true;
         }
      }