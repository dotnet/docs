      void GetEnumerator_Clicked(Object Sender, EventArgs e)
      {
labelDisplay.Text = "Invoking GetEnumerator method.<br />";
labelDisplay.Text += "The Items collection contains: <br />";

// Display the elements of the RepeaterItemCollection using GetEnumerator.
RepeaterItemCollection  myItemCollection = myRepeater.Items;
IEnumerator myEnumertor = myItemCollection.GetEnumerator();
while(myEnumertor.MoveNext())
{
   RepeaterItem myItem = (RepeaterItem)myEnumertor.Current;
   labelDisplay.Text += ((DataBoundLiteralControl)
      myItem.Controls[0]).Text + "<br />";
}
      }