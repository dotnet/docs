// <Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DetermineModifierKey
{
	class Form1 : Form
	{
		TextBox TextBox1 = new TextBox();

		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		public Form1()
		{
			TextBox1.KeyPress +=
				new KeyPressEventHandler(TextBox1_KeyPress);
			this.Controls.Add(TextBox1);
		}

		// <Snippet5>
		public void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
			{
				MessageBox.Show("Pressed " + Keys.Shift);
			}
		}
		// </Snippet5>
	}
}
// </Snippet0>