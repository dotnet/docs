private void Form1_Resize(object sender, System.EventArgs e)
{
   Control control = (Control)sender;
		
   // Ensure the Form remains square (Height = Width).
   if(control.Size.Height != control.Size.Width)
   {
      control.Size = new Size(control.Size.Width, control.Size.Width);
   }
}