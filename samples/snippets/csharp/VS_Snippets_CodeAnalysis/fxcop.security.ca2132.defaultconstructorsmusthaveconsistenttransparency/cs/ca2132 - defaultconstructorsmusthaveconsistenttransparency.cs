//<Snippet1>
using System;
using System.Security;

namespace TransparencyWarningsDemo
{

    public class BaseWithSafeCriticalDefaultCtor
    {
        [SecuritySafeCritical]
        public BaseWithSafeCriticalDefaultCtor() { }
    }

    public class DerivedWithNoDefaultCtor : BaseWithSafeCriticalDefaultCtor
    {
        // CA2132 violation - since the base has a public or protected non-transparent default .ctor, the
        // derived type must also have a default .ctor
    }

    public class DerivedWithTransparentDefaultCtor : BaseWithSafeCriticalDefaultCtor
    {
        // CA2132 violation - since the base has a safe critical default .ctor, the derived type must have
        // either a safe critical or critical default .ctor.  This is fixed by making this .ctor safe critical
        // (however, user code cannot be safe critical, so this fix is platform code only).
        DerivedWithTransparentDefaultCtor() { }
    }

    public class BaseWithCriticalCtor
    {
        [SecurityCritical]
        public BaseWithCriticalCtor() { }
    }

    public class DerivedWithSafeCriticalDefaultCtor : BaseWithSafeCriticalDefaultCtor
    {
        // CA2132 violation - since the base has a critical default .ctor, the derived must also have a critical
        // default .ctor.  This is fixed by making this .ctor critical, which is not available to user code
        [SecuritySafeCritical]
        public DerivedWithSafeCriticalDefaultCtor() { }
    }
}

//</Snippet1>