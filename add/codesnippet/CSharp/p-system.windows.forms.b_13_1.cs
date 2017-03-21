private void PrintPositions()
{
   foreach(Control c in this.Controls)
   {
      foreach(Binding xBinding in c.DataBindings)
      {
         Console.WriteLine
         (c.ToString() + "\t Position: " + 
         xBinding.BindingManagerBase.Position);
      }
   }
}
