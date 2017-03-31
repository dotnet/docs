using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

/// <summary>
/// Summary description for Form1.
/// </summary>
public class Form1 : System.Windows.Forms.Form
{
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.Button button1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Form1()
    {
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();

        //
        // TODO: Add any constructor code after InitializeComponent call
        //
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
        if( disposing )
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose( disposing );
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("one");
        System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("two");
        System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("three");

        this.listView1 = new System.Windows.Forms.ListView();
        this.button1 = new System.Windows.Forms.Button();
        this.SuspendLayout();

// 
// listView1
// 
        this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem11, listViewItem12, listViewItem13
        });
        this.listView1.Location = new System.Drawing.Point(5, 40);
        this.listView1.Name = "listView1";
        this.listView1.Size = new System.Drawing.Size(278, 207);
        this.listView1.TabIndex = 0;

// 
// button1
// 
        this.button1.Location = new System.Drawing.Point(175, 10);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(100, 22);
        this.button1.TabIndex = 1;
        this.button1.Text = "button1";
        this.button1.Click += new System.EventHandler(this.button1_Click);

// 
// Form1
// 
        this.ClientSize = new System.Drawing.Size(292, 273);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.listView1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);
    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    public void DemonstrateSelection()
    {
        //<Snippet1>
        this.listView1.Items[0].Focused = true;
        this.listView1.Items[0].Selected = true;
        //</Snippet1>
    }

    private void button1_Click(object sender, System.EventArgs e)
    {
        DemonstrateSelection();
    }
}
