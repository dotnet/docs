private void AddEventHandler()
{
   textBox1.BindingContextChanged += new EventHandler(BindingContext_Changed);
}

private void BindingContext_Changed(object sender, EventArgs e)
{
   Console.WriteLine("BindingContext changed");
}