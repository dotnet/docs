//<Snippet1>
using System;
using System.Security;

namespace TransparencyWarningsDemo
{

    public delegate void TransparentDelegate();

    [SecurityCritical]
    public delegate void CriticalDelegate();

    public class TransparentType
    {
        void DelegateBinder()
        {
            // CA2133 violation - binding a transparent delegate to a critical method
            TransparentDelegate td = new TransparentDelegate(CriticalTarget);

            // CA2133 violation - binding a critical delegate to a transparent method
            CriticalDelegate cd = new CriticalDelegate(TransparentTarget);
        }

        [SecurityCritical]
        void CriticalTarget() { }

        void TransparentTarget() { }
    }
}

//</Snippet1>