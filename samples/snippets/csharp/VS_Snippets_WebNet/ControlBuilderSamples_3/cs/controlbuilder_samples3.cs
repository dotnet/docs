using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Web.SessionState;
using System.Web.Caching;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;
using Debug = System.Diagnostics.Debug;

namespace MS.ASPNET.Samples
{
	// <snippet1>
	[AspNetHostingPermission(SecurityAction.Demand, 
		Level=AspNetHostingPermissionLevel.Minimal)]
	public sealed class MyControlControlBuilder : ControlBuilder
	{
		private string _innerText;

		public override bool NeedsTagInnerText()
		{
			return InDesigner;
		}

		public override void SetTagInnerText(string text)
		{
			if (!InDesigner)
				throw new Exception("The control is not in design mode.");
			else
				_innerText = text;
		}
	}
	// </snippet1>
}

