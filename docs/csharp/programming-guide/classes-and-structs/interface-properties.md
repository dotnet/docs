---
title: "Interface Properties"
description: Properties can be declared on an interface in C#. This example declares an interface property accessor.
ms.date: 08/20/2024
helpviewer_keywords: 
  - "properties [C#], on interfaces"
  - "interfaces [C#], properties"
ms.topic: article
---
# Interface Properties (C# Programming Guide)

Properties can be declared on an [interface](../../language-reference/keywords/interface.md). The following example declares an interface property accessor:

:::code language="csharp" source="./snippets/properties/interfaces.cs" id="SnippetDeclareInterfaceProperties":::

Interface properties typically don't have a body. The accessors indicate whether the property is read-write, read-only, or write-only. Unlike in classes and structs, declaring the accessors without a body doesn't declare an [automatically implemented property](auto-implemented-properties.md). An interface can define a default implementation for members, including properties. Defining a default implementation for a property in an interface is rare because interfaces can't define instance data fields.

## Example

In this example, the interface `IEmployee` has a read-write property, `Name`, and a read-only property, `Counter`. The class `Employee` implements the `IEmployee` interface and uses these two properties. The program reads the name of a new employee and the current number of employees and displays the employee name and the computed employee number.

You could use the fully qualified name of the property, which references the interface in which the member is declared. For example:

:::code language="csharp" source="./snippets/properties/interfaces.cs" id="SnippetExplicitImplementation":::

The preceding example demonstrates [Explicit Interface Implementation](../interfaces/explicit-interface-implementation.md). For example, if the class `Employee` is implementing two interfaces `ICitizen` and `IEmployee` and both interfaces have the `Name` property, the explicit interface member implementation is necessary. That is, the following property declaration:

:::code language="csharp" source="./snippets/properties/interfaces.cs" id="SnippetExplicitImplementation":::

Implements the `Name` property on the `IEmployee` interface, while the following declaration:

:::code language="csharp" source="./snippets/properties/interfaces.cs" id="SnippetCitizenImplementation":::

Implements the `Name` property on the `ICitizen` interface.

:::code language="csharp" source="./snippets/properties/interfaces.cs" id="SnippetPropertyExample":::
:::code language="csharp" source="./snippets/properties/interfaces.cs" id="SnippetUseProperty":::

## Sample output

```console
Enter number of employees: 210
Enter the name of the new employee: Hazem Abolrous
The employee information:
Employee number: 211
Employee name: Hazem Abolrous
```

## See also

- [Properties](./properties.md)
- [Using Properties](./using-properties.md)
- [Comparison Between Properties and Indexers](../indexers/comparison-between-properties-and-indexers.md)
- [Indexers](../indexers/index.md)
- [Interfaces](../../fundamentals/types/interfaces.md)
