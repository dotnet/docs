
            // Remove the URL at the 
            // specified index from the collection.
            urlMappings.RemoveAt(0);

            // Update the configuration file.
            if (!urlMappingSection.IsReadOnly())
              configuration.Save();
