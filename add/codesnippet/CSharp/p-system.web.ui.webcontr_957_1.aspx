      void Item_Clicked(Object Sender, EventArgs e)
      {
labelDisplay.Text = "Using item indexer.<br />";
labelDisplay.Text += "The Items collection contains: <br />";

// Display the elements of the RepeaterItemCollection using the indexer.
RepeaterItemCollection  myItemCollection = myRepeater.Items;
for(int index=0;index < myItemCollection.Count;index++)
labelDisplay.Text += ((DataBoundLiteralControl)
   myItemCollection[index].Controls[0]).Text + "<br />";
      }