using System;
using System.Drawing;
using System.Windows.Forms;

[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
public class Form1 : Form {
    
    protected TextBox textBox1;

// <Snippet1>
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
// </Snippet1>

}

