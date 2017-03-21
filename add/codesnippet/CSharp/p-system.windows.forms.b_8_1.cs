private void PrintBindingIsBinding()
{
   foreach(Control c in this.Controls)
   {
      foreach(Binding b in c.DataBindings)
      {
         Console.WriteLine("\n" + c.ToString());
         Console.WriteLine(b.PropertyName + " IsBinding: " 
             + b.IsBinding);
      }
   }
}
