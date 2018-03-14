using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreviewKeyDownCS
{
    public partial class Form1 : Form
    {

        // <snippet1>
        public Form1()
        {
            InitializeComponent();

            // Form that has a button on it
            button1.PreviewKeyDown +=new PreviewKeyDownEventHandler(button1_PreviewKeyDown);
            button1.KeyDown += new KeyEventHandler(button1_KeyDown);
            button1.ContextMenuStrip = new ContextMenuStrip();
            // Add items to ContextMenuStrip
            button1.ContextMenuStrip.Items.Add("One");
            button1.ContextMenuStrip.Items.Add("Two");
            button1.ContextMenuStrip.Items.Add("Three");
        }

        // By default, KeyDown does not fire for the ARROW keys
        void button1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    if (button1.ContextMenuStrip != null)
                    {
                        button1.ContextMenuStrip.Show(button1,
                            new Point(0, button1.Height), ToolStripDropDownDirection.BelowRight);
                    }
                    break;
            }
        }
        
        // PreviewKeyDown is where you preview the key.
        // Do not put any logic here, instead use the
        // KeyDown event after setting IsInputKey to true.
        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }
        // </snippet1>
    }
}
