        // To allow a service to hand out instances of a DataProtector we demand unrestricted DataProtectionPermission 
        // in the constructor, but Assert the permission when ProviderProtect is called.  This is similar to FileStream
        // where access is checked at time of creation, not time of use.
        [SecuritySafeCritical]
        [DataProtectionPermission(SecurityAction.Assert, ProtectData = true)]
        protected override byte[] ProviderProtect(byte[] userData)
        {
            
            // Delegate to ProtectedData
            ProtectedMemory.Protect(userData, Scope);
            return userData;
        }