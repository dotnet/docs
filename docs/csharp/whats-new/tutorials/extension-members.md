---
title: Explore extension members in C# 14 and C# 15 to enhance existing types
description: "C# 14 extension members add properties and operators to existing types. C# 15 extension indexers add indexed access. Learn both with runnable Point and Path examples."
author: billwagner
ms.author: wiwagn
ms.service: dotnet-csharp
ms.topic: tutorial
ms.date: 07/15/2026
ai-usage: ai-assisted
#customer intent: As a C# developer, I reduce repeated code by introducing extension members for common tasks 
---
# Tutorial: Explore extension members in C# 14 and C# 15

C# 14 introduced extension members, an enhancement to the existing extension methods. Extension members enable you to add properties and operators. You can also extend types as well as instances of types. C# 15 adds extension indexers, so an existing type can support indexed access from an extension block.

In this tutorial, you explore extension members by enhancing the `System.Drawing.Point` type with mathematical operations, coordinate transformations, and utility properties. Then you add indexed access to a `Path` type that stores point-to-point offsets. You learn how to migrate existing extension methods to the new extension member syntax and when each approach fits.

In this tutorial, you:

> [!div class="checklist"]
>
> * Create C# 14 extension members with static properties and operators.
> * Implement coordinate transformations using extension members.
> * Migrate traditional extension methods to extension member syntax.
> * Add a C# 15 extension indexer that reads and updates absolute points in a path.
> * Compare extension members with traditional extension methods.

## Prerequisites

