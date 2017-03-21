
// Specifies what happens when the user clicks the Button.
 private void printButton_Click(object sender, EventArgs e) 
 {
   try 
   {
     // Assumes the default printer.
     pd.Print();
   }  
   catch(Exception ex) 
   {
     MessageBox.Show("An error occurred while printing", ex.ToString());
   }
 }
 
 // Specifies what happens when the PrintPage event is raised.
 private void pd_PrintPage(object sender, PrintPageEventArgs ev) 
 {      
   // Draw a picture.
   ev.Graphics.DrawImage(Image.FromFile("C:\\My Folder\\MyFile.bmp"), ev.Graphics.VisibleClipBounds);
      
   // Indicate that this is the last page to print.
   ev.HasMorePages = false;
 }

    