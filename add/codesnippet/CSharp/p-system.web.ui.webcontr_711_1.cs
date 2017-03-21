        [ConnectionProvider("Row")]
        public IWebPartRow GetConnectionInterface()
		{
            return new RowProviderWebPart();
        }