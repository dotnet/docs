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
        this.helpLabel.Text = "Click on any control to give it focus, and then " +
            "press F1 to display help for that control.  Alternately, you can " +
            "click the help button at the top of the dialog and then click on a control.";

        // Address Label
        this.label2.Location = new System.Drawing.Point(16, 8);
        this.label2.Size = new System.Drawing.Size(100, 16);
        this.label2.Text = "Address:";

        // Comma Label
        this.label3.Location = new System.Drawing.Point(136, 56);
        this.label3.Size = new System.Drawing.Size(16, 16);
        this.label3.Text = ",";

        // Address TextBox
        this.addressTextBox.Location = new System.Drawing.Point(16, 24);
        this.addressTextBox.Size = new System.Drawing.Size(264, 20);
        this.addressTextBox.TabIndex = 0;
        this.addressTextBox.Tag = "Enter the street address in this text box.";
        this.addressTextBox.Text = "";
        this.addressTextBox.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.textBox_HelpRequested);

        // City TextBox
        this.cityTextBox.Location = new System.Drawing.Point(16, 48);
        this.cityTextBox.Size = new System.Drawing.Size(120, 20);
        this.cityTextBox.TabIndex = 3;
        this.cityTextBox.Tag = "Enter the city here.";
        this.cityTextBox.Text = "";
        this.cityTextBox.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.textBox_HelpRequested);

        // State TextBox
        this.stateTextBox.Location = new System.Drawing.Point(152, 48);
        this.stateTextBox.MaxLength = 2;
        this.stateTextBox.Size = new System.Drawing.Size(32, 20);
        this.stateTextBox.TabIndex = 5;
        this.stateTextBox.Tag = "Enter the state in this text box.";
        this.stateTextBox.Text = "";
        this.stateTextBox.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.textBox_HelpRequested);

        // Zip TextBox
        this.zipTextBox.Location = new System.Drawing.Point(192, 48);
        this.zipTextBox.Name = "zipTextBox";
        this.zipTextBox.Size = new System.Drawing.Size(88, 20);
        this.zipTextBox.TabIndex = 6;
        this.zipTextBox.Tag = "Enter the zip code here.";
        this.zipTextBox.Text = "";
        this.zipTextBox.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.textBox_HelpRequested);

        // Set up how the form should be displayed and add the controls to the form.
        this.ClientSize = new System.Drawing.Size(292, 160);
        this.Controls.AddRange(new System.Windows.Forms.Control[] { this.zipTextBox, 
                                this.stateTextBox, this.label3, this.cityTextBox,  
                                this.label2, this.helpLabel, this.addressTextBox});

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.HelpButton = true;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Text = "Help Event Demonstration";    
    }

    private void textBox_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
    {
        // This event is raised when the F1 key is pressed or the
        // Help cursor is clicked on any of the address fields.
        // The Help text for the field is in the control's
        // Tag property. It is retrieved and displayed in the label.

        Control requestingControl = (Control)sender;
        helpLabel.Text = (string)requestingControl.Tag;
        hlpevent.Handled = true;
    }
}
//</Snippet1>