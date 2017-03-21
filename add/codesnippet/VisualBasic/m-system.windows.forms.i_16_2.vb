    ' The RemoveCursorMapping method deletes the default
    ' mapping for the Cursor property.
    Private Sub RemoveCursorMapping()
        wfHost.PropertyMap.Remove("Cursor")
    End Sub