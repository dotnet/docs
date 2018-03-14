//<Snippet1>
using System;    
using System.Runtime.InteropServices;    
using System.ComponentModel;              

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
//</Snippet1>