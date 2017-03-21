private void menuItemHelpAbout_Click(object sender, EventArgs e)
{
   // Create and display a modless about dialog box.
   AboutDialog about = new AboutDialog();
   about.Show();

   // Draw a blue square on the form.
   /* NOTE: This is not a persistent object, it will no longer be
      * visible after the next call to OnPaint. To make it persistent, 
      * override the OnPaint method and draw the square there */
   Graphics g = about.CreateGraphics();
   g.FillRectangle(Brushes.Blue, 10, 10, 50, 50);
}