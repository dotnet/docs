//<SNIPPET1>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace TestValidation
{
    class Form1 : Form
    {
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        private TextBox firstNameBox, lastNameBox;
        private Button validateButton;
        private FlowLayoutPanel flowLayout1;

        private Form1()
        {
            this.Load += new EventHandler(Form1_Load);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            // Turn off validation when a control loses focus. This will be inherited by child
            // controls on the form, enabling us to validate the entire form when the 
            // button is clicked instead of one control at a time.
            this.AutoValidate = AutoValidate.Disable;

            flowLayout1 = new FlowLayoutPanel();
            flowLayout1.Dock = DockStyle.Fill;
            flowLayout1.Name = "flowLayout1";

            firstNameBox = new TextBox();
            firstNameBox.Name = "firstNameBox";
            firstNameBox.Size = new Size(75, firstNameBox.Size.Height);
            firstNameBox.CausesValidation = true;
            firstNameBox.Validating += new System.ComponentModel.CancelEventHandler(firstNameBox_Validating);
            flowLayout1.Controls.Add(firstNameBox);

            lastNameBox = new TextBox();
            lastNameBox.Name = "lastNameBox";
            lastNameBox.Size = new Size(75, lastNameBox.Size.Height);
            lastNameBox.CausesValidation = true;
            lastNameBox.Validating += new System.ComponentModel.CancelEventHandler(lastNameBox_Validating);
            flowLayout1.Controls.Add(lastNameBox);

            validateButton = new Button();
            validateButton.Text = "Validate";
            // validateButton.Location = new Point(170, 10);
            validateButton.Size = new Size(75, validateButton.Size.Height);
            validateButton.Click += new EventHandler(validateButton_Click);
            flowLayout1.Controls.Add(validateButton);

            this.Controls.Add(flowLayout1);

            this.Text = "Test Validation";
        }

        void firstNameBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (firstNameBox.Text.Length == 0)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        void lastNameBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

        void validateButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                MessageBox.Show("Validation succeeded!");
            }
            else
            {
                MessageBox.Show("Validation failed.");
            }
        }
    }
}
//</SNIPPET1>