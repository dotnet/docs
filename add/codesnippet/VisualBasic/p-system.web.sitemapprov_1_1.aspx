     ' Retrive the SiteMapProviderCollection that contains 
     ' the providers currently in use.
     Dim providers As SiteMapProviderCollection 
     providers = SiteMap.Providers

     ' Use the Indexer to retrieve the default provider for ASP.NET.
     Dim defaultProvider As SiteMapProvider 
     defaultProvider = providers("AspNetXmlSiteMapProvider")