//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
	private System.Windows.Forms.TextBox addressTextBox;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.TextBox cityTextBox;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.TextBox stateTextBox;
	private System.Windows.Forms.TextBox zipTextBox;
	private System.Windows.Forms.HelpProvider helpProvider1;
	private System.Windows.Forms.Label helpLabel;

    [STAThread]
    static void Main() 
    {
        Application.Run(new Form1());
    }

	public Form1()
	{
        this.addressTextBox = new System.Windows.Forms.TextBox();
        this.helpLabel = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.cityTextBox = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.stateTextBox = new System.Windows.Forms.TextBox();
        this.zipTextBox = new System.Windows.Forms.TextBox();
        
        // Help Label
        this.helpLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.helpLabel.Location = new System.Drawing.Point(8, 80);
        this.helpLabel.Size = new System.Drawing.Size(272, 72);
        this.helpLabel.Text = "Click the Help button in the title bar, then click a control " + 
            "to see a Help tooltip for the control.  Click on a control and press F1 to invoke " +
            "the Help system with a sample Help file.";

        // Address Label
        this.label2.Location = new System.Drawing.Point(16, 8);
        this.label2.Size = new System.Drawing.Size(100, 16);
        this.label2.Text = "Address:";

        // Comma Label
        this.label3.Location = new System.Drawing.Point(136, 56);
        this.label3.Size = new System.Drawing.Size(16, 16);
        this.label3.Text = ",";

        //<Snippet4>
        // Create the HelpProvider.
        this.helpProvider1 = new System.Windows.Forms.HelpProvider();
        //</Snippet4>

        //<Snippet2>
        // Tell the HelpProvider what controls to provide help for, and
        // what the help string is.
        this.helpProvider1.SetShowHelp(this.addressTextBox, true);
        this.helpProvider1.SetHelpString(this.addressTextBox, "Enter the street address in this text box.");

        this.helpProvider1.SetShowHelp(this.cityTextBox, true);
        this.helpProvider1.SetHelpString(this.cityTextBox, "Enter the city here.");

        this.helpProvider1.SetShowHelp(this.stateTextBox, true);
        this.helpProvider1.SetHelpString(this.stateTextBox, "Enter the state in this text box.");

        this.helpProvider1.SetShowHelp(this.zipTextBox, true);
        this.helpProvider1.SetHelpString(this.zipTextBox, "Enter the zip code here.");
        //</Snippet2>

        //<Snippet3>
        // Set what the Help file will be for the HelpProvider.
        this.helpProvider1.HelpNamespace = "mspaint.chm";
        //</Snippet3>

        // Sets properties for the different address fields.

        // Address TextBox
        this.addressTextBox.Location = new System.Drawing.Point(16, 24);
        this.addressTextBox.Size = new System.Drawing.Size(264, 20);
        this.addressTextBox.TabIndex = 0;
        this.addressTextBox.Text = "";

        // City TextBox
        this.cityTextBox.Location = new System.Drawing.Point(16, 48);
        this.cityTextBox.Size = new System.Drawing.Size(120, 20);
        this.cityTextBox.TabIndex = 3;
        this.cityTextBox.Text = "";

        // State TextBox
        this.stateTextBox.Location = new System.Drawing.Point(152, 48);
        this.stateTextBox.MaxLength = 2;
        this.stateTextBox.Size = new System.Drawing.Size(32, 20);
        this.stateTextBox.TabIndex = 5;
        this.stateTextBox.Text = "";

        // Zip TextBox
        this.zipTextBox.Location = new System.Drawing.Point(192, 48);
        this.zipTextBox.Size = new System.Drawing.Size(88, 20);
        this.zipTextBox.TabIndex = 6;
        this.zipTextBox.Text = "";

        // Add the controls to the form.
        this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                    this.zipTextBox, this.stateTextBox,
                                    this.label3, this.cityTextBox,
                                    this.label2, this.helpLabel,
                                    this.addressTextBox});

        // Set the form to look like a dialog, and show the HelpButton.    
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.HelpButton = true;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.ClientSize = new System.Drawing.Size(292, 160);
        this.Text = "Help Provider Demonstration";

    }
}
//</Snippet1>