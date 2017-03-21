private void RemoveBackColorBinding()
{
   Binding colorBinding = textBox1.DataBindings["BackColor"];
   textBox1.DataBindings.Remove(colorBinding);
}