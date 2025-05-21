---
title: System.Type.GetProperty methods
description: Learn about the System.Type.GetProperty methods.
ms.date: 03/30/2025
ms.topic: article
---
# System.Type.GetProperty methods

[!INCLUDE [context](includes/context.md)]

The following guidance applies to all overloads:

- A property is considered public to reflection if it has at least one accessor that is public. Otherwise the property is considered private, and you must use <xref:System.Reflection.BindingFlags.NonPublic?displayProperty=nameWithType> &#124; <xref:System.Reflection.BindingFlags.Instance?displayProperty=nameWithType> &#124; <xref:System.Reflection.BindingFlags.Static?displayProperty=nameWithType> (in Visual Basic, combine the values using ` Or `) to get it.
- If the current <xref:System.Type> represents a constructed generic type, this method returns the <xref:System.Reflection.PropertyInfo> with the type parameters replaced by the appropriate type arguments.
- If the current <xref:System.Type> represents a type parameter in the definition of a generic type or generic method, this method searches the properties of the class constraint.

## <xref:System.Type.GetProperty(System.String)> method

The search for `name` is case-sensitive. The search includes public static and public instance properties.

Situations in which <xref:System.Reflection.AmbiguousMatchException> occurs include the following:

- A type contains two indexed properties that have the same name but different numbers of parameters. To resolve the ambiguity, use an overload of the <xref:System.Type.GetProperty%2A> method that specifies parameter types.
- A derived type declares a property that hides an inherited property with the same name, by using the `new` modifier (`Shadows` in Visual Basic). To resolve the ambiguity, use the <xref:System.Type.GetProperty(System.String,System.Reflection.BindingFlags)> method overload and add the <xref:System.Reflection.BindingFlags.DeclaredOnly?displayProperty=nameWithType> flag to restrict the search to members that aren't inherited.

## <xref:System.Type.GetProperty(System.String,System.Reflection.BindingFlags)> method

The following <xref:System.Reflection.BindingFlags> filter flags can be used to define which properties to include in the search:

- You must specify either `BindingFlags.Instance` or `BindingFlags.Static` in order to get a return.
- Specify `BindingFlags.Public` to include public properties in the search.
- Specify `BindingFlags.NonPublic` to include non-public properties (that is, private, internal, and protected properties) in the search.
- Specify `BindingFlags.FlattenHierarchy` to include `public` and `protected` static members up the hierarchy; `private` static members in inherited classes are not included.

The following <xref:System.Reflection.BindingFlags> modifier flags can be used to change how the search works:

- `BindingFlags.IgnoreCase` to ignore the case of `name`.
- `BindingFlags.DeclaredOnly` to search only the properties declared on the <xref:System.Type>, not properties that were simply inherited.

Situations in which <xref:System.Reflection.AmbiguousMatchException> occurs include the following:

- A type contains two indexed properties that have the same name but different numbers of parameters. To resolve the ambiguity, use an overload of the <xref:System.Type.GetProperty%2A> method that specifies parameter types.
- A derived type declares a property that hides an inherited property with the same name, using the `new` modifier (`Shadows` in Visual Basic). To resolve the ambiguity, include <xref:System.Reflection.BindingFlags.DeclaredOnly?displayProperty=nameWithType> to restrict the search to members that are not inherited.

## [GetProperty(System.String, System.Reflection.BindingFlags, System.Reflection.Binder, System.Type, System.Type[], System.Reflection.ParameterModifier[])](xref:System.Type.GetProperty(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Type,System.Type[],System.Reflection.ParameterModifier[])) method

Although the default binder does not process <xref:System.Reflection.ParameterModifier> (the `modifiers` parameter), you can use the abstract <xref:System.Reflection.Binder?displayProperty=nameWithType> class to write a custom binder that does process `modifiers`. `ParameterModifier` is only used when calling through COM interop, and only parameters that are passed by reference are handled.

The following table shows what members of a base class are returned by the `Get` methods when reflecting on a type.

| Member Type | Static | Non-Static                                         |
|-------------|--------|----------------------------------------------------|
| Constructor | No     | No                                                 |
| Field       | No     | Yes. A field is always hide-by-name-and-signature. |
| Event       | Not applicable | The common type system rule is that the inheritance is the same as that of the methods that implement the property. Reflection treats properties as hide-by-name-and-signature.<sup>2</sup> |
| Method      | No     | Yes. A method (both virtual and non-virtual) can be hide-by-name or hide-by-name-and-signature.|
| Nested Type | No | No |
| Property    | Not applicable | The common type system rule is that the inheritance is the same as that of the methods that implement the property. Reflection treats properties as hide-by-name-and-signature.<sup>2</sup> |

Notes:

- Hide-by-name-and-signature considers all of the parts of the signature, including custom modifiers, return types, parameter types, sentinels, and unmanaged calling conventions. This is a binary comparison.
- For reflection, properties and events are hide-by-name-and-signature. If you have a property with both a get and a set accessor in the base class, but the derived class has only a get accessor, the derived class property hides the base class property, and you will not be able to access the setter on the base class.
- Custom attributes are not part of the common type system.

The following <xref:System.Reflection.BindingFlags> filter flags can be used to define which properties to include in the search:

- You must specify either `BindingFlags.Instance` or `BindingFlags.Static` in order to get a return.
- Specify `BindingFlags.Public` to include public properties in the search.
- Specify `BindingFlags.NonPublic` to include non-public properties (that is, private, internal, and protected properties) in the search.
- Specify `BindingFlags.FlattenHierarchy` to include `public` and `protected` static members up the hierarchy; `private` static members in inherited classes are not included.

The following <xref:System.Reflection.BindingFlags> modifier flags can be used to change how the search works:

- `BindingFlags.IgnoreCase` to ignore the case of `name`.
- `BindingFlags.DeclaredOnly` to search only the properties declared on the <xref:System.Type>, not properties that were simply inherited.

## Indexers and default properties

Visual Basic, C#, and C++ have simplified syntax for accessing indexed properties and allow one indexed property to be a default for its type. For example, if the variable `myList` refers to an <xref:System.Collections.ArrayList>, the syntax `myList[3]` (`myList(3)` in Visual Basic) retrieves the element with the index of 3. You can overload the property.

In C#, this feature is called an indexer and cannot be referred to by name. By default, a C# indexer appears in metadata as an indexed property named `Item`. However, a class library developer can use the <xref:System.Runtime.CompilerServices.IndexerNameAttribute> attribute to change the name of the indexer in the metadata. For example, the <xref:System.String> class has an indexer named <xref:System.String.Chars%2A>. Indexed properties created using languages other than C# can have names other than `Item`, as well.

To determine whether a type has a default property, use the <xref:System.Reflection.MemberInfo.GetCustomAttributes(System.Type,System.Boolean)> method to test for the <xref:System.Reflection.DefaultMemberAttribute> attribute. If the type has <xref:System.Reflection.DefaultMemberAttribute>, the <xref:System.Reflection.DefaultMemberAttribute.MemberName> property returns the name of the default property.
