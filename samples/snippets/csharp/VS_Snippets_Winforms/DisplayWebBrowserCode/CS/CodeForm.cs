using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DisplayWebBrowserCode
{
	partial class CodeForm : Form
	{
		public CodeForm()
		{
			InitializeComponent();
		}

		//<SNIPPET1>
		public string Code
		{
			get
			{
				if (richTextBox1.Text != null)
				{
					return (richTextBox1.Text);
				}
				else
				{
					return ("");
				}
			}
			set
			{
				richTextBox1.Text = value;
			}
		}
		//</SNIPPET1>
	}
}