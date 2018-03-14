//<SNIPPET2>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Samples.AspNet.CS.Controls
{

	// This code snippet creates a simple Web Part control.
 	[AspNetHostingPermission(SecurityAction.Demand,
	  Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermission(SecurityAction.InheritanceDemand,
	  Level = AspNetHostingPermissionLevel.Minimal)]
	public class SimpleControl : WebPart
	{

		private String _text = "Simple control text";

		public string Text
		{
			get
			{
				if (_text != null)
					return _text;
				else
					return string.Empty;
			}
			set { _text = value; }
		}

		protected override void Render(System.Web.UI.HtmlTextWriter 
      writer)
		{
			writer.Write(this.Text);
		}
	}
}
//</SNIPPET2>