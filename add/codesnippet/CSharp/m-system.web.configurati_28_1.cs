 
            // Clear the client target collection.
            clientTargets.Clear();

            // Update the configuration file.
            if (!clientTargetSection.IsReadOnly())
              configuration.Save();
