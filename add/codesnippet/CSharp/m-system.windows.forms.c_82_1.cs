private void MakeLabelVisible()
{
   /* If the panel contains label1, bring it 
   * to the front to make sure it is visible. */
   if(panel1.Contains(label1))
   {
      label1.BringToFront();
   }
}