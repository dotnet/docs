
using System.Windows.Forms;
using System.Drawing;
using System;

public class Form1:
    System.Windows.Forms.Form

{
    #region " Windows Form Designer generated code "

    public Form1() : base()
    {        

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        InitalizeComboBoxAndTextBoxes();
        this.comboBox1.SelectionChangeCommitted += 
            new EventHandler(comboBox1_SelectionChangeCommitted);
        //Add any initialization after the InitializeComponent() call

    }

    //Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.

    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {

        this.SuspendLayout();
        //
        //ComboBox1
        //

        //
        //TextBox1
        //

        //Form1
        //
        this.ClientSize = new System.Drawing.Size(292, 266);


        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);

    }

    #endregion
    internal System.Windows.Forms.ComboBox comboBox1;
    internal System.Windows.Forms.TextBox textbox1;


    private void InitalizeComboBoxAndTextBoxes()
    {
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.comboBox1.Location = new Point(25, 150);
        this.comboBox1.Width = 160;

        this.textbox1 = new System.Windows.Forms.TextBox();
        textbox1.Location = new Point(25, 50);
        textbox1.Name = "selectedTextBox";
        textbox1.Size = new Size(25, 15);

        string[] namespaces = new string[]{"System.Windows.Forms", 
            "System.Net", "System.Reflection", "System.Drawing"};
        
        foreach ( string aNamespace in namespaces )
        {
            comboBox1.Items.Add(aNamespace + ", " + 
                (aNamespace.Length + 4));
        }

        this.Controls.Add(this.textbox1);
        this.Controls.Add(this.comboBox1);
    }

    // The following code example demonstrates the handling of the 
    // SelectionChangeCommitted event.  This example uses the 
    // SelectionLength property to set the width of a text box that 
    // displays the SelectedText. Since the SelectionLength and
    // SelectedText properties reflect the currently selected 
    // (not newly selected) text, they will lag behind what is currently
    // displayed in the text portion of the ComboBox control. To run  
    // this example, paste the following code into a form that contains 
    // a ComboBox named comboBox1 and is populated with strings. 
    // The form should also contain a TextBox named textbox1.  
    // Ensure the SelectionChangedEvent is associated with the  
    // event-handling method in this example.

    //<snippet1>
    private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
    {

        ComboBox senderComboBox = (ComboBox) sender;
      
        // Change the length of the text box depending on what the user has 
        // selected and committed using the SelectionLength property.
        if (senderComboBox.SelectionLength > 0)
        {
            textbox1.Width = 
                senderComboBox.SelectedItem.ToString().Length *
                ((int) this.textbox1.Font.SizeInPoints);
            textbox1.Text = senderComboBox.SelectedItem.ToString();
        }
    }
    //</snippet1>

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }
}



