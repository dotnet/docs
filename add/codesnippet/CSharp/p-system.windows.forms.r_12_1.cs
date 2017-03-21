public void ChangeMySelectionColor()
{
   ColorDialog colorDialog1 = new ColorDialog();

   // Set the initial color of the dialog to the current text color.
   colorDialog1.Color = richTextBox1.SelectionColor;

   // Determine if the user clicked OK in the dialog and that the color has changed.
   if(colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && 
      colorDialog1.Color != richTextBox1.SelectionColor)
   {
      // Change the selection color to the user specified color.
      richTextBox1.SelectionColor = colorDialog1.Color;
   }
}
