//<Snippet1>
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
    private const string helpfile = "mspaint.chm";
    private System.Windows.Forms.Button showIndex;
    private System.Windows.Forms.Button showHelp;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox navigatorCombo;
    private System.Windows.Forms.Button showKeyword;
    private System.Windows.Forms.TextBox keyword;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox parameterTextBox;

    [STAThread]
    static void Main() 
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        this.showIndex = new System.Windows.Forms.Button();
        this.showHelp = new System.Windows.Forms.Button();
        this.navigatorCombo = new System.Windows.Forms.ComboBox();
        this.label1 = new System.Windows.Forms.Label();
        this.showKeyword = new System.Windows.Forms.Button();
        this.keyword = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.parameterTextBox = new System.Windows.Forms.TextBox();

        // Help Navigator Label
        this.label1.Location = new System.Drawing.Point(112, 64);
        this.label1.Size = new System.Drawing.Size(168, 16);
        this.label1.Text = "Help Navigator:";

        // Keyword Label
        this.label2.Location = new System.Drawing.Point(120, 184);
        this.label2.Size = new System.Drawing.Size(100, 16);
        this.label2.Text = "Keyword:";

        // Parameter Label
        this.label3.Location = new System.Drawing.Point(112, 120);
        this.label3.Size = new System.Drawing.Size(168, 16);
        this.label3.Text = "Parameter:";

        // Show Index Button
        this.showIndex.Location = new System.Drawing.Point(16, 16);
        this.showIndex.Size = new System.Drawing.Size(264, 32);
        this.showIndex.TabIndex = 0;
        this.showIndex.Text = "Show Help Index";
        this.showIndex.Click += new System.EventHandler(this.showIndex_Click);

        // Show Help Button
        this.showHelp.Location = new System.Drawing.Point(16, 80);
        this.showHelp.Size = new System.Drawing.Size(80, 80);
        this.showHelp.TabIndex = 1;
        this.showHelp.Text = "Show Help";
        this.showHelp.Click += new System.EventHandler(this.showHelp_Click);

        // Show Keyword Button
        this.showKeyword.Location = new System.Drawing.Point(16, 192);
        this.showKeyword.Size = new System.Drawing.Size(88, 32);
        this.showKeyword.TabIndex = 4;
        this.showKeyword.Text = "Show Keyword";
        this.showKeyword.Click += new System.EventHandler(this.showKeyword_Click);

        // Help Navigator ComboBox
        this.navigatorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.navigatorCombo.Location = new System.Drawing.Point(112, 80);
        this.navigatorCombo.Size = new System.Drawing.Size(168, 21);
        this.navigatorCombo.TabIndex = 2;

        // Keyword TextBox
        this.keyword.Location = new System.Drawing.Point(120, 200);
        this.keyword.Size = new System.Drawing.Size(160, 20);
        this.keyword.TabIndex = 5;
        this.keyword.Text = "";

        // Parameter TextBox
        this.parameterTextBox.Location = new System.Drawing.Point(112, 136);
        this.parameterTextBox.Size = new System.Drawing.Size(168, 20);
        this.parameterTextBox.TabIndex = 8;
        this.parameterTextBox.Text = "";

        // Set up how the form should be displayed and add the controls to the form.
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                        this.parameterTextBox, this.label3,
                                        this.label2, this.keyword,
                                        this.showKeyword, this.label1,
                                        this.navigatorCombo, this.showHelp,
                                        this.showIndex});
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Text = "Help App";

        //<Snippet5>
        // Load the various values of the HelpNavigator enumeration
        // into the combo box.
        TypeConverter converter;
        converter = TypeDescriptor.GetConverter(typeof(HelpNavigator));
        foreach(object value in converter.GetStandardValues()) 
        {
            navigatorCombo.Items.Add(value);
        }
        //</Snippet5>
    }

    //<Snippet2>
    private void showIndex_Click(object sender, System.EventArgs e)
    {
        // Display the index for the help file.
        Help.ShowHelpIndex(this, helpfile);
    }
    //</Snippet2>
    //<Snippet3>
    private void showHelp_Click(object sender, System.EventArgs e)
    {
        // Display Help using the Help navigator enumeration
        // that is selected in the combo box. Some enumeration
        // values make use of an extra parameter, which can
        // be passed in through the Parameter text box.
        HelpNavigator navigator = HelpNavigator.TableOfContents;
        if (navigatorCombo.SelectedItem != null)
        {
            navigator = (HelpNavigator)navigatorCombo.SelectedItem;
        }
        Help.ShowHelp(this, helpfile, navigator, parameterTextBox.Text);
    }
    //</Snippet3>
    //<Snippet4>
    private void showKeyword_Click(object sender, System.EventArgs e)
    {
        // Display help using the provided keyword.
        Help.ShowHelp(this, helpfile, keyword.Text);
    }
    //</Snippet4>
}
//</Snippet1>