//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;

namespace TransparencyWarningsDemo
{

    public class TransparentMethodDemandClass
    {
        // CA2142 violation - transparent code using a Demand.  This can be fixed by making the method safe critical.
        [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
        public void TransparentMethod()
        {
        }
    }
}

//</Snippet1>