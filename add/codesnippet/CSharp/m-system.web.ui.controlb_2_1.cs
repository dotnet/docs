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