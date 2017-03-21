        'Set the SystemEvents class to receive event notification 
        'when a user preference changes, the palette changes, or 
        'when display settings change.
        AddHandler SystemEvents.UserPreferenceChanging, _
        AddressOf SystemEvents_UserPreferenceChanging

        AddHandler SystemEvents.PaletteChanged, _
        AddressOf SystemEvents_PaletteChanged

        AddHandler SystemEvents.DisplaySettingsChanged, _
        AddressOf SystemEvents_DisplaySettingsChanged