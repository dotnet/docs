---
title: "How to implement and call a custom extension method"
description: Learn how to implement extension methods for any .NET type. Client code can use your methods by adding a reference to a DLL and adding a using directive.
ms.date: 10/02/2024
helpviewer_keywords: 
  - "extension methods [C#], implementing and calling"
ms.topic: how-to
---
# How to implement and call a custom extension method (C# Programming Guide)

This article shows how to implement your own extension methods for any .NET type. Client code can use your extension methods. Client projects must reference the assembly that contains them. Client projects must add a [using](../../language-reference/keywords/using-directive.md) directive that specifies the namespace in which the extension methods are defined.

To define and call the extension method:

1. Define a static [class](./static-classes-and-static-class-members.md) to contain the extension method. The class can't be nested inside another type and must be visible to client code. For more information about accessibility rules, see [Access Modifiers](./access-modifiers.md).
1. Implement the extension method as a static method with at least the same visibility as the containing class.
1. The first parameter of the method specifies the type that the method operates on; it must be preceded with the [this](../../language-reference/keywords/this.md) modifier.
1. In the calling code, add a `using` directive to specify the [namespace](../../language-reference/keywords/namespace.md) that contains the extension method class.
1. Call the methods as instance methods on the type.

> [!NOTE]
>
> The first parameter is not specified by calling code because it represents the type on which the operator is being applied, and the compiler already knows the type of your object. You only have to provide arguments for parameters 2 through `n`.

The following example implements an extension method named `WordCount` in the `CustomExtensions.StringExtension` class. The method operates on the <xref:System.String> class, which is specified as the first method parameter. The `CustomExtensions` namespace is imported into the application namespace, and the method is called inside the `Main` method.

:::code language="csharp" source="./snippets/how-to-implement-and-call-a-custom-extension-method/Program.cs" :::

Overload resolution prefers instance or static method defined by the type itself to extension methods. Extension methods can't access any private data in the extended class.

## See also

- [Extension Methods](./extension-methods.md)
- [LINQ (Language-Integrated Query)](../../linq/index.md)
- [Static Classes and Static Class Members](./static-classes-and-static-class-members.md)
- [protected](../../language-reference/keywords/protected.md)
- [internal](../../language-reference/keywords/internal.md)
- [public](../../language-reference/keywords/public.md)
- [this](../../language-reference/keywords/this.md)
- [namespace](../../language-reference/keywords/namespace.md)
