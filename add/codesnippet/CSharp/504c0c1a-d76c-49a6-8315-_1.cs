                // Create an array of KeyContainerPermissionAccessEntry objects
                KeyContainerPermissionAccessEntry[] keyContainerPermAccEntryArray 
                    = { keyContainerPermAccEntry1, keyContainerPermAccEntry2 };

                // Create a new KeyContainerPermission using the array.
                KeyContainerPermission keyContainerPerm2 = 
                    new KeyContainerPermission(
                    KeyContainerPermissionFlags.AllFlags,
                    keyContainerPermAccEntryArray);