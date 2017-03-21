
            // Remove the URL with the
            // specified name from the collection
            // (if exists).
            urlMappings.Remove("~/default.aspx");

            // Update the configuration file.
            if (!urlMappingSection.IsReadOnly())
              configuration.Save();
