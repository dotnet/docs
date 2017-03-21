
            // Create a UrlMapping object.
            urlMapping = new UrlMapping(
              "~/home.aspx", "~/default.aspx?parm1=1");

            // Remove it from the collection
            // (if exists).
            urlMappings.Remove(urlMapping);

            // Update the configuration file.
            if (!urlMappingSection.IsReadOnly())
              configuration.Save();
