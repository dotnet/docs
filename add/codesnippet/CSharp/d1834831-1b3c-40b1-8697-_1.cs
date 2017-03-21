		[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
		public override Type GetChildControlType(string tagName, IDictionary attribs)
		{
			// Distinguish between two possible types of child controls.
			if (tagName.ToLower().EndsWith("myoption1"))
			{
				return typeof(MyOption1);
			}
			else if (tagName.ToLower().EndsWith("myoption2"))
			{
				return typeof(MyOption2);
			}
			return null;
		}