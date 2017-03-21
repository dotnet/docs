private void PrintBoundControls()
{
   BindingManagerBase myBindingBase = this.BindingContext[ds, "customers"];
   foreach(Binding b in myBindingBase.Bindings)
   {
      Console.WriteLine(b.Control.ToString());
   }
}
