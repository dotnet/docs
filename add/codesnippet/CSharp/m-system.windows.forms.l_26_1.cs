   public Form1()
   {
      InitializeComponent();
      // Sets the control to allow drops, and then adds the necessary event handlers.
      this.richTextBox1.AllowDrop = true;
   }
	
   private void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
   {
      // Determines which item was selected.
      ListBox lb =( (ListBox)sender);
      Point pt = new Point(e.X,e.Y);
      //Retrieve the item at the specified location within the ListBox.
      int index = lb.IndexFromPoint(pt);

      // Starts a drag-and-drop operation.
      if(index>=0) 
      {
         // Retrieve the selected item text to drag into the RichTextBox.
         lb.DoDragDrop(lb.Items[index].ToString(), DragDropEffects.Copy);
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
      // Paste the text into the RichTextBox where at selection location.
      richTextBox1.SelectedText =  e.Data.GetData("System.String", true).ToString();
   }
