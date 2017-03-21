private void AboutDialog_Load(object sender, EventArgs e)
{
   // Display the application information in the label.
   this.labelVersionInfo.Text = 
      this.CompanyName + "  " + 
      this.ProductName + "  Version: " +
      this.ProductVersion;  
}