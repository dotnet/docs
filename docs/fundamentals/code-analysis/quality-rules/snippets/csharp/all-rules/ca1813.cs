using System;

namespace ca1813
{
    //<snippet1>
    // Satisfies rule: AvoidUnsealedAttributes.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class DeveloperAttribute : Attribute
    {
        public DeveloperAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
    //</snippet1>
}
