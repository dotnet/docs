public void ControlSelect(Control control)
{
   // Select the control, if it can be selected.
   if(control.CanSelect)
   {
      control.Select();
   }
}