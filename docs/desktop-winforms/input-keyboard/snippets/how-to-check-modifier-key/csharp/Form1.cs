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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        //<DetectModifier>
        // Event only raised when non-modifier key is pressed
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                MessageBox.Show("KeyPress " + Keys.Shift);
        }

        // Event raised as soon as shift is pressed
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                MessageBox.Show("KeyDown " + Keys.Shift);
        }
        //</DetectModifier>
    }
}
