//<Snippet1>
using System;
using System.Security.Permissions;

namespace System.Security.Cryptography
{
    public sealed class MyDataProtector : DataProtector
    {
        public DataProtectionScope Scope { get; set; }
//<Snippet2>
        // This implementation gets the HashedPurpose from the base class and passes it as OptionalEntropy to ProtectedData.
        // The default for DataProtector is to prepend the hash to the plain text, but because we are using the hash 
        // as OptionalEntropy there is no need to prepend it.
        protected override bool PrependHashedPurposeToPlaintext
        {
            get
            {
                return false;
            }
        }
//</Snippet2>
//<Snippet3>
        // To allow a service to hand out instances of a DataProtector we demand unrestricted DataProtectionPermission 
        // in the constructor, but Assert the permission when ProviderProtect is called.  This is similar to FileStream
        // where access is checked at time of creation, not time of use.
        [SecuritySafeCritical]
        [DataProtectionPermission(SecurityAction.Assert, ProtectData = true)]
        protected override byte[] ProviderProtect(byte[] userData)
        {
            // Delegate to ProtectedData
            return ProtectedData.Protect(userData, GetHashedPurpose(), Scope);
        }
 //</Snippet3>
 //<Snippet4>
        // To allow a service to hand out instances of a DataProtector we demand unrestricted DataProtectionPermission 
        // in the constructor, but Assert the permission when ProviderUnProtect is called.  This is similar to FileStream
        // where access is checked at time of creation, not time of use.
        [SecuritySafeCritical]
        [DataProtectionPermission(SecurityAction.Assert, UnprotectData = true)]
        protected override byte[] ProviderUnprotect(byte[] encryptedData)
        {
            // Delegate to ProtectedData
            return ProtectedData.Unprotect(encryptedData, GetHashedPurpose(), Scope);
        }
 //</Snippet4>
        public override bool IsReprotectRequired(byte[] encryptedData)
        {
            // For now, this cannot be determined, so always return true;
            return true;
        }
 //<Snippet5>
        // Public constructor
        // The Demand for DataProtectionPermission is in the constructor because we Assert this permission 
        // in the ProviderProtect/ProviderUnprotect methods. 
        [DataProtectionPermission(SecurityAction.Demand, Unrestricted = true)]
        [SecuritySafeCritical]
        public MyDataProtector(string appName, string primaryPurpose, params string[] specificPurpose)
            : base(appName, primaryPurpose, specificPurpose)
        {
        }
//</Snippet5>
    }
}
//</Snippet1>
