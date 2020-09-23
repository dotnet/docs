using System;

namespace ca1813
{
    //<snippet1>
    // Satisfies rule: AvoidUnsealedAttributes.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class DeveloperAttribute : Attribute
    {
        private string nameValue;
        public DeveloperAttribute(string name)
        {
            nameValue = name;
        }

        public string Name
        {
            get
            {
                return nameValue;
            }
        }
    }
    //</snippet1>
}
