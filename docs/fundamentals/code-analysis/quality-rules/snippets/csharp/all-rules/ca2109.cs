using System;
using System.Security.Permissions;

namespace ca2109
{
    //<snippet1>
    public class HandleEvents
    {
        // Due to the access level and signature, a malicious caller could 
        // add this method to system-triggered events where all code in the call
        // stack has the demanded permission.

        // Also, the demand might be canceled by an asserted permission.

        [SecurityPermissionAttribute(SecurityAction.Demand, UnmanagedCode = true)]

        // Violates rule: ReviewVisibleEventHandlers.
        public static void SomeActionHappened(Object sender, EventArgs e)
        {
            Console.WriteLine("Do something dangerous from unmanaged code.");
        }
    }
    //</snippet1>
}
