   protected void Discover_Click(object Source, EventArgs e)
   {
	// Specify the URL to discover.
	string sourceUrl = DiscoURL.Text;
	// Specify the URL to save discovery results to or read from.
	string outputDirectory = DiscoDir.Text;

        DiscoveryClientProtocol client = new DiscoveryClientProtocol();
	// Use default credentials to access the URL being discovered.
        client.Credentials = CredentialCache.DefaultCredentials;

        try 
        {
       	  DiscoveryDocument doc;
          
          // Discover the URL for any discoverable documents. 
	  doc = client.DiscoverAny(sourceUrl);
	 
          // Resolve all possible references from the supplied URL.
          client.ResolveAll();
        }
        catch ( Exception e2) 
        {
          DiscoveryResultsGrid.Columns.Clear();
          Status.Text = e2.Message;
        }
	// If documents were discovered, display the results in a data grid.
        if (client.Documents.Count > 0)
	    PopulateGrid(client);

	// Save the discovery results to disk.
        DiscoveryClientResultCollection results = client.WriteAll(outputDirectory, "results.discomap");
        Status.Text = "The following file holds the links to each of the discovery results: <b>" + 
	                                Path.Combine(outputDirectory,"results.discomap") + "</b>";
  }