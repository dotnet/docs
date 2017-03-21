   Public Sub Discover_Click(Source As Object, e as EventArgs )
      ' Specify the URL to discover.
      Dim sourceUrl as String = DiscoURL.Text
      ' Specify the URL to save discovery results to or read from.
      Dim outputDirectory As String = DiscoDir.Text

      Dim client as DiscoveryClientProtocol = new DiscoveryClientProtocol()
      ' Use default credentials to access the URL being discovered.
      client.Credentials = CredentialCache.DefaultCredentials
      Try 
       	Dim doc As DiscoveryDocument
        ' Discover the URL for any discoverable documents. 
        doc = client.DiscoverAny(sourceUrl)

	' Resolve references just one level deep.
        client.ResolveOneLevel()
              
       Catch e2 As Exception
       	  DiscoveryResultsGrid.Columns.Clear()
          Status.Text = e2.Message
       End Try

       ' If documents were discovered, display the results in a data grid.
       If (client.Documents.Count > 0) Then
            'populate our Grid with the discovery results
	    PopulateGrid(client)
       End If

       ' Save the discovery results to disk.	    
       Dim results As DiscoveryClientResultCollection 
       results = client.WriteAll(outputDirectory, "results.discomap")
       Status.Text = "The following file holds the links to each of the discovery results: <b>" + _ 
	                                 Path.Combine(outputDirectory,"results.discomap") + "</b>"
      End Sub