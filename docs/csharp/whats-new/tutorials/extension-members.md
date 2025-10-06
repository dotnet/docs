---
title: Explore extension members in C# 14 to enhance existing types
description: "C# 14 enables provides new syntax for extensions that support properties and operators, and enables extensions on a type as well as an instance. Learn to use them, and how to migrate existing extension methods to extension members"
author: billwagner
ms.author: wiwagn
ms.service: dotnet-csharp
ms.topic: tutorial
ms.date: 10/06/2025
ai-usage: ai-assisted
#customer intent: As a C# developer, I reduce repeated code by introducting extension members for common tasks 
---
# Tutorial: Explore extension members in C# 14

C# 14 introduces extension members, an enhancement to the existing extension methods. Extension members enable you to add properties and operators. You can also extend types in addition to instances of types. This capability allows you to create more natural and expressive APIs when extending types you don't control.

In this tutorial, you explore extension members by enhancing the `System.Drawing.Point` type with mathematical operations, coordinate transformations, and utility properties. You learn how to migrate existing extension methods to the new extension member syntax and understand when to use each approach.

In this tutorial, you:

> [!div class="checklist"]
>
> * Create extension members with static properties and operators.
> * Implement coordinate transformations using extension members.
> * Migrate traditional extension methods to extension member syntax.
> * Compare extension members with traditional extension methods.

## Prerequisites

- The .NET 10 preview SDK. Download it from the [.NET download site](https://dotnet.microsoft.com/download/dotnet/10.0).
- Visual Studio 2026 (preview). Download it from the [Visual Studio insiders page](https://visualstudio.microsoft.com/insiders/).

## Create the sample application

Start by creating a console application that demonstrates both traditional extension methods and the new extension members syntax.

1. Create a new console application:

   ```dotnetcli
   dotnet new console -n PointExtensions
   cd PointExtensions
   ```

1. Copy the following code into a new filed named `ExtensionMethods.cs`:

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

Many apps that use 2D geometry will use the concept of an `Origin`, which is the same value as <xref:System.Drawing.Point.Empty?displayProperty=nameWithType>. This code uses that fact, but some developers might chose to create a `new Point(0,0)`, which incurs some extra work. In a given domain, you want to express these common values through static properties.

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

Traditional extension methods can't add operators to existing types. You must implement arithmetic operations manually, making the code verbose and harder to read. The algorithm gets duplicated whenever the operation is needed, which creates more opportunities for small mistakes to enter the code base. It's better to place that code in one location. Add the following operators to your extension block in `NewExtensionsMembers.cs`:

:::code language="csharp" source="snippets/PointExtensions/NewExtensionsMembers.cs" id="ArithmeticOperators":::

Extension members enable you to add operators directly to existing types. Now you can perform arithmetic operations using natural syntax:

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="PointArithmeticWithOperators":::

The extension operators make point arithmetic as natural as working with built-in numeric types.

## Add More operators

You can also add extension operators for the discrete operations shown in the following code example:

:::code language="csharp" source="snippets/PointExtensions/IncludedElements.cs" id="DiscreteXYOperators":::

The `+` and `-` operators are *binary operators* and require two operands, not three. Instead of two discrete integers, use a *tuple* to specify both the `X` and `Y` deltas:

:::code language="csharp" source="snippets/PointExtensions/NewExtensionsMembers.cs" id="TupleBasedXYOperators":::

This enables elegant tuple-based operations:

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="DiscreteXYOperators":::

Your extensions can include multiple overloaded operators, as long as the operands are distinct.

## Migrate instance methods to extension members

Extension members also support instance methods. You don't have to change existing extension methods. The old and new forms are binary and source compatible. If you want to keep all your extensions in one container, you can. Migrate traditional extension methods to the new syntax maintains the same functionality.

### Traditional extension methods

The traditional approach uses the `this` parameter syntax:

:::code language="csharp" source="snippets/PointExtensions/IncludedElements.cs" id="ExtensionMethods":::

Extension members use a different syntax but provide the same functionality. Add the following code to your new extension members class:

:::code language="csharp" source="snippets/PointExtensions/NewExtensionsMembers.cs" id="TransformationMethods":::

This code doesn't compile yet. That's because this is the first extension you've written that extends an *instance* of the `Point` class, instead of the type itself. To support instance extensions, your extension block needs to name the receiver parameter. Edit the following line:

```csharp
    extension (Point)
```

So that it gives a name to the `Point` instance:

```csharp
    extension (Point point)
```

Now, the code compiles. You can call these new instance methods exactly as you accessed traditional extension methods:

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="InstanceMethods":::

The key difference is syntax: extension members use `extension (Type variableName)` instead of `this Type variableName`.

## Completed sample

The final example shows the advantages when you combine static properties, operators, and instance methods to create comprehensive type extensions.

Compare the extension member version:

:::code language="csharp" source="snippets/PointExtensions/ExtensionMemberDemonstrations.cs" id="FinalScenarios":::

With the previous version:

:::code language="csharp" source="snippets/PointExtensions/IncludedElements.cs" id="FinalScenarios":::

This example demonstrates how extension members create a cohesive API that feels like part of the original type. You can:

- Use `Point.Origin` for a meaningful starting point
- Apply mathematical operators naturally (`point + offset`, `point * scale`)
- Chain transformations using both operators and methods
- Convert between related types (`ToVector()`)

### Migration benefits

When migrating from traditional extension methods to extension members, you gain:

1. **Static properties**: Add constants and computed values to types
1. **Operators**: Enable natural mathematical and logical operations
1. **Unified syntax**: All extension logic uses the same `extension` declaration
1. **Type-level extensions**: Extend the type itself, not just instances

Run the complete application to see both approaches side by side and observe how extension members provide a more integrated development experience.

## Related content

* [Extension methods (C# Programming Guide)](/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
* [What's new in C# 14](/dotnet/csharp/whats-new/csharp-14)
* [Operator overloading (C# reference)](/dotnet/csharp/language-reference/operators/operator-overloading)
