private void BindingManagerBase_CurrentChanged
(object sender, EventArgs e)
{
   // Print the new value of the current object.
   Console.Write("Current Changed: ");
   Console.WriteLine(((BindingManagerBase)sender).Current);
}

private void MoveNext()
{
   // Increment the Position property value by one.
   myBindingManagerBase.Position += 1;
}

private void MovePrevious()
{
   // Decrement the Position property value by one.
   myBindingManagerBase.Position -= 1;
}

private void MoveFirst()
{
   // Go to the first item in the list.
   myBindingManagerBase.Position = 0;
}

private void MoveLast()
{
   // Go to the last row in the list.
   myBindingManagerBase.Position = 
   myBindingManagerBase.Count - 1;
}
   