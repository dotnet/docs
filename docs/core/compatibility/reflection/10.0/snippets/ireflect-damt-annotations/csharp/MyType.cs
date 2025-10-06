using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

// <snippet_InvokeMember>
class MyType : IReflect
{
    [DynamicallyAccessedMembers(
        DynamicallyAccessedMemberTypes.PublicFields |
        DynamicallyAccessedMemberTypes.NonPublicFields |
        DynamicallyAccessedMemberTypes.PublicMethods |
        DynamicallyAccessedMemberTypes.NonPublicMethods |
        DynamicallyAccessedMemberTypes.PublicProperties |
        DynamicallyAccessedMemberTypes.NonPublicProperties |
        DynamicallyAccessedMemberTypes.PublicConstructors |
        DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    public object InvokeMember(
        string name,
        BindingFlags invokeAttr,
        Binder? binder,
        object? target,
        object?[]? args,
        ParameterModifier[]? modifiers,
        CultureInfo? culture,
        string[]? namedParameters)
    {
        throw new NotImplementedException();
    }

    public FieldInfo? GetField(string name, BindingFlags bindingAttr)
    {
        throw new NotImplementedException();
    }

    public FieldInfo[] GetFields(BindingFlags bindingAttr)
    {
        throw new NotImplementedException();
    }

    public MemberInfo[] GetMember(string name, BindingFlags bindingAttr)
    {
        throw new NotImplementedException();
    }

    public MemberInfo[] GetMembers(BindingFlags bindingAttr)
    {
        throw new NotImplementedException();
    }

    public MethodInfo? GetMethod(string name, BindingFlags bindingAttr)
    {
        throw new NotImplementedException();
    }

    public MethodInfo? GetMethod(string name, BindingFlags bindingAttr, Binder? binder, Type[] types, ParameterModifier[]? modifiers)
    {
        throw new NotImplementedException();
    }

    public MethodInfo[] GetMethods(BindingFlags bindingAttr)
    {
        throw new NotImplementedException();
    }

    public PropertyInfo[] GetProperties(BindingFlags bindingAttr)
    {
        throw new NotImplementedException();
    }

    public PropertyInfo? GetProperty(string name, BindingFlags bindingAttr)
    {
        throw new NotImplementedException();
    }

    public PropertyInfo? GetProperty(string name, BindingFlags bindingAttr, Binder? binder, Type? returnType, Type[] types, ParameterModifier[]? modifiers)
    {
        throw new NotImplementedException();
    }

    public Type UnderlyingSystemType
    {
        get { throw new NotImplementedException(); }
    }
}
// </snippet_InvokeMember>
