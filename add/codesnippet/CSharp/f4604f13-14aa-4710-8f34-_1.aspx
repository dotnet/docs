      void CopyTo_Clicked(Object Sender, EventArgs e)
      {
labelDisplay.Text = "Invoking CopyTo method.<br />";
labelDisplay.Text += "The Items collection contains: <br />";

// Display the elements of the RepeaterItemCollection using the CopyTo method.
RepeaterItemCollection  myItemCollection = myRepeater.Items;
RepeaterItem[] myItemArray = new RepeaterItem[myItemCollection.Count];
myItemCollection.CopyTo(myItemArray,0);
for(int index=0;index < myItemArray.Length;index++)
{
   RepeaterItem myItem = (RepeaterItem)myItemArray.GetValue(index);
   labelDisplay.Text += ((DataBoundLiteralControl)
      myItem.Controls[0]).Text + "<br />";
}
      }