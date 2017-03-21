      private void AddContextMenuChangedHandler()
      {
         this.myTextBox.ContextMenuChanged += new EventHandler(TextBox_ContextMenuChanged);
      }

      private void TextBox_ContextMenuChanged(object sender, EventArgs e)
      {
         MessageBox.Show("Shortcut menu of TextBox is changed.");
      }