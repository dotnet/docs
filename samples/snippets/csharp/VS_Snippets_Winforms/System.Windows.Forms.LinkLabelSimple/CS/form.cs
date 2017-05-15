//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
    private System.Windows.Forms.LinkLabel linkLabel1;

    [STAThread]
    static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        // Create the LinkLabel.
        this.linkLabel1 = new System.Windows.Forms.LinkLabel();

        // Configure the LinkLabel's location. 
        this.linkLabel1.Location = new System.Drawing.Point(34, 56);
        // Specify that the size should be automatically determined by the content.
        this.linkLabel1.AutoSize = true;

        // Add an event handler to do something when the links are clicked.
        this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);

        // Set the text for the LinkLabel.
        this.linkLabel1.Text = "Visit Microsoft";

        // Set up how the form should be displayed and add the controls to the form.
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Controls.AddRange(new System.Windows.Forms.Control[] { this.linkLabel1 });
        this.Text = "Simple Link Label Example";
    }

    private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        // Specify that the link was visited.
        this.linkLabel1.LinkVisited = true;

        // Navigate to a URL.
        System.Diagnostics.Process.Start("http://www.microsoft.com");
    }
}
//</Snippet1>