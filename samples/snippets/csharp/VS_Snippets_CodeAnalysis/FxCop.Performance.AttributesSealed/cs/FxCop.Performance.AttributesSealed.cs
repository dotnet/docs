//<Snippet1>
using System;

namespace PerformanceLibrary 
{
    // Satisfies rule: AvoidUnsealedAttributes.

    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct)]
    public sealed class DeveloperAttribute: Attribute
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

}
//</Snippet1>
