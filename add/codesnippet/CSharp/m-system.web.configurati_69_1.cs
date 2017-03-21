            // Using the Clear method.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Execute the Clear method.
                customErrorsCollection.Clear();
                configuration.Save();
            }
