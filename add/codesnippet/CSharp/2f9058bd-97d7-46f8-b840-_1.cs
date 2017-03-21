        // Initialize is used to initialize the properties and any state that the
        // AccessProvider holds, but is not used to build the site map.
        // The site map is built when the BuildSiteMap method is called.
        public override void Initialize(string name, NameValueCollection attributes) {
            if (IsInitialized)
                return;

            base.Initialize(name, attributes);

            // Create and test the connection to the Microsoft Access database.

            // Retrieve the Value of the Access connection string from the
            // attributes NameValueCollection.
            string connectionString = attributes[AccessConnectionStringName];

            if (null == connectionString || connectionString.Length == 0)
                throw new Exception ("The connection string was not found.");
            else
                accessConnection = new OleDbConnection(connectionString);

            initialized = true;
        }