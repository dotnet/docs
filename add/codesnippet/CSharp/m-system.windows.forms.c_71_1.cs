   public delegate void InvokeDelegate();

   private void Invoke_Click(object sender, EventArgs e)
   {
      myTextBox.BeginInvoke(new InvokeDelegate(InvokeMethod));
   }
   public void InvokeMethod()
   {
      myTextBox.Text = "Executed the given delegate";
   }