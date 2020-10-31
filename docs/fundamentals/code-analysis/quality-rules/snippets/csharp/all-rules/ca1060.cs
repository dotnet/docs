using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace ca1060
{
    //<snippet1>
    // Violates rule: MovePInvokesToNativeMethodsClass.
    internal class UnmanagedApi
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool RemoveDirectory(string name);
    }
    //</snippet1>

    //<snippet2>
    public static class Interaction
    {
        // Callers require Unmanaged permission        
        public static void Beep()
        {
            // No need to demand a permission as callers of Interaction.Beep            
            // will require UnmanagedCode permission            
            if (!NativeMethods.MessageBeep(-1))
                throw new Win32Exception();
        }
    }

    internal static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool MessageBeep(int uType);
    }
    //</snippet2>

    //<snippet3>
    public static class Environment
    {
        // Callers do not require UnmanagedCode permission       
        public static int TickCount
        {
            get
            {
                // No need to demand a permission in place of               
                // UnmanagedCode as GetTickCount is considered              
                // a safe method              
                return SafeNativeMethods.GetTickCount();
            }
        }
    }

    [SuppressUnmanagedCodeSecurityAttribute]
    internal static class SafeNativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern int GetTickCount();
    }
    //</snippet3>

    //<snippet4>
    public static class Cursor
    {
        // Callers do not require UnmanagedCode permission, however,       
        // they do require UIPermissionWindow.AllWindows.    
        public static void Hide()
        {
            // Need to demand an appropriate permission           
            // in place of UnmanagedCode permission as            
            // ShowCursor is not considered a safe method.       
            new UIPermission(UIPermissionWindow.AllWindows).Demand();
            UnsafeNativeMethods.ShowCursor(false);
        }
    }

    [SuppressUnmanagedCodeSecurityAttribute]
    internal static class UnsafeNativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern int ShowCursor([MarshalAs(UnmanagedType.Bool)] bool bShow);
    }
    //</snippet4>
}
