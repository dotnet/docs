//Types:Microsoft.Win32.SystemEvents Vendor: Richter
//<snippet1>
using System;
using Microsoft.Win32;

public sealed class App 
{
    //<snippet2>
    static void Main() 
    {         
        // Set the SystemEvents class to receive event notification when a user 
        // preference changes, the palette changes, or when display settings change.
        SystemEvents.UserPreferenceChanging += new 
            UserPreferenceChangingEventHandler(SystemEvents_UserPreferenceChanging);
        SystemEvents.PaletteChanged += new 
            EventHandler(SystemEvents_PaletteChanged);
        SystemEvents.DisplaySettingsChanged += new 
            EventHandler(SystemEvents_DisplaySettingsChanged);        

        // For demonstration purposes, this application sits idle waiting for events.
        Console.WriteLine("This application is waiting for system events.");
        Console.WriteLine("Press <Enter> to terminate this application.");
        Console.ReadLine();
    }
    //</snippet2> 

    // This method is called when a user preference changes.
    static void SystemEvents_UserPreferenceChanging(object sender, UserPreferenceChangingEventArgs e) 
    {
        Console.WriteLine("The user preference is changing. Category={0}", e.Category);
    }

    // This method is called when the palette changes.
    static void SystemEvents_PaletteChanged(object sender, EventArgs e)
    {
        Console.WriteLine("The palette changed.");
    }

    // This method is called when the display settings change.
    static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
    {
        Console.WriteLine("The display settings changed.");
    }
}

// This code produces the following output.
// 
//  This app is waiting for system events.
//  Press <Enter> to terminate this application.
//  Display Settings changed.
//  User preference is changing. Category=General
//</snippet1>