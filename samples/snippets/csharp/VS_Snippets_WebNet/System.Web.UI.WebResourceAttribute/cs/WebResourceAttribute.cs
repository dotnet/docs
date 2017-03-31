// <Snippet2>
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

[assembly: WebResource("image1.jpg", "image/jpeg")]
[assembly: WebResource("help.htm", "text/html", PerformSubstitution=true)]
namespace Samples.AspNet.CS.Controls
{

	public class MyCustomControl : Control
	{

		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
		protected override void CreateChildControls()
		{
			
			// Create a new Image control.
			Image _img = new Image();
			_img.ImageUrl = this.Page.ClientScript.GetWebResourceUrl(typeof(MyCustomControl), "image1.jpg");
			this.Controls.Add(_img);

			// Create a new Label control.
			Label _lab = new Label();
			_lab.Text = "A composite control using the WebResourceAttribute class.";
			this.Controls.Add(_lab);

			// Create a new HtmlAnchor control linking to help.htm.
			HtmlAnchor a = new HtmlAnchor();
			a.HRef = this.Page.ClientScript.GetWebResourceUrl(typeof(MyCustomControl), "help.htm");
			a.InnerText = "help link";
			this.Controls.Add(new LiteralControl("<br />"));
			this.Controls.Add(a);

		}
	}

}
// </Snippet2>
