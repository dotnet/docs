---
title: System.Reflection.Context.CustomReflectionContext class
description: Learn about the System.Reflection.Context.CustomReflectionContext class.
ms.date: 02/12/2026
ai-usage: ai-assisted
---
# System.Reflection.Context.CustomReflectionContext class

[!INCLUDE [context](includes/context.md)]

<xref:System.Reflection.Context.CustomReflectionContext> provides a way for you to add or remove custom attributes from reflection objects, or add dummy properties to those objects, without re-implementing the complete reflection model. The default <xref:System.Reflection.Context.CustomReflectionContext> simply wraps reflection objects without making any changes, but by subclassing and overriding the relevant methods, you can add, remove, or change the attributes that apply to any reflected parameter or member, or add new properties to a reflected type.

For example, suppose that your code follows the convention of applying a particular attribute to factory methods, but you're now required to work with third-party code that lacks attributes. You can use <xref:System.Reflection.Context.CustomReflectionContext> to specify a rule for identifying the objects that should have attributes and to supply the objects with those attributes when they're viewed from your code.

To use <xref:System.Reflection.Context.CustomReflectionContext> effectively, the code that uses the reflected objects must support the notion of specifying a reflection context, instead of assuming that all reflected objects are associated with the runtime reflection context. Many reflection methods in the .NET Framework provide a <xref:System.Reflection.ReflectionContext> parameter for this purpose.

To modify the attributes that are applied to a reflected parameter or member, override the <xref:System.Reflection.Context.CustomReflectionContext.GetCustomAttributes%28System.Reflection.ParameterInfo%2CSystem.Collections.Generic.IEnumerable%7BSystem.Object%7D%29> or <xref:System.Reflection.Context.CustomReflectionContext.GetCustomAttributes%28System.Reflection.MemberInfo%2CSystem.Collections.Generic.IEnumerable%7BSystem.Object%7D%29> method. These methods take the reflected object and the list of attributes under its current reflection context, and return the list of attributes it should have under the custom reflection context.

> [!WARNING]
> <xref:System.Reflection.Context.CustomReflectionContext> methods should not access the list of attributes of a reflected object or method directly by calling the <xref:System.Reflection.MemberInfo.GetCustomAttributes%2A> method on the provided <xref:System.Reflection.MemberInfo> or <xref:System.Reflection.ParameterInfo> instance, but should instead use the `declaredAttributes` list, which is passed as a parameter to the <xref:System.Reflection.Context.CustomReflectionContext.GetCustomAttributes%2A> method overloads.

To add properties to a reflected type, override the <xref:System.Reflection.Context.CustomReflectionContext.AddProperties%2A> method. The method accepts a parameter that specifies the reflected type, and returns a list of additional properties. You should use the <xref:System.Reflection.Context.CustomReflectionContext.CreateProperty%2A> method to create property objects to return. You can specify delegates when creating the property that serve as the property accessor, and you can omit one of the accessors to create a read-only or write-only property. Note that such dummy properties have no metadata or Common Intermediate Language (CIL) backing.

> [!WARNING]
> - Be cautious about equality among reflected objects when you work with reflection contexts, because objects might represent the same reflected object in multiple contexts. You can use the <xref:System.Reflection.Context.CustomReflectionContext.MapType%2A> method to obtain a particular reflection context's version of a reflected object.
> - A <xref:System.Reflection.Context.CustomReflectionContext> object alters the attributes returned by a particular reflection object, such as those obtained by the <xref:System.Reflection.MemberInfo.GetCustomAttributes%2A> method. It doesn't alter the custom attribute data returned by the <xref:System.Reflection.MemberInfo.GetCustomAttributesData%2A> method, and these two lists won't match when you use a custom reflection context.

## Example

The following example demonstrates how to subclass <xref:System.Reflection.Context.CustomReflectionContext> to add a custom attribute to all the members of a given type whose names begin with "To". To run this code, paste it into an empty console project and add a reference to the `System.Reflection.Context` NuGet package.

:::code language="csharp" source="./snippets/system-reflection-context-customreflectioncontext/csharp/program.cs" id="Snippet1":::
