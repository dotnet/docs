//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PowerStatusBrowser
{
    public class PowerStatusBrowserForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;        
        
        public PowerStatusBrowserForm()
        {
            this.SuspendLayout();
            InitForm();
            
            //Add each property of the PowerStatus class to the list box.
            Type t = typeof(System.Windows.Forms.PowerStatus);            
            PropertyInfo[] pi = t.GetProperties();            
            for( int i=0; i<pi.Length; i++ )
                listBox1.Items.Add( pi[i].Name );            
            textBox1.Text = "The PowerStatus class has "+pi.Length.ToString()+" properties.\r\n";

            // Configure the list item selected handler for the list box to invoke a 
            // method that displays the value of each property.           
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            this.ResumeLayout(false);
        }
		
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Return if no item is selected.
            if( listBox1.SelectedIndex == -1 ) return;
            // Get the property name from the list item
            string propname = listBox1.Text;
            
            // Display the value of the selected property of the PowerStatus type.
            Type t = typeof(System.Windows.Forms.PowerStatus);
            PropertyInfo[] pi = t.GetProperties();            
            PropertyInfo prop = null;
            for( int i=0; i<pi.Length; i++ )
                if( pi[i].Name == propname )
                {
                    prop = pi[i];
                    break;           
                }

            object propval = prop.GetValue(SystemInformation.PowerStatus, null);            
            textBox1.Text += "\r\nThe value of the "+propname+" property is: "+propval.ToString();
        }

        private void InitForm()
        {
            // Initialize the form settings
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();            
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Location = new System.Drawing.Point(8, 16);
            this.listBox1.Size = new System.Drawing.Size(172, 496);
            this.listBox1.TabIndex = 0;            
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(188, 16);
            this.textBox1.Multiline = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;           
            this.textBox1.Size = new System.Drawing.Size(420, 496);
            this.textBox1.TabIndex = 1;            
            this.ClientSize = new System.Drawing.Size(616, 525);            
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);            
            this.Text = "Select a PowerStatus property to get the value of";                   
        }

        [STAThread]
        static void Main() 
        {
            Application.Run(new PowerStatusBrowserForm());
        }
    }
}
//</Snippet1>