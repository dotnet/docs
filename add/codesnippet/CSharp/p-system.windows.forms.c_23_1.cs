// Reset all the controls to the user's default Control color. 
private void ResetAllControlsBackColor(Control control)
{
   control.BackColor = SystemColors.Control;
   control.ForeColor = SystemColors.ControlText;
   if(control.HasChildren)
   {
      // Recursively call this method for each child control.
      foreach(Control childControl in control.Controls)
      {
         ResetAllControlsBackColor(childControl);
      }
   }
}