   // Instantiate the EventHandler.
   public void AttachRowHeaderVisibleChanged()
   {
      myDataGridTableStyle.RowHeadersVisibleChanged += new EventHandler (MyDelegateRowHeadersVisibleChanged);
   }

   // raise the event when RowHeadersVisible property is changed.
   private void MyDelegateRowHeadersVisibleChanged(object sender, EventArgs e)
   {
      string myString = "'RowHeadersVisibleChanged' event raised, Row Headers are";
      if (myDataGridTableStyle.RowHeadersVisible)
         myString += " visible";
      else
         myString += " not visible";

      MessageBox.Show(myString, "RowHeader information");
   }

   // raise the event when a button is clicked.
   private void myButton_Click(object sender, System.EventArgs e)
   {
      if (myDataGridTableStyle.RowHeadersVisible)
         myDataGridTableStyle.RowHeadersVisible = false;
      else
         myDataGridTableStyle.RowHeadersVisible = true;
   }