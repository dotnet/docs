        // The RemoveCursorMapping method deletes the default
        // mapping for the Cursor property.
        private void RemoveCursorMapping()
        {
            wfHost.PropertyMap.Remove("Cursor");
        }