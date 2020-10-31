using System;

namespace ca1018
{
    // Violates rule: MarkAttributesWithAttributeUsage.
    public sealed class BadCodeMaintainerAttribute : Attribute
    {
        public BadCodeMaintainerAttribute(string developerName)
        {
            DeveloperName = developerName;
        }
        public string DeveloperName { get; }
    }

    // Satisfies rule: Attributes specify AttributeUsage.
    // This attribute is valid for type-level targets.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public sealed class GoodCodeMaintainerAttribute : Attribute
    {
        public GoodCodeMaintainerAttribute(string developerName)
        {
            DeveloperName = developerName;
        }
        public string DeveloperName { get; }
    }
}
