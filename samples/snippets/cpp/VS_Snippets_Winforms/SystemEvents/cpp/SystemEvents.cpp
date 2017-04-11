//Types:Microsoft.Win32.SystemEvents Vendor: Richter
//<snippet1>
#using <System.dll>

using namespace System;
using namespace Microsoft::Win32;

// This method is called when a user preference changes.
void SystemEvents_UserPreferenceChanging(Object^ sender,
     UserPreferenceChangingEventArgs^ e)
 {
     Console::WriteLine("The user preference is changing. Category={0}",
         e->Category);
 }

// This method is called when the palette changes.
void SystemEvents_PaletteChanged(Object^ sender, EventArgs^ e)
{
    Console::WriteLine("The palette changed.");
}

// This method is called when the display settings change.
void SystemEvents_DisplaySettingsChanged(Object^ sender,
    EventArgs^ e)
{
    Console::WriteLine("The display settings changed.");
}

//<snippet2>
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
//</snippet2>

// This code produces the following output.
//
//  This app is waiting for system events.
//  Press <Enter> to terminate this application.
//  Display Settings changed.
//  User preference is changing. Category=General
//</snippet1>
