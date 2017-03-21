public Form1() {

   // The initial constructor code goes here.
 
   PropertyGrid propertyGrid1 = new PropertyGrid();
   propertyGrid1.CommandsVisibleIfAvailable = true;
   propertyGrid1.Location = new Point(10, 20);
   propertyGrid1.Size = new System.Drawing.Size(400, 300);
   propertyGrid1.TabIndex = 1;
   propertyGrid1.Text = "Property Grid";

   this.Controls.Add(propertyGrid1);

   propertyGrid1.SelectedObject = textBox1;
}