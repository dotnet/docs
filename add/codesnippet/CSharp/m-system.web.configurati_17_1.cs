            // Using the Remove method.
            if (!customErrorsSection.SectionInformation.IsLocked)
            {
                // Remove the error with statuscode 404.
                customErrorsCollection.Remove("404");
                configuration.Save();
            }
