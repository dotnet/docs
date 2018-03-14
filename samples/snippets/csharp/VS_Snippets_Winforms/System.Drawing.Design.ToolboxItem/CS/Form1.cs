//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace CustomToolboxItem
{
    public class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private UserControl1 userControl11;
        private System.Windows.Forms.Label label1;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.userControl11 = new CustomToolboxItem.UserControl1();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Build the project and drop UserControl1 from the toolbox onto the form.";
            // 
            // userControl11
            // 
            this.userControl11.LabelText = "This is a custom user control.  The text you see here is provided by a custom too" +
                "lbox item when the user control is dropped on the form.";
            this.userControl11.Location = new System.Drawing.Point(74, 81);
            this.userControl11.Name = "userControl11";
            this.userControl11.Padding = new System.Windows.Forms.Padding(6);
            this.userControl11.Size = new System.Drawing.Size(150, 150);
            this.userControl11.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    // Configure this user control to have a custom toolbox item.
//<snippet2>
    [ToolboxItem(typeof(MyToolboxItem))]
    public class UserControl1 : UserControl
//</snippet2>
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;

        public UserControl1()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 138);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is a custom user control.  " + 
                "The text you see here is provided by a custom toolbox" +
                " item when the user control is dropped on the form.\r\n";
            this.label1.TextAlign = 
                System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl1
            // 
            this.Controls.Add(this.label1);
            this.Name = "UserControl1";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    }

//<snippet3>
    // Toolbox items must be serializable.
    [Serializable]
    class MyToolboxItem : ToolboxItem
    {
        // The add components dialog in Visual Studio looks for a public
        // constructor that takes a type.
        public MyToolboxItem(Type toolType)
            : base(toolType)
        {
        }

        // And you must provide this special constructor for serialization.
        // If you add additional data to MyToolboxItem that you
        // want to serialize, you may override Deserialize and
        // Serialize methods to add that data.  
//<snippet4>
        MyToolboxItem(SerializationInfo info, StreamingContext context)
        {
            Deserialize(info, context);
        }
//</snippet4>

        // Let's override the creation code and pop up a dialog.
//<snippet5>
        protected override IComponent[] CreateComponentsCore(
            System.ComponentModel.Design.IDesignerHost host, 
            System.Collections.IDictionary defaultValues)
        {
            // Get the string we want to fill in the custom
            // user control.  If the user cancels out of the dialog,
            // return null or an empty array to signify that the 
            // tool creation was canceled.
            using (ToolboxItemDialog d = new ToolboxItemDialog())
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    string text = d.CreationText;

                    IComponent[] comps =
                        base.CreateComponentsCore(host, defaultValues);
                    // comps will have a single component: our data type.
                    ((UserControl1)comps[0]).LabelText = text;
                    return comps;
                }
                else
                {
                    return null;
                }
            }
        }
//</snippet5>
    }
//</snippet3>

    public class ToolboxItemDialog : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        public ToolboxItemDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the text you would like" + 
                " to have the user control populated with:";
            // 
            // textBox1
            // 
            this.textBox1.AutoSize = false;
            this.textBox1.Location = new System.Drawing.Point(10, 58);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 67);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "This is a custom user control.  " + 
                "The text you see here is provided by a custom toolbox" +
                " item when the user control is dropped on the form.";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(124, 131);
            this.button1.Name = "button1";
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(205, 131);
            this.button2.Name = "button2";
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            // 
            // ToolboxItemDialog
            // 
            this.AcceptButton = this.button1;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(292, 162);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = 
                System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ToolboxItemDialog";
            this.Text = "ToolboxItemDialog";
            this.ResumeLayout(false);

        }

        public string CreationText
        {
            get
            {
                return textBox1.Text;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
//</snippet1>
