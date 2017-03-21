            // Using the Set method.
            CustomError newCustomError =
            new CustomError(404, "customerror404.htm");

            // Update the configuration file.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Add the new custom error to the collection.
                customErrorsCollection.Set(newCustomError);
                configuration.Save();
            }
