---
title: "Reflection (C#)"
description: Reflection provides objects that describe assemblies, modules, and types in C#. If your code includes attributes, reflection enables you to access them.
ms.date: 07/20/2015
ms.assetid: f80a2362-953b-4e8e-9759-cd5f334190d4
---
# Reflection (C#)

Reflection provides objects (of type <xref:System.Type>) that describe assemblies, modules, and types. You can use reflection to dynamically create an instance of a type, bind the type to an existing object, or get the type from an existing object and invoke its methods or access its fields and properties. If you are using attributes in your code, reflection enables you to access them. For more information, see [Attributes](../../../standard/attributes/index.md).

Here's a simple example of reflection using the <xref:System.Object.GetType> method - inherited by all types from the `Object` base class - to obtain the type of a variable:

> [!NOTE]
> Make sure you add `using System;` and `using System.Reflection;` at the top of your *.cs* file.

```csharp
// Using GetType to obtain type information:
int i = 42;
Type type = i.GetType();
Console.WriteLine(type);
```

The output is: `System.Int32`.

The following example uses reflection to obtain the full name of the loaded assembly.

```csharp
// Using Reflection to get information of an Assembly:
Assembly info = typeof(int).Assembly;
Console.WriteLine(info);
```

The output is: `System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e`.

> [!NOTE]
> The C# keywords `protected` and `internal` have no meaning in Intermediate Language (IL) and are not used in the reflection APIs. The corresponding terms in IL are *Family* and *Assembly*. To identify an `internal` method using reflection, use the <xref:System.Reflection.MethodBase.IsAssembly%2A> property. To identify a `protected internal` method, use the <xref:System.Reflection.MethodBase.IsFamilyOrAssembly%2A>.

## Reflection overview

Reflection is useful in the following situations:

- When you have to access attributes in your program's metadata. For more information, see [Retrieving Information Stored in Attributes](../../../standard/attributes/retrieving-information-stored-in-attributes.md).
- For examining and instantiating types in an assembly.
- For building new types at runtime. Use classes in <xref:System.Reflection.Emit>.
- For performing late binding, accessing methods on types created at run time. See the topic [Dynamically Loading and Using Types](../../../framework/reflection-and-codedom/dynamically-loading-and-using-types.md).

## Related sections

For more information:

- [Reflection](../../../framework/reflection-and-codedom/reflection.md)
- [Viewing Type Information](../../../framework/reflection-and-codedom/viewing-type-information.md)
- [Reflection and Generic Types](../../../framework/reflection-and-codedom/reflection-and-generic-types.md)
- <xref:System.Reflection.Emit>
- [Retrieving Information Stored in Attributes](../../../standard/attributes/retrieving-information-stored-in-attributes.md)

## See also

- [C# Programming Guide](../index.md)
- [Assemblies in .NET](../../../standard/assembly/index.md)
