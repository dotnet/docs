// <Snippet2>
using System;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;

[assembly: WebResource("Samples.AspNet.CS.Controls.script_include.js", "application/x-javascript")]
namespace Samples.AspNet.CS.Controls
{
	[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class ClientScriptResourceLabel
	{
		// Class code goes here.

	}
	 
}
// </Snippet2>
