
            // Create a ClientTarget object.
            clientTarget = new ClientTarget(
              "my alias", "My User Agent");

            // Remove it from the collection
            // (if exists).
            clientTargets.Remove(clientTarget);

            // Update the configuration file.
            if (!clientTargetSection.IsReadOnly())
              configuration.Save();
