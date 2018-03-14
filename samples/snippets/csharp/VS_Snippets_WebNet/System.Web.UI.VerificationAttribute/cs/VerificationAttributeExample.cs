using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SomeNamespace
{
	public class CustomClassCS : Control
	{

		// <Snippet1>
		[Verification("ADA", "1194.22(a)", 
			VerificationReportLevel.Error, 1,
			"The image is missing a text equivalent.", 
			VerificationRule.NotEmptyString, "ImageUrl"),
		Verification("WCAG", "1.1", 
			VerificationReportLevel.Error, 1, 
			"The image is missing an text equivalent.", 
			VerificationRule.NotEmptyString, "ImageUrl")]
		public virtual String ImageText
		{
			get
			{
				object obj = ViewState["ImageText"];
				return ((obj == null) ? String.Empty : (string)obj);
			}
			set
			{
				ViewState["ImageText"] = value;
			}
		}
		public virtual String ImageUrl
		{
			get 
			{
				object obj = ViewState["ImageUrl"];
				return ((obj == null) ? String.Empty : (string)obj);
			}
			set 
			{ 
				ViewState["ImageUrl"] = value;
			}
		}
		// </Snippet1>

	}
}