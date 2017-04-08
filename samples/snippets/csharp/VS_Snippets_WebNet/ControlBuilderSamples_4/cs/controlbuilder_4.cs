// <snippet1>
using System;
using System.Web.UI;
using System.Web;
using System.Security.Permissions;

namespace ASPNET.Samples
{
	[
	AspNetHostingPermission(SecurityAction.Demand,
		Level=AspNetHostingPermissionLevel.Minimal)
	]
	public class AppendControlBuilder : ControlBuilder
	{
		// Override the OnAppendToParentBuilder method.
		public override void OnAppendToParentBuilder(ControlBuilder parentBuilder)
		{
            // Check whether the type of the control this builder
            // is applied to is CustomTextBox. If so, check whether
            // ASP code blocks exist in the control. If so, call
            // throw an Exception, if not, call the HasBody method.        
			if (ControlType == Type.GetType("CustomTextBox"))
			{
				if (HasAspCode)
					throw new Exception("This control cannot contain code blocks.");
				else
					HasBody();
			}
		}
	}
}
// </snippet1>
