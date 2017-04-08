// <snippet1>
// <snippet2>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// </snippet2>

// This sample demonstrates the use of the 
// DesignerSerializationVisibility attribute
// to serialize a collection of strings
// at design time.
namespace SerializationDemo
{
    class Form1 : Form
    {
        private SerializationDemoControl serializationDemoControl1;

        public Form1()
        {
            InitializeComponent();            
        }

        // The Windows Forms Designer emits code to this method. 
        // If an instance of SerializationDemoControl is added 
        // to the form, the Strings will be serialized here.
        private void InitializeComponent()
        {
            this.serializationDemoControl1 = new SerializationDemo.SerializationDemoControl();
            this.SuspendLayout();
            // 
            // serializationDemoControl1
            // 
            this.serializationDemoControl1.Location = new System.Drawing.Point(0, 0);
            this.serializationDemoControl1.Name = "serializationDemoControl1";
            this.serializationDemoControl1.Padding = new System.Windows.Forms.Padding(5);
            this.serializationDemoControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.serializationDemoControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    // <snippet3>
    public class SerializationDemoControl : UserControl
    {
        // This is the TextBox contained by 
        // the SerializationDemoControl.
        private System.Windows.Forms.TextBox textBox1;

        // <snippet4>
        // This field backs the Strings property.
        private String[] stringsValue = new String[1];
        // </snippet4>

        public SerializationDemoControl()
        {
            InitializeComponent();
        }

        // <snippet5>
        // When the DesignerSerializationVisibility attribute has
        // a value of "Content" or "Visible" the designer will 
        // serialize the property. This property can also be edited 
        // at design time with a CollectionEditor.
        [DesignerSerializationVisibility( 
            DesignerSerializationVisibility.Content )]
        public String[] Strings
        {
            get
            {
                return this.stringsValue;
            }
            set
            {
                this.stringsValue = value;

                // Populate the contained TextBox with the values
                // in the stringsValue array.
                StringBuilder sb = 
                    new StringBuilder(this.stringsValue.Length);

                for (int i = 0; i < this.stringsValue.Length; i++)
                {
                    sb.Append(this.stringsValue[i]);
                    sb.Append("\r\n");
                }

                this.textBox1.Text = sb.ToString();
            }
        }
        // </snippet5>

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            
            // Settings for the contained TextBox control.
            this.textBox1.AutoSize = false;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(5, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(140, 140);
            this.textBox1.TabIndex = 0;
            
            // Settings for SerializationDemoControl.
            this.Controls.Add(this.textBox1);
            this.Name = "SerializationDemoControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ResumeLayout(false);
        }
    }
    // </snippet3>
}
// </snippet1>