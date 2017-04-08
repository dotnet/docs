//<Snippet1>
using System;
using System.Security.Permissions;

namespace TransparencyWarningsDemo
{

    public class TransparentMethodsProtectedWithLinkDemandsClass
    {
        // CA2142 violation - transparent code using a LinkDemand.  This can be fixed by removing the LinkDemand
        // from the method.
        [PermissionSet(SecurityAction.LinkDemand, Unrestricted = true)]
        public void TransparentMethod()
        {
        }
    }
}

//</Snippet1>