using System;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;

namespace ASPNET.Samples.CS
{
	// <snippet1>
	// Create a custom ControlCollection that writes
	// information to the Trace log when an instance
	// of the collection is created.
	[AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
	public class CustomControlCollection : ControlCollection
	{
		private HttpContext context;

		public CustomControlCollection(Control owner)
			: base(owner)
		{

			HttpContext.Current.Trace.Write("The control collection is created.");
			// Display the Name of the control
			// that uses this collection when tracing is enabled.
			HttpContext.Current.Trace.Write("The owner is: " + this.Owner.ToString());
		}
	}
	// </snippet1>

	[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class ChildControl : Control
	{
		private String messageValue;

		public String Message
		{
			get
			{
				return messageValue;
			}
			set
			{
				messageValue = value;
			}
		}
	}

	public sealed class ParentControl : Control
	{
		public ParentControl()
		{
		}
		// <snippet2>
		// Override the CreateControlCollection method to 
		// write to the Trace object when tracing is enabled
		// for the page or application in which this control
		// is included.   
		protected override ControlCollection CreateControlCollection()
		{
			return new CustomControlCollection(this);
		}
		//</snippet2>
		protected override void CreateChildControls()
		{
			// Create a new ControlCollection.
			this.CreateControlCollection();

			// Create child controls.
			ChildControl firstControl = new ChildControl();
			firstControl.Message = "FirstChildControl";

			ChildControl secondControl = new ChildControl();
			secondControl.Message = "SecondChildControl";

			ChildControl thirdControl = new ChildControl();
			thirdControl.Message = "ThirdChildControl";

			ChildControl fourthControl = new ChildControl();
			fourthControl.Message = "FourthChildControl";

			Controls.Add(firstControl);
			Controls.Add(secondControl);
			Controls.Add(thirdControl);
			Controls.Add(fourthControl);

			// Prevent child controls from being created again.
			ChildControlsCreated = true;
		}
	}
}
