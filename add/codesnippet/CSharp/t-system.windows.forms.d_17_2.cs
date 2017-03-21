private void Form1_Load(object sender, EventArgs e) 
{
   // Sets the AllowDrop property so that data can be dragged onto the control.
   richTextBox1.AllowDrop = true;

   // Add code here to populate the ListBox1 with paths to text files.

}

private void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
{
   // Determines which item was selected.
   ListBox lb =( (ListBox)sender);
   Point pt = new Point(e.X,e.Y);
   int index = lb.IndexFromPoint(pt);

   // Starts a drag-and-drop operation with that item.
   if(index>=0) 
   {
      lb.DoDragDrop(lb.Items[index].ToString(), DragDropEffects.Link);
   }
}

private void richTextBox1_DragEnter(object sender, DragEventArgs e) 
{
   // If the data is text, copy the data to the RichTextBox control.
   if(e.Data.GetDataPresent("Text"))
      e.Effect = DragDropEffects.Copy;
}

private void richTextBox1_DragDrop(object sender, DragEventArgs e) 
{
   // Loads the file into the control. 
   richTextBox1.LoadFile((String)e.Data.GetData("Text"), System.Windows.Forms.RichTextBoxStreamType.RichText);
}
