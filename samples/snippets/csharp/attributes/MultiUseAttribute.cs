using System;
using System.Collections.Generic;
using System.Text;

namespace attributes
{
    // <Snippet1>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class MultiUse : Attribute { }

    [MultiUse]
    [MultiUse]
    class Class1 { }

    [MultiUse, MultiUse]
    class Class2 { }
    // </Snippet1>
}
