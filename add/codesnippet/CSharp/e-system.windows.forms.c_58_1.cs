      private void Button_HideLabel(object sender, EventArgs e)
      {
         myLabel.Visible = false;
      }

      private void AddVisibleChangedEventHandler()
      {
         myLabel.VisibleChanged += new EventHandler(this.Label_VisibleChanged);
      }

      private void Label_VisibleChanged(object sender, EventArgs e)
      {
         MessageBox.Show("Visible change event raised!!!");
      }