
            // Remove the client target at the 
            // specified index from the collection.
            clientTargets.RemoveAt(0);

            // Update the configuration file.
            if (!clientTargetSection.IsReadOnly())
              configuration.Save();
