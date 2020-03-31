using System;
using System.Collections.Generic;
using System.Text;

namespace attributes
{
    // <Snippet1>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    class NonInheritedAttribute : Attribute { }

    [NonInherited]
    class BClass { }

    class DClass : BClass { }
    // </Snippet1>
}
