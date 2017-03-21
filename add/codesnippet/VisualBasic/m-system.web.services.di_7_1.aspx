   Public Sub Discover_Click(Source As Object, e as EventArgs )
      ' Specify the URL to read the discovery results from.
      Dim outputDirectory As String = DiscoDir.Text

      Dim client as DiscoveryClientProtocol = new DiscoveryClientProtocol()
      ' Use default credentials to access files containing the previously saved discovery results.
      client.Credentials = CredentialCache.DefaultCredentials
      Try 
       	Dim doc As DiscoveryDocument
     
       ' Read in existing discovery results.
        Dim results As DiscoveryClientResultCollection 
        results = client.ReadAll(Path.Combine(DiscoDir.Text,"results.discomap"))

      Catch e2 As Exception
       	  DiscoveryResultsGrid.Columns.Clear()
          Status.Text = e2.Message
      End Try

      ' If disocvery documents existed in the supplied folder, display the results in a data grid.
       If (client.Documents.Count > 0) Then
            ' Populate the data grid with the discovery results.
	    PopulateGrid(client)
       End If
   End Sub