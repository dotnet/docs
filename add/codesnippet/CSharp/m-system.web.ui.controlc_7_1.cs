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