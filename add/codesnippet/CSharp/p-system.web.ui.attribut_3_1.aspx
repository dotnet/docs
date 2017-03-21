private void Button2_Click(object sender, System.EventArgs e)
{
   
   string myColor;
   AttributeCollection myAttributes = TextBox1.Attributes;
   myColor = DropDownList1.Items[DropDownList1.SelectedIndex].Text;
   // Add the attribute "background-color" in to the CssStyle.
   myAttributes.CssStyle.Add("background-color",myColor);
   
}