// <Snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


public class Form1 : Form
{
    private StatusStrip statusStrip1;

    public Form1()
    {
        InitializeComponent();
    }
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }

    private void InitializeComponent()
    {
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.SuspendLayout();
        // 
        // statusStrip1
        // 
        this.statusStrip1.Location = new System.Drawing.Point(0, 251);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(292, 22);
        this.statusStrip1.TabIndex = 0;
        this.statusStrip1.Text = "statusStrip1";
        this.statusStrip1.LocationChanged += new System.EventHandler(this.statusStrip1_LocationChanged);
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(292, 273);
        this.Controls.Add(this.statusStrip1);
        this.Name = "Form1";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    private void statusStrip1_LocationChanged(object sender, EventArgs e)
    {
        MessageBox.Show("The form has been resized.");
    }
}
// </Snippet1>