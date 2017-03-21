            // Using the Add method.
            CustomError newCustomError2 =
            new CustomError(404, "customerror404.htm");

            // Update the configuration file.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Add the new custom error to the collection.
                customErrorsCollection.Add(newCustomError2);
                configuration.Save();
            }
