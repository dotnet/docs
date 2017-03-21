private void AddButtons()
{
   // Suspend the form layout and add two buttons.
   this.SuspendLayout();
   Button buttonOK = new Button();
   buttonOK.Location = new Point(10, 10);
   buttonOK.Size = new Size(75, 25);
   buttonOK.Text = "OK";

   Button buttonCancel = new Button();
   buttonCancel.Location = new Point(90, 10);
   buttonCancel.Size = new Size(75, 25);
   buttonCancel.Text = "Cancel";
      
   this.Controls.AddRange(new Control[]{buttonOK, buttonCancel});
   this.ResumeLayout();
}