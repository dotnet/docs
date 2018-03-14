//<Snippet1>
using System;   
using System.Runtime.InteropServices;   
using System.Security;  
         
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
    [DllImport("kernel32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]       
    internal static extern int GetTickCount();   
}
//</Snippet1>