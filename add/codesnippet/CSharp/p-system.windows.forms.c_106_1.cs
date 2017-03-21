private void menuItemEdit_Popup(object sender, EventArgs e)
{
   // Disable the menu item if the text box does not have focus.
   this.menuItemEditInsertCustomerInfo.Enabled = this.textBox1.Focused;
}