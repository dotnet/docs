   private void CallParentRowsLabelStyleChanged()
   {
      myDataGrid.ParentRowsLabelStyleChanged +=
         new EventHandler(DataGridParentRowsLabelStyleChanged_Clicked);
   }

   // Set the 'ParentRowsLabelStyle' property on click of a button.
   private void ToggleStyle_Clicked(object sender, EventArgs e)
   {
      if (myDataGrid.ParentRowsLabelStyle.ToString() == "Both")
         myDataGrid.ParentRowsLabelStyle = DataGridParentRowsLabelStyle.TableName;
      else
         myDataGrid.ParentRowsLabelStyle = DataGridParentRowsLabelStyle.Both;
   }

   // raise the event when 'ParentRowsLabelStyle' property is changed.
   private void DataGridParentRowsLabelStyleChanged_Clicked(object sender, EventArgs e)
   {
      string myMessage = "ParentRowsLabelStyleChanged event raised, LabelStyle is : ";
      // Get the state of 'ParentRowsLabelStyle' property.
      string myLabelStyle = myDataGrid.ParentRowsLabelStyle.ToString();
      myMessage += myLabelStyle;

      MessageBox.Show(myMessage, "ParentRowsLabelStyle information");
   }