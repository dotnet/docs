//<Snippet1>
using System;
using System.Security;

namespace TransparencyWarningsDemo
{

    [SecuritySafeCritical]
    public class SafeCriticalBase
    {
    }

    // CA2156 violation - a transparent type cannot derive from a safe critical type.  The fix is any of:
    //   1. Make SafeCriticalBase transparent
    //   2. Make TransparentFromSafeCritical safe critical
    //   3. Make TransparentFromSafeCritical critical
    public class TransparentFromSafeCritical : SafeCriticalBase
    {
    }

    [SecurityCritical]
    public class CriticalBase
    {
    }

    // CA2156 violation - a transparent type cannot derive from a critical type.  The fix is any of:
    //   1. Make CriticalBase transparent
    //   2. Make TransparentFromCritical critical
    public class TransparentFromCritical : CriticalBase
    {
    }

    // CA2156 violation - a safe critical type cannot derive from a critical type.  The fix is any of:
    //   1. Make CriticalBase transparent
    //   2. Make CriticalBase safe critical
    //   3. Make SafeCriticalFromCritical critical
    [SecuritySafeCritical]
    public class SafeCriticalFromCritical : CriticalBase
    {
    }

}

//</Snippet1>