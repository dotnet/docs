using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AccessHTMLDOMControlCSharp
{
	public partial class UserControl1 : UserControl
	{
		public UserControl1()
		{
			InitializeComponent();
		}

		//<SNIPPET1>
		HtmlDocument doc = null;

		private void UserControl1_Load(object sender, EventArgs e)
		{
			if (this.Site != null)
			{
				doc = (HtmlDocument)this.Site.GetService(typeof(HtmlDocument));
			}
		}
		//</SNIPPET1>
	}
}