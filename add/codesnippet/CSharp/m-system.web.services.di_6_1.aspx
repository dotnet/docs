   protected void Discover_Click(object Source, EventArgs e)
   {
	// Specify the URL to read the discovery results from.
	string outputDirectory = DiscoDir.Text;

        DiscoveryClientProtocol client = new DiscoveryClientProtocol();
	// Use default credentials to access the files containing the discovery results.
        client.Credentials = CredentialCache.DefaultCredentials;

        try {
       	  DiscoveryDocument doc;
	  // Read in existing discovery results.
          DiscoveryClientResultCollection results = client.ReadAll(Path.Combine(DiscoDir.Text,"results.discomap"));
        }
        catch ( Exception e2) 
        {
          DiscoveryResultsGrid.Columns.Clear();
          Status.Text = e2.Message;
        }
	// If discovery documents existed in the supplied folder, display the results in a data grid.
        if (client.Documents.Count > 0)
	    PopulateGrid(client);
  }