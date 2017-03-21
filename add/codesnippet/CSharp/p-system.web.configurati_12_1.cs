            // Get the current Protection.
            FormsProtectionEnum currentProtection = 
                formsAuthentication.Protection;

            // Set the Protection property.
            formsAuthentication.Protection = 
                FormsProtectionEnum.All;
