[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method |  
                AttributeTargets.Property | AttributeTargets.Field, 
                Inherited = true)]
public class InheritedAttribute : Attribute
{}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method |
                AttributeTargets.Property | AttributeTargets.Field, 
                Inherited = false)]
public class NotInheritedAttribute : Attribute
{} 