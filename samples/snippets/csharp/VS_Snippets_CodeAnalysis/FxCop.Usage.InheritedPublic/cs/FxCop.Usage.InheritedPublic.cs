//<Snippet1>
using System;
namespace UsageLibrary
{
    public class ABaseType
    {
        public void BasePublicMethod(int argument1) {}
    }
    public class ADerivedType:ABaseType
    {
        // Violates rule: DoNotDecreaseInheritedMemberVisibility.
        // The compiler returns an error if this is overridden instead of new.
        private new void BasePublicMethod(int argument1){}       
    }
}
//</Snippet1>
