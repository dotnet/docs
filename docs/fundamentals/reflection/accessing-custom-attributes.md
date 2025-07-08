---
title: "Accessing Custom Attributes"
description: Access custom attributes in .NET. After attributes have been associated with program elements, you can use reflection to query their existence and values.
ms.date: 03/27/2024
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "custom attributes, accessibility"
  - "attributes [.NET], accessing"
  - "reflection, custom attributes"
---
# Access custom attributes

After attributes have been associated with program elements, reflection can be used to query their existence and values. .NET provides the <xref:System.Reflection.MetadataLoadContext>, which you can use to examine code that can't be loaded for execution.

## <xref:System.Reflection.MetadataLoadContext>

Code loaded into the <xref:System.Reflection.MetadataLoadContext> context cannot be executed. This means that instances of custom attributes cannot be created, because that would require executing their constructors. To load and examine custom attributes in the <xref:System.Reflection.MetadataLoadContext> context, use the <xref:System.Reflection.CustomAttributeData> class. You can obtain instances of this class by using the appropriate overload of the static <xref:System.Reflection.CustomAttributeData.GetCustomAttributes%2A?displayProperty=nameWithType> method. For more information, see [How to: Inspect assembly contents using MetadataLoadContext](../../standard/assembly/inspect-contents-using-metadataloadcontext.md).

## The execution context

The main reflection methods to query attributes in the execution context are <xref:System.Reflection.MemberInfo.GetCustomAttributes%2A?displayProperty=nameWithType> and <xref:System.Attribute.GetCustomAttributes%2A?displayProperty=nameWithType>.

The accessibility of a custom attribute is checked with respect to the assembly in which it's attached. This is equivalent to checking whether a method on a type in the assembly in which the custom attribute is attached can call the constructor of the custom attribute.

Methods such as <xref:System.Reflection.Assembly.GetCustomAttributes%28System.Boolean%29?displayProperty=nameWithType> check the visibility and accessibility of the type argument. Only code in the assembly that contains the user-defined type can retrieve a custom attribute of that type using `GetCustomAttributes`.

The following C# example is a typical custom attribute design pattern. It illustrates the runtime custom attribute reflection model.

```csharp
System.DLL
public class DescriptionAttribute : Attribute
{
}

System.Web.DLL
internal class MyDescriptionAttribute : DescriptionAttribute
{
}

public class LocalizationExtenderProvider
{
    [MyDescriptionAttribute(...)]
    public CultureInfo GetLanguage(...)
    {
    }
}
```

If the runtime is attempting to retrieve the custom attributes for the public custom attribute type <xref:System.ComponentModel.DescriptionAttribute> attached to the `GetLanguage` method, it performs the following actions:

1. The runtime checks that the type argument `DescriptionAttribute` to `Type.GetCustomAttributes(Type type)` is public, and therefore is visible and accessible.
2. The runtime checks that the user-defined type `MyDescriptionAttribute` that's derived from `DescriptionAttribute` is visible and accessible within the System.Web.dll assembly, where it's attached to the method `GetLanguage()`.
3. The runtime checks that the constructor of `MyDescriptionAttribute` is visible and accessible within the System.Web.dll assembly.
4. The runtime calls the constructor of `MyDescriptionAttribute` with the custom attribute parameters and returns the new object to the caller.

The custom attribute reflection model could leak instances of user-defined types outside the assembly in which the type is defined. This is no different from the members in the runtime system library that return instances of user-defined types, such as <xref:System.Type.GetMethods%2A?displayProperty=nameWithType> returning an array of `RuntimeMethodInfo` objects. To prevent a client from discovering information about a user-defined custom attribute type, define the type's members to be nonpublic.

The following example demonstrates the basic way of using reflection to get access to custom attributes.

[!code-csharp[CustomAttributeData#2](../../../samples/snippets/csharp/VS_Snippets_CLR/CustomAttributeData/CS/source2.cs#2)]
[!code-vb[CustomAttributeData#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CustomAttributeData/VB/source2.vb#2)]

## See also

- <xref:System.Reflection.MemberInfo.GetCustomAttributes%2A?displayProperty=nameWithType>
- <xref:System.Attribute.GetCustomAttributes%2A?displayProperty=nameWithType>
- [View Type Information](viewing-type-information.md)
