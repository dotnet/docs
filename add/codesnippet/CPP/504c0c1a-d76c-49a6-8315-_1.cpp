         // Create an array of KeyContainerPermissionAccessEntry objects
         array<KeyContainerPermissionAccessEntry^>^keyContainerPermAccEntryArray = {keyContainerPermAccEntry1,keyContainerPermAccEntry2};
         
         // Create a new KeyContainerPermission using the array.
         KeyContainerPermission ^ keyContainerPerm2 = gcnew KeyContainerPermission( KeyContainerPermissionFlags::AllFlags,keyContainerPermAccEntryArray );
         