//<Snippet1>
using System;
using System.Security.Permissions;

namespace SecurityTestClassLibrary
{
    public class SecurityTestClass
    {
        [System.Security.SecurityCritical]
        void SecurityCriticalMethod()
        {
            new FileIOPermission(PermissionState.Unrestricted).Assert();

            // perform I/O operations under Assert
        }
    }
}

//</Snippet1>
