
            // Create a new UrlMapping object.
            urlMapping = new UrlMapping(
              "~/home.aspx", "~/default.aspx?parm1=1");
              
            // Add the urlMapping to 
            // the collection.
            urlMappings.Add(urlMapping);

            // Update the configuration file.
            if (!urlMappingSection.IsReadOnly())
              configuration.Save();
