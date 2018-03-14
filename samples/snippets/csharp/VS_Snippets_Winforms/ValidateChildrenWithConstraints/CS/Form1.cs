//<SNIPPET1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ValidateChildrenWithConstraints
{
    class Form1 : Form
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        private Form1()
        {
            this.Load += new EventHandler(Form1_Load);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            // Create controls on form.
            TextBox textBox1, textBox2, textBox3;
            FlowLayoutPanel flowPanel1;
            TextBox subTextBox1;
            Button button1;

            this.Size = new Size(500, 300);
            this.AutoValidate = AutoValidate.Disable;

            textBox1 = new TextBox();
            textBox1.Location = new Point(20, 20);
            textBox1.Size = new Size(75, textBox1.Size.Height);
            textBox1.CausesValidation = true;
            textBox1.Validating += new System.ComponentModel.CancelEventHandler(textBox1_Validating);
            this.Controls.Add(textBox1);

            textBox2 = new TextBox();
            textBox2.Location = new Point(105, 20);
            textBox2.Size = new Size(75, textBox2.Size.Height);
            textBox2.CausesValidation = true;
            textBox2.Validating += new System.ComponentModel.CancelEventHandler(textBox2_Validating);
            this.Controls.Add(textBox2);

            textBox3 = new TextBox();
            textBox3.Location = new Point(190, 20);
            textBox3.Size = new Size(75, textBox3.Size.Height);
            textBox3.Enabled = false;
            textBox3.CausesValidation = true;
            textBox3.Validating += new System.ComponentModel.CancelEventHandler(textBox3_Validating);
            this.Controls.Add(textBox3);

            button1 = new Button();
            button1.Text = "Click";
            button1.Location = new Point(270, 20);
            button1.Click += new EventHandler(button1_Click);
            this.Controls.Add(button1);

            flowPanel1 = new FlowLayoutPanel();
            flowPanel1.Size = new Size(400, 100);
            flowPanel1.Dock = DockStyle.Bottom;
            subTextBox1 = new TextBox();
            subTextBox1.CausesValidation = true;
            subTextBox1.Validating += new System.ComponentModel.CancelEventHandler(subTextBox1_Validating);
            flowPanel1.Controls.Add(subTextBox1);
            this.Controls.Add(flowPanel1);
        }

        void subTextBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("subTextBox1 Validating!");
        }

        void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("textBox1 Validating!");
        }

        void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("textBox2 Validating!");
        }

        void textBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("textBox3 Validating!");
        }

        void button1_Click(object sender, EventArgs e)
        {
            this.ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled);
        }
    }
}
//</SNIPPET1>