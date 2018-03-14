//<Snippet1>
using System;   
using System.Runtime.InteropServices;   
using System.Security;   
using System.Security.Permissions;           

public static class Cursor   
{       
    // Callers do not require UnmanagedCode permission, however,       
    // they do require UIPermissionWindow.AllWindows       
    public static void Hide()          
    {           
        // Need to demand an appropriate permission           
        // in  place of UnmanagedCode permission as            
        // ShowCursor is not considered a safe method           
        new UIPermission(UIPermissionWindow.AllWindows).Demand();           
        UnsafeNativeMethods.ShowCursor(false);       
    }   
}            

[SuppressUnmanagedCodeSecurityAttribute]   
internal static class UnsafeNativeMethods   
{       
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]       
    internal static extern int ShowCursor([MarshalAs(UnmanagedType.Bool)]bool bShow);   
}
//</Snippet1>