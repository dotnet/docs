            try
            {
                // Try to access a resource.
            }
            catch (System.UnauthorizedAccessException e)
            {
                // Call a custom error logging procedure.
                LogError(e);
                // Re-throw the error.
                throw;     
            }