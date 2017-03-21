     // Retrive the SiteMapProviderCollection that contains 
     // the providers currently in use.
     SiteMapProviderCollection providers = SiteMap.Providers;

     // Use the Indexer to retrieve the default provider for ASP.NET.
     SiteMapProvider defaultProvider = providers["AspNetXmlSiteMapProvider"];
