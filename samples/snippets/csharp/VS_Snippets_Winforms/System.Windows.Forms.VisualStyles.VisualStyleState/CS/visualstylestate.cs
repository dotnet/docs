
// <Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace VisualStyleStateSample
{
	class Form1 : Form
	{
		Button button1 = new Button();
		RadioButton radioButton1 = new RadioButton();
		RadioButton radioButton2 = new RadioButton();
		RadioButton radioButton3 = new RadioButton();
		RadioButton radioButton4 = new RadioButton();

		public Form1()
		{
			button1.AutoSize = true;
			button1.Location = new Point(10, 10);
			button1.Text = "Update VisualStyleState";
			button1.Click += new EventHandler(button1_Click);

			radioButton1.Location = new Point(10, 50);
			radioButton1.AutoSize = true;
			radioButton1.Text = "Apply styles to client area only";

			radioButton2.Location = new Point(10, 70);
			radioButton2.AutoSize = true;
			radioButton2.Text = "Apply styles to nonclient area only";

			radioButton3.Location = new Point(10, 90);
			radioButton3.AutoSize = true;
			radioButton3.Text = "Apply styles to client and nonclient areas";

			radioButton4.Location = new Point(10, 110);
			radioButton4.AutoSize = true;
			radioButton4.Text = "Disable styles in all areas";

			this.Text = "VisualStyleState Test";
			this.Controls.AddRange(new Control[] { button1,  
                radioButton1, radioButton2, radioButton3, radioButton4});
		}

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		// <Snippet10>
		void button1_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				Application.VisualStyleState =
					VisualStyleState.ClientAreaEnabled;
			}
			else if (radioButton2.Checked)
			{
				Application.VisualStyleState =
					VisualStyleState.NonClientAreaEnabled;
			}
			else if (radioButton3.Checked)
			{
				Application.VisualStyleState =
					VisualStyleState.ClientAndNonClientAreasEnabled;
			}
			else if (radioButton4.Checked)
			{
				Application.VisualStyleState =
					VisualStyleState.NoneEnabled;
			}

			// Repaint the form and all child controls.
			this.Invalidate(true);
		}
		// </Snippet10>
	}
}
// </Snippet0>