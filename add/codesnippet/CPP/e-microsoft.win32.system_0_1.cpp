int main()
{
    // Set the SystemEvents class to receive event notification
    // when a user preference changes, the palette changes, or
    // when display settings change.
    SystemEvents::UserPreferenceChanging += gcnew
        UserPreferenceChangingEventHandler(
        SystemEvents_UserPreferenceChanging);
    SystemEvents::PaletteChanged += gcnew
        EventHandler(SystemEvents_PaletteChanged);
    SystemEvents::DisplaySettingsChanged += gcnew
        EventHandler(SystemEvents_DisplaySettingsChanged);

    // For demonstration purposes, this application sits idle
    // waiting for events.
    Console::WriteLine("This application is waiting for system events.");
    Console::WriteLine("Press <Enter> to terminate this application.");
    Console::ReadLine();
}