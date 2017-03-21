            ' Create an array of KeyContainerPermissionAccessEntry objects
            Dim keyContainerPermAccEntryArray As KeyContainerPermissionAccessEntry() = _
                {keyContainerPermAccEntry1, keyContainerPermAccEntry2}

            ' Create a new KeyContainerPermission using the array.
            Dim keyContainerPerm2 As _
                New KeyContainerPermission(KeyContainerPermissionFlags.AllFlags, keyContainerPermAccEntryArray)