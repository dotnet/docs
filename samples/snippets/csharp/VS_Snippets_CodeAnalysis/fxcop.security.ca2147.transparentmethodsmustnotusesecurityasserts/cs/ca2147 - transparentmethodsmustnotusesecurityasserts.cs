//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;

namespace TransparencyWarningsDemo
{

    public class TransparentMethodsUseSecurityAssertsClass
    {
        // CA2147 violation - transparent code using a security assert declaratively.  This can be fixed by
        // any of:
        //   1. Make DeclarativeAssert critical
        //   2. Make DeclarativeAssert safe critical
        //   3. Remove the assert attribute
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public void DeclarativeAssert()
        {
        }

        public void ImperativeAssert()
        {
            // CA2147 violation - transparent code using a security assert imperatively.  This can be fixed by
            // any of:
            //   1. Make ImperativeAssert critical
            //   2. Make ImperativeAssert safe critical
            //   3. Remove the assert call
            new PermissionSet(PermissionState.Unrestricted).Assert();
        }
    }
}

//</Snippet1>