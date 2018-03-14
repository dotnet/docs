using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DisplayWebBrowserCode
{
	partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//<SNIPPET2>
		private void button1_Click(object sender, EventArgs e)
		{
			HtmlElement elem;

			if (webBrowser1.Document != null)
			{
				CodeForm cf = new CodeForm();
				HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("HTML");
				if (elems.Count == 1)
				{
					elem = elems[0];
					cf.Code = elem.OuterHtml;
					cf.Show();
				}
			}
		}
		//</SNIPPET2>
	}
}