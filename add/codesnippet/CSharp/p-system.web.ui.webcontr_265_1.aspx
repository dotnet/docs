  protected void TemplatePagerField_OnPagerCommand(object sender, DataPagerCommandEventArgs e)
  {     
      // Get the new page number 
      TextBox PageNumberTextBox = (TextBox)e.Item.FindControl("PageNumberTextBox");
      int newPageNumber = -1;
      try
      {
        newPageNumber = Convert.ToInt32(PageNumberTextBox.Text.Trim());
      }
      catch (FormatException)
      {
        Message.Text = "Invalid page number.";
        return;
      }
      catch (OverflowException)
      {
        Message.Text = "Invalid page number.";
        return;
      }

      int newIndex = (newPageNumber - 1) * e.Item.Pager.PageSize;
      //Verify if the new index is valid
      if (newIndex >= 0 && newIndex <= e.TotalRowCount)
      {
        //Set the new start index and maximum rows
        e.NewStartRowIndex = newIndex;
        e.NewMaximumRows = e.Item.Pager.MaximumRows;
      }
      else
        Message.Text = "Invalid page number.";
  }