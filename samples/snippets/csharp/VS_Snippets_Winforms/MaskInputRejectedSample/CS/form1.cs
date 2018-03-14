#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace MaskInputRejectedSampleCSharp
{
	partial class Form1: Form
	{
		public Form1()
		{
			InitializeComponent();
		}

           //<SNIPPET1>
        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "00/00/0000";

            maskedTextBox1.MaskInputRejected += new MaskInputRejectedEventHandler(maskedTextBox1_MaskInputRejected);
            maskedTextBox1.KeyDown += new KeyEventHandler(maskedTextBox1_KeyDown);
        }

        void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (maskedTextBox1.MaskFull)
            {
                toolTip1.ToolTipTitle = "Input Rejected - Too Much Data";
                toolTip1.Show("You cannot enter any more data into the date field. Delete some characters in order to insert more data.", maskedTextBox1, 0, -20, 5000);
            }
            else if (e.Position == maskedTextBox1.Mask.Length)
            {
                toolTip1.ToolTipTitle = "Input Rejected - End of Field";
                toolTip1.Show("You cannot add extra characters to the end of this date field.", maskedTextBox1, 0, -20, 5000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Input Rejected";
                toolTip1.Show("You can only add numeric characters (0-9) into this date field.", maskedTextBox1, 0, -20, 5000);
            }
        }

        void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // The balloon tip is visible for five seconds; if the user types any data before it disappears, collapse it ourselves.
            toolTip1.Hide(maskedTextBox1);
        }
        //</SNIPPET1>
    }
}