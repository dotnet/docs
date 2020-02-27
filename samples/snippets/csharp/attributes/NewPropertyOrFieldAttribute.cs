using System;
using System.Collections.Generic;
using System.Text;

namespace attributes
{
    // <Snippet1>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class NewPropertyOrFieldAttribute : Attribute { }
    // </Snippet1>

    // <Snippet2>
    class MyClass
    {
        // Attribute attached to property:
        [NewPropertyOrField]
        public string Name { get; set; }

        // Attribute attached to backing field:
        [field:NewPropertyOrField]
        public string Description { get; set; }
    }
    // </Snippet2>
}
