   // Initialize is used to initialize the properties and any state that the
   // AccessProvider holds, but is not used to build the site map.
   // The site map is built when the BuildSiteMap method is called.
   virtual void Initialize( String^ name, NameValueCollection^ attributes ) override
   {
      if ( IsInitialized )
            return;

      StaticSiteMapProvider::Initialize( name, attributes );
      
      // Create and test the connection to the Microsoft Access database.
      // Retrieve the Value of the Access connection string from the
      // attributes NameValueCollection.
      String^ connectionString = attributes[ AccessConnectionStringName ];
      if ( nullptr == connectionString || connectionString->Length == 0 )
            throw gcnew Exception( "The connection string was not found." );
      else
            accessConnection = gcnew OleDbConnection( connectionString );

      initialized = true;
   }


protected:
