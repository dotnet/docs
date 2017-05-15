using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

 class Form1 : Form
    {
        private Button button1 = new Button();
        public Form1()
        {
            //InitializeComponent();
            this.Controls.Add(button1);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
       // <snippet4>
        private Image GetImageOfCustomControl(Control userControl)
        {
            Image controlImage = null;
            AttributeCollection attrCol = 
                    TypeDescriptor.GetAttributes(userControl);
            ToolboxBitmapAttribute imageAttr = (ToolboxBitmapAttribute)
                attrCol[typeof(ToolboxBitmapAttribute)];
            if (imageAttr != null)
            {
                controlImage = imageAttr.GetImage(userControl);
            }

            return controlImage;
        }
        // </snippet4>

    }


// The following code example demonstrates how to use the 
// ToolBoxBitmapAttribute#ctor(string) costructor to set stop.bmp as the
// toolbox icon for the StopSignControl. This example assumes
// the existence of a 16-by-16-pixel bitmap named stop.bmp at c:\.
//<snippet1>
[System.Drawing.ToolboxBitmap("c:\\stop.bmp")]
public class StopSignControl:
    System.Windows.Forms.UserControl

{
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button Button1;

    public StopSignControl() : base()
    {        
        this.Label1 = new System.Windows.Forms.Label();
        this.Button1 = new System.Windows.Forms.Button();

        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) 0));

        this.Label1.ForeColor = System.Drawing.Color.Red;
        this.Label1.Location = new System.Drawing.Point(24, 56);
        this.Label1.Name = "Label1";
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Stop!";
        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        this.Button1.Enabled = false;
        this.Button1.Location = new System.Drawing.Point(56, 88);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(40, 32);
        this.Button1.TabIndex = 1;
        this.Button1.Text = "stop";

        this.Controls.Add(this.Button1);
        this.Controls.Add(this.Label1);
        this.Name = "StopSignControl";

    }

    private void StopSignControl_MouseEnter(object sender, System.EventArgs e)
    {

        Label1.Text.ToUpper();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 14.0F, 
	    System.Drawing.FontStyle.Bold);
        Button1.Enabled = true;
    }

    private void StopSignControl_MouseLeave(object sender, System.EventArgs e)
    {

        Label1.Text.ToLower();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 12.0F, 
	    System.Drawing.FontStyle.Regular);
        Button1.Enabled = false;
    }

}
//</snippet1>

// The following code example demonstrates how to use the 
// ToolBoxBitmapAttribute#ctor(type, string) constructor to set StopSignControl2.bmp as a toolbox
// icon for the StopSignControl. This example assumes
// the existence of a 16-by-16-pixel bitmap named StopSignControl2.bmp with its 
// BuildAction property set to EmbeddedResource.
//<snippet2>
[System.Drawing.ToolboxBitmap(typeof(StopSignControl2), "StopSignControl2.bmp")]
public class StopSignControl2:
    System.Windows.Forms.UserControl

{
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button Button1;

    public StopSignControl2() : base()
    {        
        this.Label1 = new System.Windows.Forms.Label();
        this.Button1 = new System.Windows.Forms.Button();

        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 
            12.0F, System.Drawing.FontStyle.Regular, 
            System.Drawing.GraphicsUnit.Point, ((byte) 0));
        this.Label1.ForeColor = System.Drawing.Color.Red;
        this.Label1.Location = new System.Drawing.Point(24, 56);
        this.Label1.Name = "Label1";
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Stop!";
        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.Button1.Enabled = false;
        this.Button1.Location = new System.Drawing.Point(56, 88);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(40, 32);
        this.Button1.TabIndex = 1;
        this.Button1.Text = "stop";
        this.Controls.Add(this.Button1);
        this.Controls.Add(this.Label1);
        this.Name = "StopSignControl";

    }

    private void StopSignControl_MouseEnter(object sender, System.EventArgs e)
    {
        Label1.Text.ToUpper();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 14.0F, 
            System.Drawing.FontStyle.Bold);
        Button1.Enabled = true;
    }

    private void StopSignControl_MouseLeave(object sender, System.EventArgs e)
    {

        Label1.Text.ToLower();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 12.0F, 
	    System.Drawing.FontStyle.Regular);
        Button1.Enabled = false;
    }

}
//</snippet2>


// The following code example demonstrates how to use the 
// ToolBoxBitmapAttribute#ctor(type) constructor to set the icon of the button control
// to the toolbox icon for a UserControl named StopSignControl3. 
//<snippet3>
[System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.Button))]
public class StopSignControl3:
    System.Windows.Forms.UserControl

{
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button Button1;

    public StopSignControl3() : base()
    {        
        this.Label1 = new System.Windows.Forms.Label();
        this.Button1 = new System.Windows.Forms.Button();

        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 
            12.0F, System.Drawing.FontStyle.Regular, 
            System.Drawing.GraphicsUnit.Point, ((byte) 0));
        this.Label1.ForeColor = System.Drawing.Color.Red;
        this.Label1.Location = new System.Drawing.Point(24, 56);
        this.Label1.Name = "Label1";
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Stop!";
        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        this.Button1.Enabled = false;
        this.Button1.Location = new System.Drawing.Point(56, 88);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(40, 32);
        this.Button1.TabIndex = 1;
        this.Button1.Text = "stop";
        this.Controls.Add(this.Button1);
        this.Controls.Add(this.Label1);
        this.Name = "StopSignControl";

    }

    private void StopSignControl_MouseEnter(object sender, System.EventArgs e)
    {
        Label1.Text.ToUpper();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily,
	    14.0F, System.Drawing.FontStyle.Bold);
        Button1.Enabled = true;
    }

    private void StopSignControl_MouseLeave(object sender, System.EventArgs e)
    {
        Label1.Text.ToLower();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 
	    12.0F, System.Drawing.FontStyle.Regular);
        Button1.Enabled = false;
    }

}
//</snippet3>