- The .NET 11 preview SDK. Download it from the [.NET download site](https://dotnet.microsoft.com/download/dotnet/11.0).
- Visual Studio 2026 with preview features enabled. Download it from the [Visual Studio page](https://visualstudio.microsoft.com).
- This sample sets `<LangVersion>preview</LangVersion>` because extension indexers are a C# 15 preview feature.

## Create the sample application

Start by creating a console application that demonstrates both traditional extension methods and the new extension members syntax. You create extensions for the <xref:System.Drawing.Point?displayProperty=fullName> type. This type comes from the `System.Drawing` namespace and is typically used in Windows Forms applications.

1. Create a new console application.

   ```dotnetcli
   dotnet new console -n PointExtensions
   cd PointExtensions
   ```

1. Update the project file so the sample targets .NET 11 and uses preview language features:

   :::code language="xml" source="snippets/PointExtensions/PointExtensions.csproj":::

1. Copy the following code into a new file named `ExtensionMethods.cs`:

   :::code language="csharp" source="snippets/PointExtensions/ExtensionMethods.cs":::

1. Copy the following code that demonstrates these extension methods and other uses of the <xref:System.Drawing.Point?displayProperty=nameWithType>:

   :::code language="csharp" source="snippets/PointExtensions/ExtensionMethodsDemonstrations.cs":::

1. Replace the content of `Program.cs` with the demonstration code:

   :::code language="csharp" source="snippets/PointExtensions/Program.cs" id="TraditionalExtensionMethods":::

1. Run the sample application and examine the output.

Traditional extension methods can only add instance methods to existing types. Extension members enable you to add static properties, which provides a more natural way to extend types with constants or computed values.

## Add static properties with extension members

First, examine this code in the sample:

:::code language="csharp" source="snippets/PointExtensions/IncludedElements.cs" id="StaticPropertySubstitute":::

Many apps that use 2D geometry use the concept of an `Origin`, which is the same value as <xref:System.Drawing.Point.Empty?displayProperty=nameWithType>. This code uses that fact, but some developers might create a `new Point(0,0)`, which incurs some extra work. In a given domain, you want to express these common values through static properties.

Create `NewExtensionsMembers.cs` to create extension members that solve this problem:

```csharp
using System.Drawing;
using System.Numerics;

namespace ExtensionMembers;

public static class PointExtensions
{
    extension (Point)
    {
        public static Point Origin => Point.Empty;
    }
}
```

The preceding code adds a static *extension property* to the `Point` struct. The `extension` keyword introduces an *extension block*. This extension block extends the `Point` struct.

You can use this static property as though it were a member of the `Point` struct.

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="StaticProperty":::

The `Point.Origin` property now appears as if it were part of the original `Point` type, providing a more intuitive API.

## Implement arithmetic operators

Next, examine the following code that performs arithmetic with points:

:::code language="csharp" source="snippets/PointExtensions/IncludedElements.cs" id="PointArithmetic":::

Traditional extension methods can't add operators to existing types. You must implement arithmetic operations manually, which makes the code verbose and harder to read. The algorithm gets duplicated whenever you need the operation, which creates more opportunities for small mistakes to enter the code base. It's better to place that code in one location. Add the following operators to your extension block in `NewExtensionsMembers.cs`:

:::code language="csharp" source="snippets/PointExtensions/NewExtensionsMembers.cs" id="ArithmeticOperators":::

By using extension members, you can add operators directly to existing types. Now you can perform arithmetic operations by using natural syntax:

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="PointArithmeticWithOperators":::

The extension operators make point arithmetic as natural as working with built-in numeric types.

## Add more operators

You can also add extension operators for the discrete operations shown in the following code example:

:::code language="csharp" source="snippets/PointExtensions/IncludedElements.cs" id="DiscreteXYOperators":::

The `+` and `-` operators are *binary operators* and require two operands, not three. Instead of two discrete integers, use a *tuple* to specify both the `X` and `Y` deltas:

:::code language="csharp" source="snippets/PointExtensions/NewExtensionsMembers.cs" id="TupleBasedXYOperators":::

The preceding operator enables elegant tuple-based operations:

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="DiscreteXYOperators":::

Your extensions can include multiple overloaded operators, as long as the operands are distinct.

## Migrate instance methods to extension members

Extension members also support instance methods. You don't have to change existing extension methods. The old and new forms are binary and source compatible. If you want to keep all your extensions in one container, you can. Migrating traditional extension methods to the new syntax maintains the same functionality.

### Traditional extension methods

The traditional approach uses the `this` parameter syntax:

:::code language="csharp" source="snippets/PointExtensions/IncludedElements.cs" id="ExtensionMethods":::

Extension members use a different syntax but provide the same functionality. Add the following code to your new extension members class:

:::code language="csharp" source="snippets/PointExtensions/NewExtensionsMembers.cs" id="TransformationMethods":::

These methods extend an instance of the `Point` struct, not the `Point` type. The extension block names the receiver parameter so the method body can read that point. The sample uses `extension(ref Point point)` because `Translate`, `Scale`, and `Rotate` change the caller's `Point`. Without `ref`, those methods would update a copy of the struct, and the caller wouldn't see the change.

You can call these new instance methods exactly as you accessed traditional extension methods:

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="InstanceMethods":::

The key difference is syntax: extension members use `extension (Type variableName)` instead of `this Type variableName`.

## Add extension indexers

C# 15 adds indexers to `extension` blocks. An indexer has no name. Code accesses it with `this[...]` in the declaration and with indexed syntax at the call site.

Imagine a path type that stores each step as a relative offset. When you ask for `path[i]`, you want the absolute point at that step. When you assign `path[i] = target`, you want the type to update the one offset that gets you there. Indexed access reads like "the point at this step" and keeps the offset-to-point math in one place.

Imagine that `Path` came from a library. If you don't own the type, you can't add an indexer to its source. Before C# 15, you could add methods, but you couldn't add `this[...]` indexed access to a type you don't control. This tutorial defines `Path` so the sample is runnable; think of it as standing in for that library type.

For this section, add a `Path` type. The type stores a sequence of `(dX, dY)` offsets. Each offset says how far to move from the previous point. The first offset starts at `Point.Origin`, the static extension property you added earlier.

Create a new file named `Path.cs` in the same project as the other sample files. Add the `Path` type to the `ExtensionMembers` namespace in that file. Keeping `Path` in this namespace makes it your sample type, not <xref:System.IO.Path>. The demo file uses a `using Path = ExtensionMembers.Path;` alias, so every `Path` in the demo means the sample path type.

:::code language="csharp" source="snippets/PointExtensions/Path.cs" id="PathType":::

Now add an indexer for `Path`. Put this code in the existing `PointExtensions` static class in `NewExtensionsMembers.cs`. Add it as a new `extension(Path path)` block, separate from the `extension(Point)` block for static members and operators and separate from the `extension(ref Point point)` block for instance methods:

:::code language="csharp" source="snippets/PointExtensions/NewExtensionsMembers.cs" id="PathIndexer":::

Indexers are always instance members, so this new extension block must name the receiver: `extension(Path path)`. A block written as `extension(Path)` wouldn't provide a `path` variable for the indexer body.

`Path` is a class that owns a list of offsets. The indexer doesn't need a `ref` receiver because the setter changes the contents of that existing `Path` object.

The getter starts at `Point.Origin`, then adds the offsets from index `0` through the requested index. With offsets `(2, 3)`, `(1, 1)`, and `(-1, 4)`, the absolute points are `(2, 3)`, `(3, 4)`, and `(2, 8)`.

The setter receives a target absolute point. It leaves earlier offsets alone and changes only the offset at the requested index. The new offset is the target point minus the absolute point at the previous index. Later points shift because they remain relative to the changed offset.

Now, use the indexer to read and write points along the path:

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="PathIndexerUse":::

Both accessors throw <xref:System.ArgumentOutOfRangeException> when the index doesn't refer to an offset in the path.

## Completed sample

The final example shows the advantages when you combine static properties, operators, instance methods, and an indexer to create comprehensive type extensions.

Compare the extension member version:

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="FinalScenarios":::

With the previous version:

:::code language="csharp" source="snippets/PointExtensions/IncludedElements.cs" id="FinalScenarios":::

This example demonstrates how extension members create a cohesive API that feels like part of the original type. You can:

- Use `Point.Origin` for a meaningful starting point
- Apply mathematical operators naturally (`point + offset`, `point * scale`)
- Chain transformations using both operators and methods
- Convert between related types (`ToVector()`)
- Read and update absolute points along a path with `path[index]`

### Migration benefits

When you migrate from traditional extension methods to extension members, you get:

1. **Static properties**: Add constants and computed values to types.
1. **Operators**: Enable natural mathematical and logical operations.
1. **Indexers**: Add C# 15 indexed access that can compute values from an existing type and update its stored state.
1. **Unified syntax**: All extension logic uses the same `extension` declaration.
1. **Type-level extensions**: Extend the type itself, not only instances.

Run the complete application to see both approaches side by side and observe how extension members provide a more integrated development experience.

## Related content

- [Extension methods (C# Programming Guide)](../../programming-guide/classes-and-structs/extension-methods.md)
- [What's new in C# 14](../csharp-14.md)
- [What's new in C# 15](../csharp-15.md)
- [`extension` keyword (C# reference)](../../language-reference/keywords/extension.md)
- [Extension indexers feature specification](~/_csharplang/proposals/extension-indexers.md)
- [Operator overloading (C# reference)](../../language-reference/operators/operator-overloading.md)
