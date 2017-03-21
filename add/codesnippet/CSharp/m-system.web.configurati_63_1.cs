            // Using method RemoveAt.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Remove the error at 0 index
                customErrorsCollection.RemoveAt(0);
                configuration.Save();
            }
