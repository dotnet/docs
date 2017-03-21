
            // Create a new ClientTarget object.
            clientTarget = new ClientTarget(
              "my alias", "My User Agent"); 
              
            // Add the clientTarget to 
            // the collection.
            clientTargets.Add(clientTarget);

            // Update the configuration file.
            if (!clientTargetSection.IsReadOnly())
              configuration.Save();
