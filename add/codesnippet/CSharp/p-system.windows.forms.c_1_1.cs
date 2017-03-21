private void button1_Click(object sender, System.EventArgs e)
{
   /* If the CTRL key is pressed when the 
      * control is clicked, hide the control. */
   if(Control.ModifierKeys == Keys.Control)
   {
      ((Control)sender).Hide();
   }
}