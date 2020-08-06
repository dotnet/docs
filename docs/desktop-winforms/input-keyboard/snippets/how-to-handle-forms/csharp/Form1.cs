using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Event only raised when non-modifier key is pressed
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        // Event raised as soon as shift is pressed
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //<HandleKey>
        // Detect all numeric characters at the form level and consume 1,4, and 7.
        // Form.KeyPreview must be set to true for this event handler to be called.
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' pressed.");

                switch (e.KeyChar)
                {
                    case (char)49:
                    case (char)52:
                    case (char)55:
                        MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' consumed.");
                        e.Handled = true;
                        break;
                }
            }
        }
        //</HandleKey>
    }
}
