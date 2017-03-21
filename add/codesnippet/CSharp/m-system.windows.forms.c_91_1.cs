private void ClearAllBindings()
{
   foreach(Control c in groupBox1.Controls)
   c.DataBindings.Clear();
}