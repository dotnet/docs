        // Override the AppendSubBuilder method to throw an
        // exception if the class it is applied to attempts
        // to include child controls. 
		public override void AppendSubBuilder(ControlBuilder subBuilder)
		{
			throw new Exception(
				"A custom label control cannot contain other objects.");
		}