        // The method defines the behavior of the DoubleClick 
        // event. It shows a MessageBox with the item's text.
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            string msg = String.Format("Item: {0}", this.Text);

            MessageBox.Show(msg);
        }