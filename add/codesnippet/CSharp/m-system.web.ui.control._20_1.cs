		// Override the CreateControlCollection method to 
		// write to the Trace object when tracing is enabled
		// for the page or application in which this control
		// is included.   
		protected override ControlCollection CreateControlCollection()
		{
			return new CustomControlCollection(this);
		}