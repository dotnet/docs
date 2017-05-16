//<Snippet1>
using System;
using System.Security;

namespace TransparencyWarningsDemo
{

    [SecurityCritical]
    public class CriticalClass
    {
        // CA2136 violation - this method is not really safe critical, since the larger scoped type annotation
        // has precidence over the smaller scoped method annotation.  This can be fixed by removing the
        // SecuritySafeCritical attribute on this method
        [SecuritySafeCritical]
        public void SafeCriticalMethod()
        {
        }
    }
}

//</Snippet1>