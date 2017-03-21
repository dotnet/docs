private void button1_Click(object sender, EventArgs e)
{
   /* Add a button to top left corner of the 
    * scrollable area, allowing for the offset. */
   panel1.AutoScroll = true;
   Button myButton = new Button();
   myButton.Location = new Point(
      0 + panel1.AutoScrollPosition.X, 
      0 + panel1.AutoScrollPosition.Y);
   panel1.Controls.Add(myButton);
}