// Create two RadioButtons to add to the Panel.
private RadioButton radioAddButton = new RadioButton();
private RadioButton radioRemoveButton = new RadioButton();

// Add controls to the Panel using the AddRange method.
private void addRangeButton_Click(object sender, System.EventArgs e)
{
   // Set the Text the RadioButtons will display.
   radioAddButton.Text = "radioAddButton";
   radioRemoveButton.Text = "radioRemoveButton";
			
   // Set the appropriate location of radioRemoveButton.
   radioRemoveButton.Location = new System.Drawing.Point(
     radioAddButton.Location.X, 
     radioAddButton.Location.Y + radioAddButton.Height);
			
   //Add the controls to the Panel.
   panel1.Controls.AddRange(new Control[]{radioAddButton, radioRemoveButton});
}