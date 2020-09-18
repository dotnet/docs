using System;
using System.Security;
using System.Security.Permissions;

namespace TransparencyWarningsDemo
{

    public class MethodsProtectedWithLinkDemandsClass
    {
        // CA2135 violation - the LinkDemand should be removed, and the method marked [SecurityCritical] instead
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public void ProtectedMethod()
        {
        }
    }
}
