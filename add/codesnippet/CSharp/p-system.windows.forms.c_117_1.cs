private void myButton_Click(object sender, EventArgs e)
{
   FontDialog myFontDialog = new FontDialog();
   if(myFontDialog.ShowDialog() == DialogResult.OK)
   {
      // Set the control's font.
      myDateTimePicker.Font = myFontDialog.Font;
   }
}