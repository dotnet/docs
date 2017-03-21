        public override object Transform(object providerData)
        {
            _provider = (IWebPartRow)providerData;
            return this;
        }