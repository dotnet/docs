using System;
using System.Collections.Generic;
using System.Text;

namespace attributes
{
    namespace VersionOne
    {
        // <Snippet1>
        [System.AttributeUsage(System.AttributeTargets.All,
                           AllowMultiple = false,
                           Inherited = true)]
        class NewAttribute : System.Attribute { }
        // </Snippet1>
    }
    namespace VersionTwo
    {
        // <Snippet2>
        [System.AttributeUsage(System.AttributeTargets.All)]
        class NewAttribute : System.Attribute { }
        // </Snippet2>
    }
}
