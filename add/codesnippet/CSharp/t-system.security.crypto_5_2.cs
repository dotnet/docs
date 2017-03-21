using System;
using System.Security.Permissions;

namespace System.Security.Cryptography
{
    public sealed class MemoryProtector : DataProtector
    {
        public MemoryProtectionScope Scope { get; set; }
        protected override bool PrependHashedPurposeToPlaintext 
        {
            get
            {
                // Signal the DataProtector to prepend the hash of the purpose to the data.
                return true;
            }
        }
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
        // To allow a service to hand out instances of a DataProtector we demand unrestricted DataProtectionPermission 
        // in the constructor, but Assert the permission when ProviderUnprotect is called..  This is similar to FileStream
        // where access is checked at time of creation, not time of use.
        [SecuritySafeCritical]
        [DataProtectionPermission(SecurityAction.Assert, UnprotectData = true)]
        protected override byte[] ProviderUnprotect(byte[] encryptedData)
        {

            ProtectedMemory.Unprotect(encryptedData,Scope);           
                return encryptedData;
        }

        public override bool IsReprotectRequired(byte[] encryptedData)
        {
            // For now, this cannot be determined so always return true.
            return true;
        }
        // Public constructor
        // The Demand for DataProtectionPermission is in the constructor because we Assert this permission 
        // in the ProviderProtect/ProviderUnprotect methods. 
        [DataProtectionPermission(SecurityAction.Demand, Unrestricted = true)]
        [SecuritySafeCritical]
        public MemoryProtector(string appName, string primaryPurpose, params string[] specificPurpose)
            : base(appName, primaryPurpose, specificPurpose)
        {
        }
    }
}