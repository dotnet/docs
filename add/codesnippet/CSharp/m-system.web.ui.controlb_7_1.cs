        // Override the HtmlDecodeLiterals method to allow HTML
        // decoding of literal strings in any controls this builder
        // is applied to.
		public override bool HtmlDecodeLiterals()
		{
			return true;
		}