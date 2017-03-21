[ObfuscationAttribute(Exclude=true, ApplyToMembers=false)]
public class Type2
{

    // The exclusion of the type is not applied to its members,
    // however in order to mark the member with the "default" 
    // feature it is necessary to specify Exclude=false,
    // because the default value of Exclude is true. The tool
    // should not strip this attribute after obfuscation.
    [ObfuscationAttribute(Exclude=false, Feature="default", 
        StripAfterObfuscation=false)]
    public void MethodA() {}

    // This member is marked for obfuscation, because the 
    // exclusion of the type is not applied to its members.
    public void MethodB() {}

}