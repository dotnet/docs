using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace MS.ASPNET.Samples
{
	// <snippet3>
    // A custom ControlBuilder class that is designed
    // for custom Label classes. It does not allow white
    // space in the control to be interpreted as a LiteralControl,
    // does not allow child controls, and allows literal strings
    // to be HTML decoded.
	[AspNetHostingPermission(SecurityAction.Demand, 
		Level=AspNetHostingPermissionLevel.Minimal)]
	public sealed class CstmLabelBuilder : ControlBuilder
	{
        // Override the AllowWhiteSpaceLiterals method
        // so that white spaces in a control are not 
        // converted to LiteralControl objects.
		public override bool AllowWhitespaceLiterals()
		{
			return false;
		}

		// <snippet1>
        // Override the AppendSubBuilder method to throw an
        // exception if the class it is applied to attempts
        // to include child controls. 
		public override void AppendSubBuilder(ControlBuilder subBuilder)
		{
			throw new Exception(
				"A custom label control cannot contain other objects.");
		}
		// </snippet1>

		// <snippet2>
        // Override the HtmlDecodeLiterals method to allow HTML
        // decoding of literal strings in any controls this builder
        // is applied to.
		public override bool HtmlDecodeLiterals()
		{
			return true;
		}
		// </snippet2>
	}
	// </snippet3>

	[
	ControlBuilder(typeof(CstmLabelBuilder)),
	DefaultProperty("Text"),
	ParseChildren(false)
	]
	[AspNetHostingPermission(SecurityAction.Demand, 
		Level=AspNetHostingPermissionLevel.Minimal)]
	public sealed class CustomLabel : WebControl
	{
		protected override HtmlTextWriterTag TagKey
		{
			get {
				return HtmlTextWriterTag.Label;
			}
		}

		public String Text
		{
			get {
				String s = (string)ViewState["Text"];
				if (s == null)
					return String.Empty;
				else
					return s;
			}
			set {
				ViewState["Text"] = value;
			}
		}

		protected override void AddParsedSubObject(object obj)
		{
			if (obj == typeof(LiteralControl))
				Text = ((LiteralControl)obj).Text;
		}

		protected override void RenderContents(HtmlTextWriter w)
		{
			w.Write(HttpUtility.HtmlEncode(Text));
		}
	}
}
